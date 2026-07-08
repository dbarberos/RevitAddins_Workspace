// ==============================================================================
// SKILL: SKILL-RVT-DATA (Data & Information)
// PATTERN: Material PBR & Appearance Asset Modifier
// PURPOSE: Safely interacts with the Protein Render Engine in Revit. 
//          Handles the duplication of shared Appearance Assets to prevent 
//          cross-material contamination and manages the strict EditScope 
//          required to mutate visual properties (like Color or Transparency).
// DEPENDENCIES: Autodesk.Revit.DB, Autodesk.Revit.DB.Visual
// ==============================================================================

using System;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Visual;

namespace RevitAddinBase.Data
{
    /// <summary>
    /// Utility class for safely modifying Revit Material visual properties.
    /// </summary>
    public static class MaterialAssetModifier
    {
        /// <summary>
        /// Ensures that the material has its own unique Appearance Asset.
        /// If the asset is shared with other materials, it duplicates it.
        /// MUST be called within an active Transaction.
        /// </summary>
        /// <param name="doc">The active Document.</param>
        /// <param name="material">The target Material element.</param>
        /// <returns>True if the asset was isolated/duplicated; False if it failed.</returns>
        public static bool IsolateAppearanceAsset(Document doc, Material material)
        {
            if (doc == null || material == null) return false;

            ElementId appearanceAssetId = material.AppearanceAssetId;
            if (appearanceAssetId == ElementId.InvalidElementId) return false;

            AppearanceAssetElement currentAsset = doc.GetElement(appearanceAssetId) as AppearanceAssetElement;
            if (currentAsset == null) return false;

            // Simple heuristic to avoid infinite renaming if we run the script multiple times
            if (currentAsset.Name.EndsWith("_Isolated")) return true; 

            try
            {
                // Duplicate the asset in the database
                AppearanceAssetElement clonedAsset = currentAsset.Duplicate(currentAsset.Name + "_Isolated");
                
                // Assign the newly cloned asset back to our specific material
                material.AppearanceAssetId = clonedAsset.Id;
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[MaterialAPI] Failed to isolate asset: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Changes the primary Albedo/Diffuse color of a Generic material asset.
        /// Automatically manages the AppearanceAssetEditScope.
        /// MUST be called within an active Transaction.
        /// </summary>
        /// <param name="doc">The active Document.</param>
        /// <param name="material">The target Material element.</param>
        /// <param name="r">Red channel (0-255)</param>
        /// <param name="g">Green channel (0-255)</param>
        /// <param name="b">Blue channel (0-255)</param>
        public static void SetGenericMaterialColor(Document doc, Material material, byte r, byte g, byte b)
        {
            if (doc == null || material == null) return;

            ElementId assetId = material.AppearanceAssetId;
            if (assetId == ElementId.InvalidElementId) return;

            AppearanceAssetElement assetElement = doc.GetElement(assetId) as AppearanceAssetElement;
            if (assetElement == null) return;

            // The EditScope acts as an exclusive lock on the render engine
            using (AppearanceAssetEditScope editScope = new AppearanceAssetEditScope(doc))
            {
                try
                {
                    // 1. Open the asset for writing
                    Asset editableAsset = editScope.Start(assetId);

                    // 2. Locate the diffuse color property (Assuming the material uses the Generic schema)
                    AssetProperty genericDiffuseProp = editableAsset.FindByName("generic_diffuse");
                    
                    if (genericDiffuseProp is AssetPropertyDoubleArray4d colorProp)
                    {
                        // 3. Protein engine expects normalized colors (0.0 to 1.0) instead of 0-255
                        Color color = new Color(r, g, b);
                        double redNorm = color.Red / 255.0;
                        double greenNorm = color.Green / 255.0;
                        double blueNorm = color.Blue / 255.0;
                        
                        // Set the RGBA values (Alpha is the 4th parameter)
                        colorProp.SetValueAsColor(new Color(r, g, b));
                    }

                    // 4. Commit the changes to the engine
                    editScope.Commit(true);
                }
                catch (Exception ex)
                {
                    editScope.Cancel();
                    System.Diagnostics.Debug.WriteLine($"[MaterialAPI] EditScope failed: {ex.Message}");
                }
            }
        }
    }
}