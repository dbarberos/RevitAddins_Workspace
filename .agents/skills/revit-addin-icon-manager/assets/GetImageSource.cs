using System;
using System.Reflection;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace RevitAddin.Helpers
{
    public static class ImageResourceLoader
    {
        /// <summary>
        /// Obtiene un ImageSource a partir del nombre de un recurso incrustado en el ensamblado como Resource.
        /// Diseñado específicamente para cumplir con el esquema pack:// de Revit y WPF.
        /// </summary>
        /// <param name="resourceName">Nombre del archivo de imagen (p. ej. "YourIcon32.png")</param>
        /// <returns>ImageSource cargado o null si ocurre un fallo.</returns>
        public static ImageSource GetImageSource(string resourceName)
        {
            try
            {
                // Recuperar dinámicamente el nombre del ensamblado ejecutor en Revit
                string assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
                
                // Formato oficial "pack://application" requerido para inyectar recursos en Revit Ribbon
                Uri uri = new Uri($"pack://application:,,,/{assemblyName};component/Resources/Icons/{resourceName}");
                
                return new BitmapImage(uri);
            }
            catch
            {
                return null;
            }
        }
    }
}
