using System;
using Autodesk.Revit.DB;
using CommunityToolkit.Mvvm.ComponentModel;

namespace TransferPlus.Models
{
    /// <summary>
    /// Modelo de datos para representar Vistas de Diseño (Drafting Views) e Instancias CAD (DWG Links / Imports).
    /// </summary>
    public partial class CadDetailItemModel : ObservableObject
    {
        [ObservableProperty]
        private string _name = string.Empty;

        [ObservableProperty]
        private string _viewName = string.Empty;

        [ObservableProperty]
        private string _sheetName = string.Empty;

        [ObservableProperty]
        private bool _isLinked;

        [ObservableProperty]
        private bool _isDraftingView;

        [ObservableProperty]
        private int _cadCount;

        [ObservableProperty]
        private bool _isChecked;

        [ObservableProperty]
        private string _sourceDocumentName = string.Empty;

        [ObservableProperty]
        private object? _thumbnail;

        [ObservableProperty]
        private bool _isLoadingThumbnail;

        [ObservableProperty]
        private string _category = string.Empty;

        public ElementId? ElementId { get; set; }
        public ElementId? OwnerViewId { get; set; }
        public ElementId? SheetId { get; set; }

        /// <summary>
        /// Referencia opcional al elemento nativo Revit (ViewDrafting o ImportInstance).
        /// </summary>
        public object? NativeElement { get; set; }

        /// <summary>
        /// Referencia opcional al Documento nativo de Revit.
        /// </summary>
        public object? SourceDocument { get; set; }

        public string DisplayCategory => !string.IsNullOrWhiteSpace(Category) ? Category : (IsDraftingView ? "Drafting Views" : (IsLinked ? "CAD Links" : "CAD Imports"));
        public string LocationSummary => !string.IsNullOrWhiteSpace(SheetName) ? $"{ViewName} [Sheet: {SheetName}]" : ViewName;
    }
}
