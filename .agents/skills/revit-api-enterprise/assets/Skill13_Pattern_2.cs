using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

public static class CloudSyncService
{
    // CORRECTO: HttpClient debe ser un Singleton durante toda la vida útil del Add-in
    // para evitar el agotamiento de puertos (Socket Exhaustion).
    private static readonly HttpClient _httpClient = new HttpClient();
    private const string FIREBASE_DB_URL = "[https://tu-proyecto-aeco.firebaseio.com/auditorias.json](https://tu-proyecto-aeco.firebaseio.com/auditorias.json)";

    public static async Task SincronizarAuditoriaAsync(AuditoriaBim data)
    {
        try
        {
            // 1. Serialización del objeto C# a JSON
            string jsonPayload = JsonSerializer.Serialize(data);
            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            // 2. Llamada asíncrona (Libera el hilo principal de Revit mientras espera la red)
            HttpResponseMessage response = await _httpClient.PostAsync(FIREBASE_DB_URL, content);

            // 3. Validación de respuesta
            response.EnsureSuccessStatusCode(); 
        }
        catch (HttpRequestException ex)
        {
            // Logging del error de conectividad
            System.Diagnostics.Debug.WriteLine($"Fallo de sincronización Cloud: {ex.Message}");
        }
    }
}
