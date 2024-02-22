using SocialAuthentication.Helper.HttpContent;
using JsonContent = SocialAuthentication.Helper.HttpContent.JsonContent;


namespace SocialAuthentication.Helper.HttpClient
{
    public class HttpRequestFactory
    {
        public static async Task<HttpResponseMessage> Get(string requestUri, string token = null)
        {
            var builder = new HttpRequestBuilder()
                                .AddMethod(HttpMethod.Get)
                                .AddRequestUri(requestUri)
                                .AddBearerToken(token);

            return await builder.SendAsync();
        }

        public static async Task<HttpResponseMessage> Post(
           string requestUri, object value, string token = null)
        {
            var builder = new HttpRequestBuilder()
                                .AddMethod(HttpMethod.Post)
                                .AddRequestUri(requestUri)
                                .AddContent(new JsonContent(value))
                                .AddBearerToken(token);

            return await builder.SendAsync();
        }

        public static async Task<HttpResponseMessage> Put(
           string requestUri, object value, string token = null)
        {
            var builder = new HttpRequestBuilder()
                                .AddMethod(HttpMethod.Put)
                                .AddRequestUri(requestUri)
                                .AddContent(new JsonContent(value))
                                .AddBearerToken(token);

            return await builder.SendAsync();
        }

        public static async Task<HttpResponseMessage> Patch(
           string requestUri, object value, string token = null)
        {
            var builder = new HttpRequestBuilder()
                                .AddMethod(new HttpMethod("PATCH"))
                                .AddRequestUri(requestUri)
                                .AddContent(new PatchContent(value))
                                .AddBearerToken(token);

            return await builder.SendAsync();
        }

        public static async Task<HttpResponseMessage> Delete(string requestUri, string token = null)
        {
            var builder = new HttpRequestBuilder()
                                .AddMethod(HttpMethod.Delete)
                                .AddRequestUri(requestUri)
                                .AddBearerToken(token);

            return await builder.SendAsync();
        }
    }
}
