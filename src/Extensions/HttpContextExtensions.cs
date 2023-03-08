namespace CityInfo.Extensions{
    public static class  HttpContextExtensions{
        public static string GetIpAddress(this HttpContext context) => context.Request.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
    }
}