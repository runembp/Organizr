#pragma warning disable CS8604

using System.Text;
using Newtonsoft.Json;

namespace Organizr.Admin.Data.HelperClasses;

public static class HttpClientHelperClass
{
    public static Task<HttpResponseMessage> DeleteAsJsonAsync(this HttpClient httpClient, string requestUri)
       => httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Delete, requestUri));

    public static Task<HttpResponseMessage> DeleteAsJsonAsync<T>(this HttpClient httpClient, string requestUri, T data)
        => httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Delete, requestUri) { Content = Serialize(data) });

    public static Task<HttpResponseMessage> PatchAsJsonAsync(this HttpClient httpClient, string requestUri)
        => httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Patch, requestUri));

    public static Task<HttpResponseMessage> PatchAsJsonAsync<T>(this HttpClient httpClient, string requestUri, T data)
        => httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Patch, requestUri) { Content = Serialize(data) });

    private static HttpContent Serialize(object data) => new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
}