using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bai05.Models;
namespace Bai05.Services
{
    internal class EmailValidatorService
    {
        private readonly ApiClient _apiClient;

        public EmailValidatorService(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<EmailCheckResult> CheckEmailRegisteredAsync(string email)
        {
            try
            {
                var testPassword = Guid.NewGuid().ToString();

                var form = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("username", email),
                    new KeyValuePair<string, string>("password", testPassword),
                });

                var loginResult = await _apiClient.PostFromAsync<AuthTokenResponse>("/auth/token", form);

                if (!loginResult.Success)
                {
                    var errorMsg = loginResult.ErrorMessage?.ToLower() ?? "";

                    if (errorMsg.Contains("not found") ||
                        errorMsg.Contains("không tìm thấy") ||
                        errorMsg.Contains("does not exist") ||
                        errorMsg.Contains("không tồn tại"))
                    {
                        return new EmailCheckResult
                        {
                            IsRegistered = false,
                            Email = email,
                            Message = "Email chưa đăng ký trong hệ thống"
                        };
                    }

                    if (errorMsg.Contains("password") ||
                        errorMsg.Contains("mật khẩu") ||
                        errorMsg.Contains("incorrect") ||
                        errorMsg.Contains("wrong"))
                    {
                        return new EmailCheckResult
                        {
                            IsRegistered = true,
                            Email = email,
                            Message = "Email đã đăng ký trong hệ thống"
                        };
                    }

                    return new EmailCheckResult
                    {
                        IsRegistered = false,
                        Email = email,
                        Message = $"Không thể xác minh: {loginResult.ErrorMessage}",
                        HasError = true
                    };
                }

                return new EmailCheckResult
                {
                    IsRegistered = true,
                    Email = email,
                    Message = "Email đã đăng ký"
                };
            }
            catch (Exception ex)
            {
                return new EmailCheckResult
                {
                    IsRegistered = false,
                    Email = email,
                    Message = $"Lỗi: {ex.Message}",
                    HasError = true
                };
            }
        }
    }

    public class EmailCheckResult
    {
        public bool IsRegistered { get; set; }
        public string Email { get; set; } = "";
        public string Message { get; set; } = "";
        public bool HasError { get; set; }
    }
}