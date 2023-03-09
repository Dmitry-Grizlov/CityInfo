namespace CityInfo.Extensions
{
    public class ApiResult<T> : ApiResult
    {
        public T Data { get; set; }
    }

    public class ApiResult
    {
        public int StatusCode { get; set; }

        public string Msg { get; set; }
    }
}