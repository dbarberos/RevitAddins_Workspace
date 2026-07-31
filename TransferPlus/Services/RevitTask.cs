using System;
using System.Threading.Tasks;
using Autodesk.Revit.UI;

namespace TransferPlus.Services
{
    /// <summary>
    /// Encapsula el patrón RevitTask para coordinar de forma asíncrona operaciones en el hilo principal
    /// de Revit desde ViewModels modeless o ventanas de WPF sin bloquear el hilo secundario de la UI.
    /// </summary>
    public static class RevitTask
    {
        private class RevitTaskEventHandler : IExternalEventHandler
        {
            private Action<UIApplication>? _currentAction;
            private TaskCompletionSource<object?>? _tcs;

            public void Execute(UIApplication app)
            {
                try
                {
                    _currentAction?.Invoke(app);
                    _tcs?.TrySetResult(null);
                }
                catch (Exception ex)
                {
                    _tcs?.TrySetException(ex);
                }
            }

            public string GetName() => "TransferPlus RevitTask Handler";

            public Task RunAsync(Action<UIApplication> action, ExternalEvent externalEvent)
            {
                _currentAction = action;
                _tcs = new TaskCompletionSource<object?>();
                externalEvent.Raise();
                return _tcs.Task;
            }
        }

        private static readonly RevitTaskEventHandler _handler = new();
        private static readonly ExternalEvent _externalEvent = ExternalEvent.Create(_handler);

        /// <summary>
        /// Ejecuta una acción que modifica el documento en el hilo principal de Revit.
        /// </summary>
        public static Task RunAsync(Action<UIApplication> action)
        {
            return _handler.RunAsync(action, _externalEvent);
        }

        /// <summary>
        /// Ejecuta una función que devuelve un valor en el hilo principal de Revit.
        /// </summary>
        public static async Task<T> RunAsync<T>(Func<UIApplication, T> func)
        {
            T result = default!;
            await _handler.RunAsync(app =>
            {
                result = func(app);
            }, _externalEvent);
            return result;
        }
    }
}
