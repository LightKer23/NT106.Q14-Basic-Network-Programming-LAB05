using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai05
{
    internal class AuthService
    {
        private readonly ApiClient _apiClient;
        public AuthService(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }
        public async Task<ApiResult<UserInfo>> LoginAsync(string username, string password)
        {
            var form = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password),
            });

            var loginResult = await _apiClient.PostFromAsync<AuthTokenResponse>("/auth/token", form);

            if (!loginResult.Success || loginResult.Data == null || string.IsNullOrEmpty(loginResult.Data.access_token))
                return ApiResult<UserInfo>.Fail(loginResult.ErrorMessage ?? "Đăng nhập thất bại");

            _apiClient.SetToken(loginResult.Data.token_type, loginResult.Data.access_token);

            var meResult = await _apiClient.GetAsync<UserInfo>("/api/v1/user/me");
            UserInfo userInfo;

            if (meResult.Success && meResult.Data != null)
            {
                userInfo = meResult.Data;
                userInfo.token = loginResult.Data.access_token;
            }
            else
            {
                userInfo = new UserInfo
                {
                    username = username,
                    token = loginResult.Data.access_token
                };
            }

            CurrentUser.SetUser(userInfo);
            return ApiResult<UserInfo>.Ok(userInfo);
        }

        public Task<ApiResult<UserInfo>> GetMeAsync()
        {
            return _apiClient.GetAsync<UserInfo>("/auth/me");
        }

        public async Task<ApiResult<UserInfo>> RegisterAsync(UserInfo userInfo)
        {
            var payload = new
            {
                username = userInfo.username,
                email = userInfo.email,
                password = userInfo.password,
                first_name = userInfo.first_name,
                last_name = userInfo.last_name,
                sex = userInfo.sex,
                birthday = userInfo.birthday?.ToString("yyyy-MM-dd"),
                language = userInfo.language,
                phone = userInfo.phone
            };

            return await _apiClient.PostJsonAsync<object, UserInfo>("/api/v1/user/signup", payload);
        }
    }
}

public class AuthTokenResponse
{
    public string access_token { get; set; } = string.Empty;
    public string token_type { get; set; } = string.Empty;
}