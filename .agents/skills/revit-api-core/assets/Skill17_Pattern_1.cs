// C# (WPF Backend): Suscripción al evento del navegador
private void InicializarWebView()
{
    miWebView.WebMessageReceived += AlRecibirMensajeWeb;
}

private void AlRecibirMensajeWeb(object sender, CoreWebView2WebMessageReceivedEventArgs e)
{
    // 1. Capturar el string JSON
    string jsonPayload = e.TryGetWebMessageAsString();
    
    // 2. Deserializar
    WebMessage mensaje = JsonSerializer.Deserialize<WebMessage>(jsonPayload);
    
    // 3. Enrutamiento del comando
    if (mensaje.Action == "CREATE_WALL")
    {
        // NO SE PUEDE INICIAR TRANSACCIÓN AQUÍ.
        // Se inyectan los datos en el manejador asíncrono y se dispara a Revit.
        _manejadorMuros.Datos = mensaje.Data;
        _eventoExternoCrearMuros.Raise();
    }
}
