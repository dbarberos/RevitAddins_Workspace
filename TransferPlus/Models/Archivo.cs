using System;
using Autodesk.Revit.DB;
using CommunityToolkit.Mvvm.ComponentModel;

namespace TransferPlus.Models
{
	public class Archivo : ObservableObject
	{
		public Archivo(Document e)
		{
			this._adoc = e;
			this._nombre = e.Title;
			this._checked = false;
		}

		private string _nombre = string.Empty;
		public string Nombre
		{
			get => _nombre;
			set => SetProperty(ref _nombre, value);
		}

		private Document _adoc;
		public Document Adoc
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

		public Action? OnCheckedPropertyChanged { get; set; }
	}
}
