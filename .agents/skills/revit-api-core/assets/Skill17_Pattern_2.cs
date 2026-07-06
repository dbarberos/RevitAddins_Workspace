// C# (Backend): Enviar estado de vuelta a la UI web
public async void EnviarExitoAWeb(string elementoId)
{
    string scriptJS = $"window.actualizarEstadoUI('Muro Creado', '{elementoId}');";
    await miWebView.CoreWebView2.ExecuteScriptAsync(scriptJS);
}
