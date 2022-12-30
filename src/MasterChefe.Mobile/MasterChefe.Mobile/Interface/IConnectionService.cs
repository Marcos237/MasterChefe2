using System.Net.Http;
    
namespace MasterChefe.Mobile.Interface
{
    public interface IConnectionService
    {
        HttpClient client { get; set; }
        string url { get; set; }
        HttpClient GetClient();
        string GetUrl(string partialUrl);
        HttpClientHandler GetInsecureHandler();
    }
}
