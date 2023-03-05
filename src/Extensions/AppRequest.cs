using System.Text;
using System.Net;

namespace CityInfo.Extensions
{
    /// <summary>
    /// A simple basic class for HTTP Requests.
    /// </summary>
    public class AppRequest
    {
        /// <summary>
        /// UserAgent to be used on the requests
        /// </summary>
        public string UserAgent = @"Mozilla/5.0 (Windows; Windows NT 6.1) AppleWebKit/534.23 (KHTML, like Gecko) Chrome/11.0.686.3 Safari/534.23";

        /// <summary>
        /// Cookie Container that will handle all the cookies.
        /// </summary>
        private CookieContainer cJar;

        /// <summary>
        /// Performs a basic HTTP GET request.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <returns>HTML Content of the response.</returns>
        public async Task<string> Get(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.CookieContainer = cJar;
            request.UserAgent = UserAgent;
            request.KeepAlive = false;
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync();
            StreamReader sr = new StreamReader(response.GetResponseStream());
            return sr.ReadToEnd();
        }

        /// <summary>
        /// Performs a basic HTTP POST request
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="body">POST Data to be passed.</param>
        /// <param name="refer">Referrer of the request</param>
        /// <returns>HTML Content of the response.</returns>
        public async Task<string> Post(string url, string body, string refer = "")
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.CookieContainer = cJar;
            request.UserAgent = UserAgent;
            request.KeepAlive = false;
            request.Method = "POST";
            request.Referer = refer;

            if (!string.IsNullOrEmpty(body))
            {
                byte[] postBytes = Encoding.ASCII.GetBytes(body);
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = postBytes.Length;

                Stream requestStream = await request.GetRequestStreamAsync();
                requestStream.Write(postBytes, 0, postBytes.Length);
                requestStream.Close();
            }

            HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync();
            StreamReader sr = new StreamReader(response.GetResponseStream());

            return sr.ReadToEnd();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BReq"/> class.
        /// </summary>
        public AppRequest()
        {
            cJar = new CookieContainer();
        }
    }
}