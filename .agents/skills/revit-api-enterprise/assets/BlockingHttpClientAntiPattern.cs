// ==============================================================================
// SKILL: revit-api-enterprise (Distributed & Cloud Integrations)
// ANTI-PATTERN: Synchronous Task Blocking & Socket Exhaustion
// PURPOSE: Explains why task blocking in Revit's UI thread causes Deadlocks.
// ==============================================================================

using System;
using System.Net.Http;

namespace RevitAddinBase.Enterprise
{
    public class BlockingHttpClientAntiPattern
    {
        public void ExecuteBlockingPost(string url, HttpContent content)
        {
            // FATAL 1: Instantiating HttpClient inside a using block inside loops exhausts OS ports.
            using (HttpClient client = new HttpClient()) 
            {
                // FATAL 2: Accessing .Result or calling .Wait() blocks Revit's main thread (leads to immediate Deadlocks).
                var response = client.PostAsync(url, content).Result; 
            }
        }
    }
}
