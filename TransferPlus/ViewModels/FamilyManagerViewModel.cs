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
using TransferPlus.Services.Providers;

namespace TransferPlus.ViewModels
{
    /// <summary>
    /// ViewModel para el Gestor de Familias (FamilyManagerView) basado en C# 12 y CommunityToolkit.Mvvm.
    /// Consume la abstracción IFamilyProvider para cargar y transferir familias independientemente del origen real (Azure, disco, modelo abierto o vínculo).
    /// </summary>
    public partial class FamilyManagerViewModel : ObservableObject
    {
        private readonly Document? _targetDocument;
        private readonly FamilyRevitService _familyRevitService;
        private IFamilyProvider? _currentProvider;
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

        public FamilyManagerViewModel(Document? targetDocument = null, FamilyRevitService? familyRevitService = null, IFamilyProvider? initialProvider = null)
        {
            _targetDocument = targetDocument;
            _familyRevitService = familyRevitService ?? new FamilyRevitService();
            _currentProvider = initialProvider;

            if (_currentProvider != null)
            {
                _ = LoadFromProviderAsync(_currentProvider);
            }
            else
            {
                LoadMockData();
            }
        }

        public async Task LoadFromSourceDisplayAsync(string selectedSourceDisplay)
        {
            if (string.IsNullOrWhiteSpace(selectedSourceDisplay)) return;

            var provider = FamilyProviderFactory.CreateProvider(selectedSourceDisplay, _targetDocument!, _familyRevitService);
            await LoadFromProviderAsync(provider);
        }

        public async Task LoadFromProviderAsync(IFamilyProvider provider)
        {
            _currentProvider = provider;
            StatusSummary = $"Cargando familias desde '{provider.ProviderName}'...";

            try
            {
                var familyItems = await provider.GetFamiliesAsync();
                _allFamilies = new ObservableCollection<FamilyItemModel>(familyItems);

                var catList = new List<string> { "Todas las Categorías" };
                catList.AddRange(_allFamilies.Select(f => f.CategoryName).Distinct().OrderBy(c => c));
                Categories = new ObservableCollection<string>(catList);

                ApplyFilter();

                if (Families.Count > 0)
                {
                    SelectedFamily = Families[0];
                }

                StatusSummary = $"{_allFamilies.Count} familia(s) cargadas desde '{provider.ProviderName}'.";
            }
            catch (Exception ex)
            {
                TelemetryLogger.LogError($"Error al cargar familias con proveedor '{provider.ProviderName}'", ex);
                StatusSummary = $"Error al cargar familias desde '{provider.ProviderName}'.";
            }
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
                        new FamilySymbolItemModel { Name = "2000x1000mm", FamilyName = "M_Escritorio Executive 1800x900", IsActive = false }
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
                        new FamilySymbolItemModel { Name = "1800x2100mm", FamilyName = "Puerta Peatonal 2-Hojas Cristal", IsActive = false }
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

            if (_targetDocument != null && _currentProvider != null)
            {
                StatusSummary = $"Cargando familia '{SelectedFamily.Name}' mediante {_currentProvider.ProviderName}...";

                var famToLoad = SelectedFamily;
                var doc = _targetDocument;
                var provider = _currentProvider;

                bool success = await RevitTask.RunAsync(app =>
                {
                    return provider.TransferFamilyAsync(famToLoad, doc).GetAwaiter().GetResult();
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
                // Modo Aislado / Fallback
                SelectedFamily.IsLoaded = true;
                SelectedFamily.StatusMessage = "Cargada en Modelo";
                OnPropertyChanged(nameof(SelectedFamily));
                StatusSummary = $"Familia '{SelectedFamily.Name}' cargada con éxito.";
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

            if (_targetDocument != null && _currentProvider != null)
            {
                StatusSummary = $"Iniciando transferencia asíncrona de {selectedFamilies.Count} familias con {_currentProvider.ProviderName}...";

                var doc = _targetDocument;
                var provider = _currentProvider;

                int successCount = await RevitTask.RunAsync(app =>
                {
                    int count = 0;
                    foreach (var fam in selectedFamilies)
                    {
                        bool ok = provider.TransferFamilyAsync(fam, doc).GetAwaiter().GetResult();
                        if (ok)
                        {
                            fam.IsLoaded = true;
                            fam.StatusMessage = "Transferida al Modelo";
                            count++;
                        }
                    }
                    return count;
                });

                StatusSummary = $"Transferencia completada: {successCount} de {selectedFamilies.Count} familias transferidas.";
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
        private async Task RefreshAsync(object? parameter)
        {
            if (_currentProvider != null)
            {
                await LoadFromProviderAsync(_currentProvider);
            }
            else
            {
                LoadMockData();
            }
        }
    }
}
