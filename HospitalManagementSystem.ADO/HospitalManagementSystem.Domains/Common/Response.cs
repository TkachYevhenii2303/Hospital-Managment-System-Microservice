namespace HospitalManagementSystem.Domains.Common
{
    public class Response<TEntity>
    {
        public TEntity? Data { get; set; }

        public string Message { get; set; } = string.Empty;

        public bool Success { get; set; } = true;
    }
}
