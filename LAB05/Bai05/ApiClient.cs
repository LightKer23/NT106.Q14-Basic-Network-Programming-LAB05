using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Bai05
{
    internal class ApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;
        public ApiClient()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://nt106.uitiot.vn");
            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public void SetToken(string tokenType, string accessToken)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(tokenType, accessToken);
        }

        public void ClearToken()
        {
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }


        #region Helpers

        public async Task<ApiResult<T>> PostFromAsync<T>(string url, FormUrlEncodedContent content)
        {
            try
            {
                var resp = await _httpClient.PostAsync(url, content);
                var body = await resp.Content.ReadAsStringAsync();

                if (!resp.IsSuccessStatusCode)
                    return ApiResult<T>.Fail(body);

                var data = JsonSerializer.Deserialize<T>(body, _jsonOptions);
                return ApiResult<T>.Ok(data!);
            }
            catch (Exception ex)
            {
                return ApiResult<T>.Fail(ex.Message);
            }
        }

        public async Task<ApiResult<T>> GetAsync<T>(string url)
        {
            try
            {
                var resp = await _httpClient.GetAsync(url);
                var body = await resp.Content.ReadAsStringAsync();

                if (!resp.IsSuccessStatusCode)
                    return ApiResult<T>.Fail(ParseErrorMessage(body));

                var data = JsonSerializer.Deserialize<T>(body, _jsonOptions);
                return ApiResult<T>.Ok(data!);
            }
            catch (Exception ex)
            {
                return ApiResult<T>.Fail(ex.Message);
            }
        }

        public async Task<ApiResult<TRes>> PostJsonAsync<TReq, TRes>(string url, TReq payload)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine($"POST {url}");

                var json = JsonSerializer.Serialize(payload);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var request = new HttpRequestMessage(HttpMethod.Post, url)
                {
                    Content = content
                };

                if (!url.Contains("/auth/token") && !url.Contains("/auth/refresh") && CurrentUser.IsLoggedIn && !string.IsNullOrEmpty(CurrentUser.User?.token))
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", CurrentUser.User.token);

                var resp = await _httpClient.SendAsync(request);
                var body = await resp.Content.ReadAsStringAsync();

                if (!resp.IsSuccessStatusCode)
                    return ApiResult<TRes>.Fail($"Lỗi {resp.StatusCode}: {body}");

                try
                {
                    var data = JsonSerializer.Deserialize<TRes>(body, _jsonOptions);
                    return ApiResult<TRes>.Ok(data!);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(body, "JSON Response");
                    return ApiResult<TRes>.Fail("Lỗi parse JSON: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                return ApiResult<TRes>.Fail(ex.Message);
            }
        }

        public async Task<ApiResult<bool>> DeleteAsync(string url)
        {
            try
            {
                var resp = await _httpClient.DeleteAsync(url);
                var body = await resp.Content.ReadAsStringAsync();
                if (!resp.IsSuccessStatusCode)
                    return ApiResult<bool>.Fail(body);
                return ApiResult<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                return ApiResult<bool>.Fail(ex.Message);
            }
        }

        private string ParseErrorMessage(string responseBody)
        {
            try
            {
                using var doc = JsonDocument.Parse(responseBody);
                if (doc.RootElement.TryGetProperty("error", out var errorElement))
                {
                    return errorElement.GetString() ?? "Unknown error";
                }
            }
            catch
            {
            }
            return "Unknown error";
        }
        #endregion
    }
}

public class ApiResult<T>
{
    public bool Success { get; set; }
    public string? ErrorMessage { get; set; } = string.Empty;
    public T? Data { get; set; }
    public static ApiResult<T> Ok(T data) => new ApiResult<T> { Success = true, Data = data };
    public static ApiResult<T> Fail(string errorMessage) => new ApiResult<T> { Success = false, ErrorMessage = errorMessage };
}

public class UserInfo
{
    public string username { get; set; } = string.Empty;
    public string email { get; set; } = string.Empty;
    public string password { get; set; } = string.Empty;
    public string? first_name { get; set; } = string.Empty;
    public string? last_name { get; set; } = string.Empty;
    public int sex { get; set; }
    public DateTime? birthday { get; set; }
    public string? language { get; set; } = string.Empty;
    public string? phone { get; set; } = string.Empty;

    [JsonIgnore]
    public string? token { get; set; } = string.Empty;
}

public class CurrentUser
{
    public static UserInfo? User { get; private set; }
    public static bool IsLoggedIn => User != null;
    public static void SetUser(UserInfo user) => User = user;
    public static void ClearUser() => User = null;
}