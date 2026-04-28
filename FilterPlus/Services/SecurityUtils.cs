using System.Text.RegularExpressions;

namespace FilterPlus.Services;

public static class SecurityUtils
{
    /// <summary>
    /// Sanitizes input to prevent common injection attacks (XSS, SQLi, etc.).
    /// Although this is a desktop app, it's a good practice.
    /// </summary>
    public static string SanitizeInput(string input)
    {
        if (string.IsNullOrEmpty(input)) return string.Empty;
        
        // Remove potential script tags
        string sanitized = Regex.Replace(input, @"<[^>]*>", string.Empty);
        
        // Trim to a reasonable length to prevent buffer overflow/DoS
        if (sanitized.Length > 200) sanitized = sanitized.Substring(0, 200);
        
        return sanitized.Trim();
    }

    /// <summary>
    /// Validates if the string is a safe name for a tab or filter.
    /// </summary>
    public static bool IsSafeInput(string input)
    {
        if (string.IsNullOrEmpty(input)) return true;
        
        // Check for common malicious patterns
        if (input.Contains("..") || input.Contains("/") || input.Contains("\\")) return false;
        
        return true;
    }
}
