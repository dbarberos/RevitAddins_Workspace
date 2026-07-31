using System;
using System.IO;
using System.Linq;
using Autodesk.Revit.DB;
using TransferPlus.Services;

namespace TransferPlus.Services
{
    /// <summary>
    /// Opciones de carga de familia silenciosas para evitar diálogos modales de Revit.
    /// Sobrescribe de forma automática definiciones y valores de parámetros.
    /// </summary>
    public class SilentOverwriteFamilyOption : IFamilyLoadOptions
    {
        public bool OnFamilyFound(bool familyInUse, out bool overwriteParameterValues)
        {
            overwriteParameterValues = true;
            return true; // Sobrescribir silenciosamente sin diálogo modal
        }

        public bool OnSharedFamilyFound(Family sharedFamily, bool familyInUse, out FamilySource source, out bool overwriteParameterValues)
        {
            source = FamilySource.Family;
            overwriteParameterValues = true;
            return true; // Sobrescribir silenciosamente sin diálogo modal
        }
    }

    /// <summary>
    /// Servicio encintado para operaciones con la API de familias de Revit.
    /// Implementa carga segura, transacciones con supresión de advertencias (WarningSwallower) y manipulación de símbolos.
    /// </summary>
    public class FamilyRevitService
    {
        /// <summary>
        /// Intenta cargar una familia (.rfa) en el documento destino dentro de una transacción con WarningSwallower.
        /// </summary>
        public bool TryLoadFamily(Document document, string rfaFilePath, out Family? family)
        {
            family = null;
            if (document == null || string.IsNullOrWhiteSpace(rfaFilePath) || !File.Exists(rfaFilePath))
            {
                return false;
            }

            var overwriteOptions = new SilentOverwriteFamilyOption();

            using var transaction = new Transaction(document, "Cargar Familia TransferPlus");
            WarningSwallower.AttachToTransaction(transaction);
            transaction.Start();

            try
            {
                if (document.LoadFamily(rfaFilePath, overwriteOptions, out family))
                {
                    transaction.Commit();
                    return family != null;
                }

                // Si la familia ya estaba cargada en el documento, buscar la referencia existente
                var familyName = Path.GetFileNameWithoutExtension(rfaFilePath);
                var existingFamily = new FilteredElementCollector(document)
                    .OfClass(typeof(Family))
                    .Cast<Family>()
                    .FirstOrDefault(f => f.Name.Equals(familyName, StringComparison.OrdinalIgnoreCase));

                if (existingFamily != null)
                {
                    family = existingFamily;
                    transaction.Commit();
                    return true;
                }

                transaction.RollBack();
                return false;
            }
            catch (Exception ex)
            {
                LoggerService.LogError($"Error al cargar la familia de Revit desde '{rfaFilePath}'", ex);
                if (transaction.GetStatus() == TransactionStatus.Started)
                {
                    transaction.RollBack();
                }
                return false;
            }
        }

        /// <summary>
        /// Intenta cargar un símbolo/tipo específico de familia (.rfa) en el documento destino con WarningSwallower.
        /// </summary>
        public bool TryLoadFamilySymbol(Document document, string rfaFilePath, string symbolName, out FamilySymbol? familySymbol)
        {
            familySymbol = null;
            if (document == null || string.IsNullOrWhiteSpace(rfaFilePath) || !File.Exists(rfaFilePath) || string.IsNullOrWhiteSpace(symbolName))
            {
                return false;
            }

            var overwriteOptions = new SilentOverwriteFamilyOption();

            using var transaction = new Transaction(document, "Cargar Símbolo de Familia TransferPlus");
            WarningSwallower.AttachToTransaction(transaction);
            transaction.Start();

            try
            {
                if (document.LoadFamilySymbol(rfaFilePath, symbolName, overwriteOptions, out familySymbol))
                {
                    if (familySymbol != null && !familySymbol.IsActive)
                    {
                        familySymbol.Activate();
                    }
                    transaction.Commit();
                    return familySymbol != null;
                }

                // Buscar si el símbolo ya existía
                var existingSymbol = new FilteredElementCollector(document)
                    .OfClass(typeof(FamilySymbol))
                    .Cast<FamilySymbol>()
                    .FirstOrDefault(s => s.Name.Equals(symbolName, StringComparison.OrdinalIgnoreCase));

                if (existingSymbol != null)
                {
                    familySymbol = existingSymbol;
                    if (!familySymbol.IsActive)
                    {
                        familySymbol.Activate();
                    }
                    transaction.Commit();
                    return true;
                }

                transaction.RollBack();
                return false;
            }
            catch (Exception ex)
            {
                LoggerService.LogError($"Error al cargar el símbolo '{symbolName}' de la familia '{rfaFilePath}'", ex);
                if (transaction.GetStatus() == TransactionStatus.Started)
                {
                    transaction.RollBack();
                }
                return false;
            }
        }
    }
}
