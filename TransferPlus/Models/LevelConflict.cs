using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace TransferPlus.Models
{
    public enum LevelMappingAction
    {
        CreateNew,
        MapToExisting
    }

    public partial class LevelConflict : ObservableObject
    {
        private LevelMappingAction _selectedAction = LevelMappingAction.CreateNew;
        private string? _selectedTargetLevelName;

        private string _newLevelName = string.Empty;

        public string SourceLevelName { get; set; } = string.Empty;
        public double SourceElevation { get; set; }
        public string SourceElevationText { get; set; } = string.Empty;

        public string NewLevelName
        {
            get => string.IsNullOrEmpty(_newLevelName) ? SourceLevelName : _newLevelName;
            set => SetProperty(ref _newLevelName, value);
        }

        public List<string> AvailableTargetLevels { get; set; } = new();

        public string? ClosestLowerLevelName { get; set; }
        public string? ClosestUpperLevelName { get; set; }
        public string? ExactMatchLevelName { get; set; }

        public LevelMappingAction SelectedAction
        {
            get => _selectedAction;
            set
            {
                SetProperty(ref _selectedAction, value);
                OnPropertyChanged(nameof(IsMapToExistingEnabled));
                OnPropertyChanged(nameof(IsCreateNew));
                OnPropertyChanged(nameof(IsMapToExisting));
            }
        }

        public bool IsCreateNew
        {
            get => SelectedAction == LevelMappingAction.CreateNew;
            set
            {
                if (value)
                {
                    SelectedAction = LevelMappingAction.CreateNew;
                }
            }
        }

        public bool IsMapToExisting
        {
            get => SelectedAction == LevelMappingAction.MapToExisting;
            set
            {
                if (value)
                {
                    SelectedAction = LevelMappingAction.MapToExisting;
                }
            }
        }

        public string? SelectedTargetLevelName
        {
            get => _selectedTargetLevelName;
            set => SetProperty(ref _selectedTargetLevelName, value);
        }

        public bool IsMapToExistingEnabled => SelectedAction == LevelMappingAction.MapToExisting;

        public bool HasExactMatch => !string.IsNullOrEmpty(ExactMatchLevelName);
        public bool HasClosestLower => !string.IsNullOrEmpty(ClosestLowerLevelName);
        public bool HasClosestUpper => !string.IsNullOrEmpty(ClosestUpperLevelName);

        [RelayCommand]
        private void SelectLevelAndMap(string levelName)
        {
            SelectedTargetLevelName = levelName;
            SelectedAction = LevelMappingAction.MapToExisting;
        }
    }
}
