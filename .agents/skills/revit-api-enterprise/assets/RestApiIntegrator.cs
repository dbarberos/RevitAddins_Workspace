// ==============================================================================
// SKILL: SKILL-RVT-ENT (Enterprise & Cloud Ecosystem)
// PATTERN: Thread-Safe REST API Integrator
// PURPOSE: Handles HTTP GET/POST requests safely without locking the Revit UI thread.
//          Uses a single HttpClient instance to prevent socket exhaustion.
// DEPENDENCIES: System.Net.Http, System.Text.Json, System.Threading.Tasks
// ==============================================================================

using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RevitAddinBase.Enterprise
{
    /// <summary>
    /// Singleton HTTP Client wrapper for external API communication.
    /// </summary>
    public static class RestApiIntegrator
    {
        // Singleton pattern to avoid Socket Exhaustion (Enterprise Best Practice)
        private static readonly HttpClient _httpClient = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(30)
        };

        /// <summary>
        /// Sends a JSON payload to an external REST API via POST asynchronously.
        /// </summary>
        /// <param name="endpointUrl">The destination URL.</param>
        /// <param name="jsonPayload">The serialized JSON string.</param>
        /// <param name="bearerToken">Optional authentication token.</param>
        /// <returns>The server's response content, or an error message.</returns>
        public static async Task<string> PostDataAsync(string endpointUrl, string jsonPayload, string bearerToken = null)
        {
            if (string.IsNullOrWhiteSpace(endpointUrl) || string.IsNullOrWhiteSpace(jsonPayload))
                return null;

            try
            {
                using (var request = new HttpRequestMessage(HttpMethod.Post, endpointUrl))
                {
                    request.Content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                    if (!string.IsNullOrWhiteSpace(bearerToken))
                    {
                        request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", bearerToken);
                    }

                    // Await the response without locking the Revit Main Thread
                    using (var response = await _httpClient.SendAsync(request))
                    {
                        response.EnsureSuccessStatusCode();
                        return await response.Content.ReadAsStringAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[REST API] POST Failed: {ex.Message}");
                return $"Error: {ex.Message}";
            }
        }
    }
}