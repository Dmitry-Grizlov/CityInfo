using System.Text;
using System.Net;

namespace CityInfo.Extensions
{
    public class AppRequest<T>
    {
        public const string GetMethod = "GET";
        public const string PostMethod = "POST";
        public const string UserAgent = @"Mozilla/5.0 (Windows; Windows NT 6.1) AppleWebKit/534.23 (KHTML, like Gecko) Chrome/11.0.686.3 Safari/534.23";

        public static async Task<T> Send(string url, string method = "GET", string body = null, string userAgent = UserAgent, string contentType = "application/x-www-form-urlencoded")
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.UserAgent = userAgent;
            request.KeepAlive = false;
            request.Method = method;

            if (!string.IsNullOrEmpty(body))
            {
                byte[] postBytes = Encoding.UTF8.GetBytes(body);
                request.ContentType = contentType;
                request.ContentLength = postBytes.Length;

                var requestStream = await request.GetRequestStreamAsync();
                requestStream.Write(postBytes, 0, postBytes.Length);
                requestStream.Close();
            }

            var response = (HttpWebResponse)await request.GetResponseAsync();
            var sr = new StreamReader(response.GetResponseStream());
            var resultString = sr.ReadToEnd();
            var result = JsonConvert.DeserializeObject<T>(resultString);
            return result;
        }
    }
}