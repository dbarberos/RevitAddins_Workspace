// ==============================================================================
// SKILL: SKILL-RVT-UX (Advanced UX/UI)
// ANTI-PATTERN: Direct Document Access from Thread Context of Web Messaging
// PURPOSE: Demonstrates why direct modifications from WebMessageReceived threads crash.
// ==============================================================================

using Autodesk.Revit.DB;
using Microsoft.Web.WebView2.Core;

namespace RevitAddinBase.UX
{
    public class DirectDocumentAccessAntiPattern
    {
        private Document _doc;

        // FATAL: Attempting to write/read Revit model properties inside message callback threads
        // will crash with a ModificationOutsideTransactionException or general Revit API lock failures.
        private void WebView_MessageReceived(object sender, CoreWebView2WebMessageReceivedEventArgs e)
        {
            using (Transaction t = new Transaction(_doc, "Via Web Access")) // Fatal crash
            {
                t.Start();
                // Model writing code
                t.Commit();
            }
        }
    }
}
