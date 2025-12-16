using Bai05.Models;
using Bai05.Utils;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Bai05.Services
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

                if (!url.Contains("/auth/token") &&
                    !url.Contains("/auth/refresh") &&
                    !url.Contains("/signup") &&
                    CurrentUser.IsLoggedIn &&
                    CurrentUser.User != null &&
                    !string.IsNullOrEmpty(CurrentUser.User.token))
                {
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", CurrentUser.User.token);
                }

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
                return ApiResult<TRes>.Fail($"Lỗi kết nối: {ex.Message}");
            }
        }

        public async Task<ApiResult<bool>> DeleteAsync(string url)
        {
            try
            {
                var req = new HttpRequestMessage(HttpMethod.Delete, url);

                if (CurrentUser.IsLoggedIn && !string.IsNullOrWhiteSpace(CurrentUser.User?.token))
                    req.Headers.Authorization = new AuthenticationHeaderValue("Bearer", CurrentUser.User.token);

                var resp = await _httpClient.SendAsync(req);
                var body = await resp.Content.ReadAsStringAsync();

                if (!resp.IsSuccessStatusCode)
                    return ApiResult<bool>.Fail($"Lỗi {resp.StatusCode}: {body}");

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