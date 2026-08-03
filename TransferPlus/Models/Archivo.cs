using System;
using Autodesk.Revit.DB;
using CommunityToolkit.Mvvm.ComponentModel;

namespace TransferPlus.Models
{
    public class Archivo : ObservableObject
    {
        public Archivo()
        {
            this._adoc = null!;
            this._nombre = string.Empty;
            this._checked = false;
        }

        public Archivo(Document e)
        {
            this._adoc = e;
            this._nombre = e?.Title ?? string.Empty;
            this._checked = false;
        }

        public Archivo(string nombre, bool isFamilySource = false)
        {
            this._adoc = null!;
            this._nombre = nombre;
            this._checked = false;
            this._esFamilySource = isFamilySource;
        }

        private string _nombre = string.Empty;
        public string Nombre
        {
            get => _nombre;
            set => SetProperty(ref _nombre, value);
        }

        private Document? _adoc;
        public Document? Adoc
        {
            get => _adoc;
            set => SetProperty(ref _adoc, value);
        }

        private bool _checked;
        public bool Checked
        {
            get => _checked;
            set
            {
                if (SetProperty(ref _checked, value))
                {
                    OnCheckedPropertyChanged?.Invoke();
                }
            }
        }

        private bool _esVinculo;
        public bool EsVinculo
        {
            get => _esVinculo;
            set => SetProperty(ref _esVinculo, value);
        }

        private bool _esFamilySource;
        public bool EsFamilySource
        {
            get => _esFamilySource;
            set => SetProperty(ref _esFamilySource, value);
        }

        public Action? OnCheckedPropertyChanged { get; set; }
    }
}
