// ==============================================================================
// SKILL: SKILL-RVT-UX (Advanced UX/UI)
// PATTERN: MVVM View-Model Base
// PURPOSE: Provides the standard INotifyPropertyChanged implementation to 
//          facilitate two-way data binding between XAML components and C# logic.
// DEPENDENCIES: System.ComponentModel, System.Runtime.CompilerServices
// ==============================================================================

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RevitAddinBase.UX
{
    /// <summary>
    /// Base class for all ViewModels powering Revit WPF windows and dockable panes.
    /// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Notifies the WPF UI that a property value has changed and the XAML needs to redraw.
        /// </summary>
        /// <param name="propertyName">Automatically captured by the compiler.</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Safely updates a backing field and triggers the UI notification only if the value changed.
        /// </summary>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="field">Reference to the backing field.</param>
        /// <param name="value">The new value to set.</param>
        /// <param name="propertyName">Automatically captured by the compiler.</param>
        /// <returns>True if the value changed, False if it was the same.</returns>
        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (System.Collections.Generic.EqualityComparer<T>.Default.Equals(field, value))
            {
                return false;
            }

            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}