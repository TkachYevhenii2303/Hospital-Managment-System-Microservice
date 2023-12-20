using HospitalManagementSystem.Shared.Response.Interfaces;

namespace HospitalManagementSystem.Shared.Response
{
    public class Response<TData> : IResponse<TData>
    {
        public TData? Data { get; set; }

        public string Message { get; set; } = string.Empty;

        public bool Succeeded { get; set; } = true;

        public int StatusCode { get; set; }

        public static Response<TData> Success(TData data)
        {
            return new Response<TData>()
            {
                Succeeded = true,
                Data = data
            };
        }

        public static Response<TData> Success(TData data, string message)
        {
            return new Response<TData>()
            {
                Succeeded = true,
                Data = data,
                Message = message,
                StatusCode = 200
            };
        }

        public static Task<Response<TData>> SuccessAsync(TData data, string message)
        {
            return Task.FromResult(Success(data, message));
        }

        public static Task<Response<TData>> SuccessAsync(TData data)
        {
            return Task.FromResult(Success(data));
        }
    }
}
