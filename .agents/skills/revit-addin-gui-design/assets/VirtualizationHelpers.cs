using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace VirtualizationHelpers
{
    public static class Diagnostics
    {
        /// <summary>
        /// Checks if virtualization is actively functioning on an ItemsControl.
        /// </summary>
        public static bool IsVirtualizing(ItemsControl control)
        {
            var panel = FindVisualChild<VirtualizingStackPanel>(control);
            return panel != null && VirtualizingPanel.GetIsVirtualizing(control);
        }

        /// <summary>
        /// Gets the count of actual UI containers instantiated in memory.
        /// Useful for proving that virtualization is working (realized count << total items).
        /// </summary>
        public static int GetRealizedCount(ItemsControl control)
        {
            var generator = control.ItemContainerGenerator;
            return Enumerable.Range(0, control.Items.Count)
                .Count(i => generator.ContainerFromIndex(i) != null);
        }

        private static T FindVisualChild<T>(DependencyObject parent) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                if (child is T typedChild)
                    return typedChild;

                var result = FindVisualChild<T>(child);
                if (result != null)
                    return result;
            }
            return null;
        }
    }
}
