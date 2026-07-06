// FATAL: Intentar leer o escribir en el Documento de Revit directamente al recibir un mensaje web.
// Lanzará 'ModificationOutsideTransactionException' o un error de contexto de API.
private void WebView_MessageReceived(object sender, CoreWebView2WebMessageReceivedEventArgs e)
{
    Transaction t = new Transaction(_doc, "Desde Web"); // CRASH inminente
    t.Start();
}
