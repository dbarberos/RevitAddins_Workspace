// FATAL 1: Instanciar HttpClient en un bloque using dentro de un bucle agota los sockets del OS.
using (HttpClient client = new HttpClient()) 
{
    // FATAL 2: Usar .Result o .Wait() bloquea el hilo principal de Revit (Deadlock inminente)
    var respuesta = client.PostAsync(url, content).Result; 
}
