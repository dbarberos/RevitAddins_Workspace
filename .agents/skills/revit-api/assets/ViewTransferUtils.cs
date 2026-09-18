using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Autodesk.Revit.DB;

namespace RevitApi.Assets;

/// <summary>
/// Reusable utility methods for cross-document view matching, string normalization,
/// and session-level view mapping in Revit Add-ins.
/// </summary>
public static class ViewTransferUtils
{
    /// <summary>
    /// Strips all punctuation, symbols, and whitespace, returning lowercase alphanumeric characters only.
    /// </summary>
    public static string ToAlphaNumericOnly(string input)
    {
        if (string.IsNullOrEmpty(input)) return string.Empty;
        var sb = new System.Text.StringBuilder();
        foreach (char c in input)
        {
            if (char.IsLetterOrDigit(c))
            {
                sb.Append(char.ToLowerInvariant(c));
            }
        }
        return sb.ToString();
    }

    /// <summary>
    /// Normalizes unicode dashes, hyphens, and whitespace variations into standard ASCII space and hyphen.
    /// </summary>
    public static string NormalizeName(string text)
    {
        if (string.IsNullOrEmpty(text)) return string.Empty;

        char[] dashes = new char[] { '\u2010', '\u2011', '\u2012', '\u2013', '\u2014', '\u2015', '\u2212', '\u00AD' };
        foreach (char d in dashes)
        {
            text = text.Replace(d, '-');
        }

        char[] whitespaces = new char[] { '\u00A0', '\u200B', '\uFEFF', '\r', '\n', '\t', '\u2000', '\u2001', '\u2002', '\u2003', '\u2004', '\u2005', '\u2006', '\u2007', '\u2008', '\u2009', '\u200A', '\u202F', '\u205F', '\u3000' };
        foreach (char ws in whitespaces)
        {
            text = text.Replace(ws, ' ');
        }

        return Regex.Replace(text, @"\s+", " ").Trim();
    }

    /// <summary>
    /// Performs a robust 4-tier search for an existing view in targetDoc by name.
    /// Handles exact matches, unicode space/dash normalization, VIEW_NAME parameter lookup,
    /// and fallback alphanumeric-only matching.
    /// </summary>
    public static View? FindExistingViewByName(Document doc, string viewName)
    {
        if (doc == null || string.IsNullOrWhiteSpace(viewName)) return null;

        string exactTarget = viewName.Trim();
        string cleanTarget = NormalizeName(viewName);
        string alphaTarget = ToAlphaNumericOnly(viewName);

        var views = new FilteredElementCollector(doc)
            .OfClass(typeof(View))
            .WhereElementIsNotElementType()
            .Cast<View>()
            .Where(v => v != null && v.IsValidObject && !v.IsTemplate)
            .ToList();

        // Tier 1: Exact match
        foreach (View v in views)
        {
            try
            {
                if (v.Name.Trim().Equals(exactTarget, StringComparison.OrdinalIgnoreCase))
                    return v;
            }
            catch { }
        }

        // Tier 2: Normalized match
        foreach (View v in views)
        {
            try
            {
                if (NormalizeName(v.Name).Equals(cleanTarget, StringComparison.OrdinalIgnoreCase))
                    return v;
            }
            catch { }
        }

        // Tier 3: BuiltInParameter.VIEW_NAME match
        foreach (View v in views)
        {
            try
            {
                Parameter p = v.get_Parameter(BuiltInParameter.VIEW_NAME);
                if (p != null && p.HasValue)
                {
                    string pVal = NormalizeName(p.AsString());
                    if (pVal.Equals(cleanTarget, StringComparison.OrdinalIgnoreCase))
                        return v;
                }
            }
            catch { }
        }

        // Tier 4: AlphaNumeric-only match
        if (!string.IsNullOrEmpty(alphaTarget))
        {
            foreach (View v in views)
            {
                try
                {
                    if (ToAlphaNumericOnly(v.Name).Equals(alphaTarget, StringComparison.OrdinalIgnoreCase))
                        return v;
                }
                catch { }
            }
        }

        return null;
    }
}
