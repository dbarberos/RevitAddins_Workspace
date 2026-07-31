using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using TransferPlus.Models;

namespace TransferPlus.ViewModels
{
    /// <summary>
    /// ViewModel para la interfaz del Gestor de Familias (FamilyManagerView).
    /// Diseñado bajo MVVM estricto sin referencias a Autodesk.Revit.DB o Autodesk.Revit.UI.
    /// </summary>
    public class FamilyManagerViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<FamilyItemModel> _allFamilies = new();
        private ObservableCollection<FamilyItemModel> _filteredFamilies = new();
        private FamilyItemModel? _selectedFamily;
        private ObservableCollection<FamilySymbolItemModel> _selectedFamilySymbols = new();
        private string _searchQuery = string.Empty;
        private string _selectedCategory = "Todas las Categorías";
        private ObservableCollection<string> _categories = new();
        private string _statusSummary = "Listo";

        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<FamilyItemModel> Families
        {
            get => _filteredFamilies;
            set
            {
                _filteredFamilies = value;
                OnPropertyChanged();
            }
        }

        public FamilyItemModel? SelectedFamily
        {
            get => _selectedFamily;
            set
            {
                if (_selectedFamily != value)
                {
                    _selectedFamily = value;
                    OnPropertyChanged();
                    UpdateSelectedFamilySymbols();
                }
            }
        }

        public ObservableCollection<FamilySymbolItemModel> SelectedFamilySymbols
        {
            get => _selectedFamilySymbols;
            set
            {
                _selectedFamilySymbols = value;
                OnPropertyChanged();
            }
        }

        public string SearchQuery
        {
            get => _searchQuery;
            set
            {
                if (_searchQuery != value)
                {
                    _searchQuery = value;
                    OnPropertyChanged();
                    ApplyFilter();
                }
            }
        }

        public string SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                if (_selectedCategory != value)
                {
                    _selectedCategory = value;
                    OnPropertyChanged();
                    ApplyFilter();
                }
            }
        }

        public ObservableCollection<string> Categories
        {
            get => _categories;
            set
            {
                _categories = value;
                OnPropertyChanged();
            }
        }

        public string StatusSummary
        {
            get => _statusSummary;
            set
            {
                _statusSummary = value;
                OnPropertyChanged();
            }
        }

        public int TotalFamiliesCount => _allFamilies.Count;
        public int SelectedFamiliesCount => _allFamilies.Count(f => f.IsSelected);

        // Comandos ICommand
        public ICommand LoadCommand { get; }
        public ICommand TransferCommand { get; }
        public ICommand CancelCommand { get; }
        public ICommand SelectAllCommand { get; }
        public ICommand UnselectAllCommand { get; }
        public ICommand RefreshCommand { get; }

        public FamilyManagerViewModel()
        {
            // Inicializar Comandos
            LoadCommand = new RelayCommand(ExecuteLoad, CanExecuteAction);
            TransferCommand = new RelayCommand(ExecuteTransfer, CanExecuteAction);
            CancelCommand = new RelayCommand(ExecuteCancel);
            SelectAllCommand = new RelayCommand(ExecuteSelectAll);
            UnselectAllCommand = new RelayCommand(ExecuteUnselectAll);
            RefreshCommand = new RelayCommand(ExecuteRefresh);

            // Cargar datos falsos (Mock Data) para diseño e iteración independiente
            LoadMockData();
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

            // Poblar categorías únicas
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
            var query = _searchQuery?.Trim().ToLower() ?? string.Empty;
            var cat = _selectedCategory;

            var filtered = _allFamilies.Where(f =>
                (string.IsNullOrEmpty(query) || f.Name.ToLower().Contains(query) || f.CategoryName.ToLower().Contains(query)) &&
                (cat == "Todas las Categorías" || f.CategoryName.Equals(cat, StringComparison.OrdinalIgnoreCase))
            ).ToList();

            Families = new ObservableCollection<FamilyItemModel>(filtered);
            UpdateCounters();
        }

        private void UpdateSelectedFamilySymbols()
        {
            if (SelectedFamily != null && SelectedFamily.Symbols != null)
            {
                SelectedFamilySymbols = new ObservableCollection<FamilySymbolItemModel>(SelectedFamily.Symbols);
            }
            else
            {
                SelectedFamilySymbols = new ObservableCollection<FamilySymbolItemModel>();
            }
        }

        private void UpdateCounters()
        {
            OnPropertyChanged(nameof(TotalFamiliesCount));
            OnPropertyChanged(nameof(SelectedFamiliesCount));
            StatusSummary = $"{SelectedFamiliesCount} familia(s) seleccionada(s) de {TotalFamiliesCount} en lista.";
        }

        public void NotifyFamilySelectionChanged()
        {
            UpdateCounters();
        }

        // --- MÉTODOS DE EJECUCIÓN DE COMANDOS (MODO AISLADO / MOCK) ---

        private bool CanExecuteAction(object? parameter) => true;

        private void ExecuteLoad(object? parameter)
        {
            // TODO: En Fase 4, invocar IFamilyManager.TryLoadFamily() desde el servicio de Revit
            if (SelectedFamily != null)
            {
                SelectedFamily.IsLoaded = true;
                SelectedFamily.StatusMessage = "Cargada en Modelo";
                OnPropertyChanged(nameof(SelectedFamily));
                StatusSummary = $"Familia '{SelectedFamily.Name}' cargada con éxito (Mock).";
            }
        }

        private void ExecuteTransfer(object? parameter)
        {
            // TODO: En Fase 4, llamar a TransferOrchestrator para transferir familias seleccionadas
            var count = SelectedFamiliesCount;
            if (parameter is Window window)
            {
                window.DialogResult = true;
                window.Close();
            }
            else
            {
                StatusSummary = $"Transferencia iniciada para {count} familias (Mock).";
            }
        }

        private void ExecuteCancel(object? parameter)
        {
            // TODO: Cancelar operación y cerrar diálogo
            if (parameter is Window window)
            {
                window.DialogResult = false;
                window.Close();
            }
        }

        private void ExecuteSelectAll(object? parameter)
        {
            foreach (var f in Families)
            {
                f.IsSelected = true;
            }
            UpdateCounters();
            ApplyFilter();
        }

        private void ExecuteUnselectAll(object? parameter)
        {
            foreach (var f in Families)
            {
                f.IsSelected = false;
            }
            UpdateCounters();
            ApplyFilter();
        }

        private void ExecuteRefresh(object? parameter)
        {
            // TODO: Recargar fuentes de familias
            LoadMockData();
            StatusSummary = "Lista de familias actualizada.";
        }

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Implementación de ICommand genérico interno para no depender de librerías externas
        private class RelayCommand : ICommand
        {
            private readonly Action<object?> _execute;
            private readonly Func<object?, bool>? _canExecute;

            public RelayCommand(Action<object?> execute, Func<object?, bool>? canExecute = null)
            {
                _execute = execute ?? throw new ArgumentNullException(nameof(execute));
                _canExecute = canExecute;
            }

            public bool CanExecute(object? parameter) => _canExecute?.Invoke(parameter) ?? true;
            public void Execute(object? parameter) => _execute(parameter);
            public event EventHandler? CanExecuteChanged
            {
                add => CommandManager.RequerySuggested += value;
                remove => CommandManager.RequerySuggested -= value;
            }
        }
    }
}
