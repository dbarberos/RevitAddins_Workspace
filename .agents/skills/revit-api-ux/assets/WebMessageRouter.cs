// ==============================================================================
// SKILL: SKILL-RVT-UX (Advanced UX/UI)
// PATTERN: WebView2 Message Routing Handler
// PURPOSE: Safely intercepts browser actions and dispatches External Events.
// ==============================================================================

using System;
using System.Text.Json;
using Microsoft.Web.WebView2.Core;

namespace RevitAddinBase.UX
{
    public class WebMessageRouter
    {
        private dynamic _wallCreationEvent; // From revit-api-core ExternalEventBridge
        private dynamic _wallCreationDataHandler;

        private void InitializeWebView(Microsoft.Web.WebView2.Wpf.WebView2 webView)
        {
            webView.WebMessageReceived += OnWebMessageReceived;
        }

        private void OnWebMessageReceived(object sender, CoreWebView2WebMessageReceivedEventArgs e)
        {
            // 1. Capture JSON payload string
            string jsonPayload = e.TryGetWebMessageAsString();
            
            // 2. Deserialize payload
            WebMessage message = JsonSerializer.Deserialize<WebMessage>(jsonPayload);
            
            // 3. Route the message action safely
            if (message.Action == "CREATE_WALL")
            {
                // CRITICAL: Cannot start a database Transaction directly in WebView2 threads.
                // Instead, queue arguments and trigger the External Event bridge.
                _wallCreationDataHandler.Data = message.Data;
                _wallCreationEvent.Raise();
            }
        }

        public class WebMessage
        {
            public string Action { get; set; }
            public object Data { get; set; }
        }
    }
}
