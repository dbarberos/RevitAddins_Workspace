// ==============================================================================
// SKILL: SKILL-RVT-UX (Advanced UX/UI)
// PATTERN: Dispatch Script execution back to Web UI
// PURPOSE: Notifies the browser client of Revit transaction success.
// ==============================================================================

using System;
using System.Threading.Tasks;
using Microsoft.Web.WebView2.Wpf;

namespace RevitAddinBase.UX
{
    public class WebMessageResponseSender
    {
        private WebView2 _webView;

        public async Task SendSuccessToWeb(string elementId)
        {
            if (_webView?.CoreWebView2 != null)
            {
                string jsScript = $"window.updateUiState('Wall Created', '{elementId}');";
                await _webView.CoreWebView2.ExecuteScriptAsync(jsScript);
            }
        }
    }
}
