using Bai05.Models;

namespace Bai05.Services
{
    internal class FoodService
    {
        private readonly ApiClient _apiClient;
        public FoodService(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public Task<ApiResult<DishListResponse<FoodItem>>> GetAllFoodsAsync(int page, int size)
        {
            var payload = new
            {
                current = page,
                pageSize = size
            };

            return _apiClient.PostJsonAsync<object, DishListResponse<FoodItem>>("/api/v1/monan/all", payload);
        }

        public Task<ApiResult<DishListResponse<FoodItem>>> GetMyFoodsAsync(int page, int size)
        {
            var payload = new
            {
                current = page,
                pageSize = size
            };

            return _apiClient.PostJsonAsync<object, DishListResponse<FoodItem>>("/api/v1/monan/my-dishes", payload);
        }


        public Task<ApiResult<FoodItem>> AddFoodAsync(string name, int price, string? description, string? imageUrl, string? address)
        {
            var payload = new
            {
                ten_mon_an = name,
                gia = price,
                mo_ta = description,
                hinh_anh = imageUrl,
                dia_chi = address
            };

            return _apiClient.PostJsonAsync<object, FoodItem>("/api/v1/monan/add", payload);
        }

        public Task<ApiResult<bool>> DeleteFoodAsync(int id)
        {
            return _apiClient.DeleteAsync($"/api/v1/monan/{id}");
        }

        public async Task<ApiResult<List<FoodItem>>> GetAllFoodsNoPagingAsync(int pageSize = 50)
        {
            var allFoods = new List<FoodItem>();

            var first = await GetAllFoodsAsync(1, pageSize);
            if (!first.Success || first.Data == null)
                return ApiResult<List<FoodItem>>.Fail(first.ErrorMessage ?? "Không tải được dữ liệu cộng đồng.");

            allFoods.AddRange(first.Data.data);

            var pg = first.Data.pagination;
            if (pg == null)
                return ApiResult<List<FoodItem>>.Ok(allFoods);

            int totalPages = (int)Math.Ceiling(pg.total / (double)pg.pageSize);

            for (int p = 2; p <= totalPages; p++)
            {
                var res = await GetAllFoodsAsync(p, pageSize);
                if (!res.Success || res.Data == null)
                    return ApiResult<List<FoodItem>>.Fail(res.ErrorMessage ?? $"Không tải được trang {p}.");

                allFoods.AddRange(res.Data.data);
            }

            return ApiResult<List<FoodItem>>.Ok(allFoods);
        }

        public async Task<ApiResult<List<FoodItem>>> GetMyFoodsNoPagingAsync(int pageSize = 50)
        {
            var allFoods = new List<FoodItem>();

            var first = await GetMyFoodsAsync(1, pageSize);
            if (!first.Success || first.Data == null)
                return ApiResult<List<FoodItem>>.Fail(first.ErrorMessage ?? "Không tải được danh sách cá nhân.");

            allFoods.AddRange(first.Data.data);

            var pg = first.Data.pagination;
            if (pg == null)
                return ApiResult<List<FoodItem>>.Ok(allFoods);

            int totalPages = (int)Math.Ceiling(pg.total / (double)pg.pageSize);

            for (int p = 2; p <= totalPages; p++)
            {
                var res = await GetMyFoodsAsync(p, pageSize);
                if (!res.Success || res.Data == null)
                    return ApiResult<List<FoodItem>>.Fail(res.ErrorMessage ?? $"Không tải được trang {p}.");

                allFoods.AddRange(res.Data.data);
            }

            return ApiResult<List<FoodItem>>.Ok(allFoods);
        }
    }
}



