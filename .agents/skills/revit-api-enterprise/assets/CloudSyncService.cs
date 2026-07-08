// ==============================================================================
// SKILL: revit-api-enterprise (Distributed & Cloud Integrations)
// PATTERN: Asynchronous Singleton REST Syncer
// PURPOSE: Communicates with cloud databases safely from Revit background tasks.
// ==============================================================================

using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RevitAddinBase.Enterprise
{
    public static class CloudSyncService
    {
        // CORRECT: HttpClient is instantiated once and held as a Singleton to prevent Socket Exhaustion.
        private static readonly HttpClient _httpClient = new HttpClient();
        private const string FIREBASE_DB_URL = "https://your-aeco-project.firebaseio.com/audits.json";

        public static async Task SyncAuditAsync(BimAudit data)
        {
            try
            {
                // 1. Serialize C# model to JSON payload
                string jsonPayload = JsonSerializer.Serialize(data);
                var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                // 2. Perform async call (releases Revit's UI thread while awaiting web response)
                HttpResponseMessage response = await _httpClient.PostAsync(FIREBASE_DB_URL, content);

                // 3. Confirm response status
                response.EnsureSuccessStatusCode(); 
            }
            catch (HttpRequestException ex)
            {
                // Log connectivity failure
                System.Diagnostics.Debug.WriteLine($"Cloud Sync Failed: {ex.Message}");
            }
        }
    }

    public class BimAudit
    {
        public string ProjectId { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
