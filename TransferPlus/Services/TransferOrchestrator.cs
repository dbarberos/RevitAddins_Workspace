using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Autodesk.Revit.DB;
using TransferPlus.Models;

namespace TransferPlus.Services;

public class TransferOrchestrator
{
    public static void TransferElements(Document sourceDoc, Document targetDoc, IEnumerable<TransferItem> items, bool overrideDuplicates)
    {
        var elementsToCopy = new List<ElementId>();
        var familiesToLoad = new List<TransferItem>();

        foreach (var item in items)
        {
            if (item.IsLoadable)
            {
                familiesToLoad.Add(item);
            }
            else
            {
                elementsToCopy.Add(item.ElementId);
            }
        }

        using (Transaction t = new Transaction(targetDoc, "TransferPlus: Copy Elements"))
        {
            t.Start();
            WarningSwallower.AttachToTransaction(t);

            if (elementsToCopy.Any())
            {
                CopyPasteOptions options = new CopyPasteOptions();
                options.SetDuplicateTypeNamesHandler(overrideDuplicates 
                    ? new CustomCopyHandlerOk() 
                    : new CustomCopyHandlerAbort());

                try
                {
                    ElementTransformUtils.CopyElements(sourceDoc, elementsToCopy, targetDoc, Transform.Identity, options);
                }
                catch (Exception)
                {
                    // Optionally log
                }
            }

            foreach (var famItem in familiesToLoad)
            {
                try
                {
                    Family? family = sourceDoc.GetElement(famItem.ElementId) as Family;
                    if (family == null)
                    {
                        var symbol = sourceDoc.GetElement(famItem.ElementId) as FamilySymbol;
                        family = symbol?.Family;
                    }

                    if (family != null)
                    {
                        Document famDoc = sourceDoc.EditFamily(family);
                        famDoc.LoadFamily(targetDoc, new FamilyLoadOptionsOk());
                        famDoc.Close(false);
                    }
                }
                catch (Exception)
                {
                    // Optionally log
                }
            }

            t.Commit();
        }
    }

    private class CustomCopyHandlerOk : IDuplicateTypeNamesHandler
    {
        public DuplicateTypeAction OnDuplicateTypeNamesFound(DuplicateTypeNamesHandlerArgs args)
        {
            return DuplicateTypeAction.UseDestinationTypes;
        }
    }

    private class CustomCopyHandlerAbort : IDuplicateTypeNamesHandler
    {
        public DuplicateTypeAction OnDuplicateTypeNamesFound(DuplicateTypeNamesHandlerArgs args)
        {
            return DuplicateTypeAction.Abort;
        }
    }

    private class FamilyLoadOptionsOk : IFamilyLoadOptions
    {
        public bool OnFamilyFound(bool familyInUse, out bool overwriteParameterValues)
        {
            overwriteParameterValues = true;
            return true;
        }

        public bool OnSharedFamilyFound(Family sharedFamily, bool familyInUse, out FamilySource source, out bool overwriteParameterValues)
        {
            source = FamilySource.Family;
            overwriteParameterValues = true;
            return true;
        }
    }
}
