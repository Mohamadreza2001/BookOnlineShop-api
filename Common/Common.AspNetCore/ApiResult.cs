namespace Common.AspNetCore
{
    public class ApiResult
    {
        public bool IsSuccess { get; set; }
        public MetaData MetaData { get; set; }
    }

    public class ApiResult<TData>
    {
        public TData Data { get; set; }
        public bool IsSuccess { get; set; }
        public MetaData MetaData { get; set; }
    }
}
