using System;

namespace TransferPlus.Models
{
    /// <summary>
    /// Represents structured information for elements that triggered a duplicate naming conflict during transfer.
    /// </summary>
    public class DuplicateElementInfo
    {
        public string Categoria { get; set; } = "General";
        public string Familia { get; set; } = "Standard";
        public string Clase { get; set; } = "Element";
        public string Nombre { get; set; } = "Undefined";

        public DuplicateElementInfo() { }

        public DuplicateElementInfo(string categoria, string familia, string clase, string nombre)
        {
            Categoria = string.IsNullOrWhiteSpace(categoria) ? "General" : categoria;
            Familia = string.IsNullOrWhiteSpace(familia) ? "Standard" : familia;
            Clase = string.IsNullOrWhiteSpace(clase) ? "Element" : clase;
            Nombre = string.IsNullOrWhiteSpace(nombre) ? "Undefined" : nombre;
        }

        public DuplicateElementInfo(Elemento item, string clase)
        {
            if (item != null)
            {
                Categoria = string.IsNullOrWhiteSpace(item.Categoria) ? "General" : item.Categoria;
                Familia = string.IsNullOrWhiteSpace(item.Familia) ? "Standard" : item.Familia;
                Clase = string.IsNullOrWhiteSpace(clase) ? (item.GetType().Name) : clase;
                Nombre = string.IsNullOrWhiteSpace(item.Nombre) ? "Undefined" : item.Nombre;
            }
        }

        public override string ToString()
        {
            return $"[{Categoria} > {Familia} > {Clase}] {Nombre}";
        }
    }
}
