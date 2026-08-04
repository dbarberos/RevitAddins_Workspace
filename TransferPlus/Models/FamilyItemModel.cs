using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;

namespace TransferPlus.Models
{
    /// <summary>
    /// Representa un tipo/símbolo individual dentro de una familia de Revit.
    /// Contiene solo tipos primitivos para garantizar desacoplamiento total de la API de Revit en la vista.
    /// </summary>
    public partial class FamilySymbolItemModel : ObservableObject
    {
        [ObservableProperty]
        private string _name = string.Empty;

        [ObservableProperty]
        private string _familyName = string.Empty;

        [ObservableProperty]
        private bool _isActive;

        [ObservableProperty]
        private bool _isSelected = true;

        [ObservableProperty]
        private bool _isChecked = true;

        public object? NativeSymbol { get; set; }
    }

    /// <summary>
    /// Modelo de datos para representar una Familia de Revit en la interfaz de usuario.
    /// </summary>
    public partial class FamilyItemModel : ObservableObject
    {
        public string Name { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
        public string SourceName { get; set; } = "Modelo Origen";
        public int SymbolCount => Symbols?.Count ?? 0;
        public bool IsLoaded { get; set; }
        public bool IsSelected { get; set; }
        public string StatusMessage { get; set; } = "Disponible";
        public string ImagePreviewUrl { get; set; } = string.Empty;
        
        public string RevitVersion { get; set; } = string.Empty;
        
        [ObservableProperty]
        private object? _thumbnail;

        [ObservableProperty]
        private bool _isLoadingThumbnail;

        public List<FamilySymbolItemModel> Symbols { get; set; } = new();

        /// <summary>
        /// Referencia opcional al objeto nativo Revit (Autodesk.Revit.DB.Family) cuando proviene de un modelo abierto o vinculado.
        /// </summary>
        public object? NativeFamily { get; set; }

        /// <summary>
        /// Referencia opcional al documento nativo origen (Autodesk.Revit.DB.Document) cuando proviene de un modelo abierto o vinculado.
        /// </summary>
        public object? SourceDocument { get; set; }
    }
}
