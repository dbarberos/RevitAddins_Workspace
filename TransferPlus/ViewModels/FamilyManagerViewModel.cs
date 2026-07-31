using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Autodesk.Revit.DB;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TransferPlus.Models;
using TransferPlus.Services;

namespace TransferPlus.ViewModels
{
    /// <summary>
    /// ViewModel para el Gestor de Familias (FamilyManagerView) basado en C# 12 y CommunityToolkit.Mvvm.
    /// Soporta ejecución asíncrona en el hilo principal de Revit mediante el patrón RevitTask/ExternalExecutor
    /// y transacciones seguras con supresor de advertencias WarningSwallower.
    /// </summary>
    public partial class FamilyManagerViewModel : ObservableObject
    {
        private readonly Document? _targetDocument;
        private readonly FamilyRevitService _familyRevitService;
        private ObservableCollection<FamilyItemModel> _allFamilies = [];

        [ObservableProperty]
        private ObservableCollection<FamilyItemModel> _families = [];

        [ObservableProperty]
        private FamilyItemModel? _selectedFamily;

        [ObservableProperty]
        private ObservableCollection<FamilySymbolItemModel> _selectedFamilySymbols = [];

        [ObservableProperty]
        private string _searchQuery = string.Empty;

        [ObservableProperty]
        private string _selectedCategory = "Todas las Categorías";

        [ObservableProperty]
        private ObservableCollection<string> _categories = [];

        [ObservableProperty]
        private string _statusSummary = "Listo";

        public int TotalFamiliesCount => _allFamilies.Count;
        public int SelectedFamiliesCount => _allFamilies.Count(f => f.IsSelected);

        public FamilyManagerViewModel(Document? targetDocument = null, FamilyRevitService? familyRevitService = null)
        {
            _targetDocument = targetDocument;
            _familyRevitService = familyRevitService ?? new FamilyRevitService();
            LoadMockData();
        }

        partial void OnSelectedFamilyChanged(FamilyItemModel? value)
        {
            UpdateSelectedFamilySymbols();
        }

        partial void OnSearchQueryChanged(string value)
        {
            ApplyFilter();
        }

        partial void OnSelectedCategoryChanged(string value)
        {
            ApplyFilter();
        }

        private void LoadMockData()
        {
            _allFamilies = new ObservableCollection<FamilyItemModel>
            {
                new FamilyItemModel
                {
                    Name = "M_Escritorio Executive 1800x900",
                    CategoryName = "Mobiliario",
                    SourceName = "Modelo Origen",
                    IsLoaded = true,
                    IsSelected = true,
                    StatusMessage = "En Modelo Origen",
                    Symbols = new List<FamilySymbolItemModel>
                    {
                        new FamilySymbolItemModel { Name = "1800x900mm", FamilyName = "M_Escritorio Executive 1800x900", IsActive = true },
                        new FamilySymbolItemModel { Name = "1600x800mm", FamilyName = "M_Escritorio Executive 1800x900", IsActive = false },
                        new FamilySymbolItemModel { Name = "2000x1000mm", FamilyName = "M_Escritorio Executive 1800x900", IsActive = false },
                        new FamilySymbolItemModel { Name = "L-Shape 2100x1800mm", FamilyName = "M_Escritorio Executive 1800x900", IsActive = false }
                    }
                },
                new FamilyItemModel
                {
                    Name = "Puerta Peatonal 2-Hojas Cristal",
                    CategoryName = "Puertas",
                    SourceName = "Biblioteca Local",
                    IsLoaded = false,
                    IsSelected = true,
                    StatusMessage = "Disponible en Biblioteca",
                    Symbols = new List<FamilySymbolItemModel>
                    {
                        new FamilySymbolItemModel { Name = "1600x2100mm", FamilyName = "Puerta Peatonal 2-Hojas Cristal", IsActive = true },
                        new FamilySymbolItemModel { Name = "1800x2100mm", FamilyName = "Puerta Peatonal 2-Hojas Cristal", IsActive = false },
                        new FamilySymbolItemModel { Name = "2000x2200mm", FamilyName = "Puerta Peatonal 2-Hojas Cristal", IsActive = false }
                    }
                },
                new FamilyItemModel
                {
                    Name = "Unidad Tratamiento Aire AHU-04",
                    CategoryName = "Equipos Mecánicos",
                    SourceName = "Modelo Origen",
                    IsLoaded = true,
                    IsSelected = true,
                    StatusMessage = "En Modelo Origen",
                    Symbols = new List<FamilySymbolItemModel>
                    {
                        new FamilySymbolItemModel { Name = "AHU-04-A (5000 m3/h)", FamilyName = "Unidad Tratamiento Aire AHU-04", IsActive = true },
                        new FamilySymbolItemModel { Name = "AHU-04-B (7500 m3/h)", FamilyName = "Unidad Tratamiento Aire AHU-04", IsActive = false }
                    }
                },
                new FamilyItemModel
                {
                    Name = "Luminaria Empotrada LED 600x600",
                    CategoryName = "Equipos Eléctricos",
                    SourceName = "Modelo Origen",
                    IsLoaded = true,
                    IsSelected = false,
                    StatusMessage = "En Modelo Origen",
                    Symbols = new List<FamilySymbolItemModel>
                    {
                        new FamilySymbolItemModel { Name = "40W 4000K", FamilyName = "Luminaria Empotrada LED 600x600", IsActive = true },
                        new FamilySymbolItemModel { Name = "50W 4000K DALI", FamilyName = "Luminaria Empotrada LED 600x600", IsActive = false },
                        new FamilySymbolItemModel { Name = "30W 3000K", FamilyName = "Luminaria Empotrada LED 600x600", IsActive = false }
                    }
                },
                new FamilyItemModel
                {
                    Name = "Pilar Estructural HEB 300",
                    CategoryName = "Armazón Estructural",
                    SourceName = "Biblioteca Local",
                    IsLoaded = false,
                    IsSelected = false,
                    StatusMessage = "Disponible en Biblioteca",
                    Symbols = new List<FamilySymbolItemModel>
                    {
                        new FamilySymbolItemModel { Name = "HEB 260", FamilyName = "Pilar Estructural HEB 300", IsActive = false },
                        new FamilySymbolItemModel { Name = "HEB 300", FamilyName = "Pilar Estructural HEB 300", IsActive = true },
                        new FamilySymbolItemModel { Name = "HEB 340", FamilyName = "Pilar Estructural HEB 300", IsActive = false },
                        new FamilySymbolItemModel { Name = "HEB 400", FamilyName = "Pilar Estructural HEB 300", IsActive = false }
                    }
                },
                new FamilyItemModel
                {
                    Name = "Ventana Corredera Aluminio 2H",
                    CategoryName = "Ventanas",
                    SourceName = "Modelo Origen",
                    IsLoaded = true,
                    IsSelected = true,
                    StatusMessage = "En Modelo Origen",
                    Symbols = new List<FamilySymbolItemModel>
                    {
                        new FamilySymbolItemModel { Name = "1200x1400mm", FamilyName = "Ventana Corredera Aluminio 2H", IsActive = true },
                        new FamilySymbolItemModel { Name = "1500x1400mm", FamilyName = "Ventana Corredera Aluminio 2H", IsActive = false },
                        new FamilySymbolItemModel { Name = "1800x1500mm", FamilyName = "Ventana Corredera Aluminio 2H", IsActive = false }
                    }
                }
            };

            var catList = new List<string> { "Todas las Categorías" };
            catList.AddRange(_allFamilies.Select(f => f.CategoryName).Distinct().OrderBy(c => c));
            Categories = new ObservableCollection<string>(catList);

            ApplyFilter();

            if (Families.Count > 0)
            {
                SelectedFamily = Families[0];
            }
        }

        private void ApplyFilter()
        {
            var query = SearchQuery?.Trim().ToLower() ?? string.Empty;
            var cat = SelectedCategory;

            var filtered = _allFamilies.Where(f =>
                (string.IsNullOrEmpty(query) || f.Name.ToLower().Contains(query) || f.CategoryName.ToLower().Contains(query)) &&
                (cat == "Todas las Categorías" || f.CategoryName.Equals(cat, StringComparison.OrdinalIgnoreCase))
            ).ToList();

            Families = new ObservableCollection<FamilyItemModel>(filtered);
            UpdateCounters();
        }

        private void UpdateSelectedFamilySymbols()
        {
            if (SelectedFamily?.Symbols != null)
            {
                SelectedFamilySymbols = new ObservableCollection<FamilySymbolItemModel>(SelectedFamily.Symbols);
            }
            else
            {
                SelectedFamilySymbols = [];
            }
        }

        private void UpdateCounters()
        {
            OnPropertyChanged(nameof(TotalFamiliesCount));
            OnPropertyChanged(nameof(SelectedFamiliesCount));
            StatusSummary = $"{SelectedFamiliesCount} familia(s) seleccionada(s) de {TotalFamiliesCount} en lista.";
        }

        [RelayCommand]
        private async Task LoadAsync(object? parameter)
        {
            if (SelectedFamily == null) return;

            if (_targetDocument != null)
            {
                StatusSummary = $"Cargando familia '{SelectedFamily.Name}' mediante RevitTask...";

                bool success = await RevitTask.RunAsync(app =>
                {
                    return _familyRevitService.TryLoadFamily(_targetDocument, SelectedFamily.ImagePreviewUrl, out _);
                });

                if (success)
                {
                    SelectedFamily.IsLoaded = true;
                    SelectedFamily.StatusMessage = "Cargada en Modelo";
                    OnPropertyChanged(nameof(SelectedFamily));
                    StatusSummary = $"Familia '{SelectedFamily.Name}' cargada con éxito en el modelo de Revit.";
                }
                else
                {
                    StatusSummary = $"No se pudo cargar la familia '{SelectedFamily.Name}'.";
                }
            }
            else
            {
                // Modo Aislado / Mock Data
                SelectedFamily.IsLoaded = true;
                SelectedFamily.StatusMessage = "Cargada en Modelo";
                OnPropertyChanged(nameof(SelectedFamily));
                StatusSummary = $"Familia '{SelectedFamily.Name}' cargada con éxito (Mock).";
            }
        }

        [RelayCommand]
        private async Task TransferAsync(object? parameter)
        {
            var selectedFamilies = Families.Where(f => f.IsSelected).ToList();
            if (selectedFamilies.Count == 0)
            {
                StatusSummary = "No hay familias seleccionadas para transferir.";
                return;
            }

            if (_targetDocument != null)
            {
                StatusSummary = $"Iniciando transferencia asíncrona de {selectedFamilies.Count} familias con WarningSwallower...";

                int successCount = 0;
                await RevitTask.RunAsync(app =>
                {
                    foreach (var fam in selectedFamilies)
                    {
                        if (_familyRevitService.TryLoadFamily(_targetDocument, fam.ImagePreviewUrl, out _))
                        {
                            fam.IsLoaded = true;
                            fam.StatusMessage = "Transferida al Modelo";
                            successCount++;
                        }
                    }
                });

                StatusSummary = $"Transferencia completada: {successCount} de {selectedFamilies.Count} familias transferidas sin advertencias modales.";
            }
            else
            {
                StatusSummary = $"Transferencia ejecutada para {selectedFamilies.Count} familias (Mock).";
            }

            if (parameter is Window window)
            {
                window.DialogResult = true;
                window.Close();
            }
        }

        [RelayCommand]
        private void Cancel(object? parameter)
        {
            if (parameter is Window window)
            {
                window.DialogResult = false;
                window.Close();
            }
        }

        [RelayCommand]
        private void SelectAll(object? parameter)
        {
            foreach (var f in Families)
            {
                f.IsSelected = true;
            }
            UpdateCounters();
            ApplyFilter();
        }

        [RelayCommand]
        private void UnselectAll(object? parameter)
        {
            foreach (var f in Families)
            {
                f.IsSelected = false;
            }
            UpdateCounters();
            ApplyFilter();
        }

        [RelayCommand]
        private void Refresh(object? parameter)
        {
            LoadMockData();
            StatusSummary = "Lista de familias actualizada.";
        }
    }
}
