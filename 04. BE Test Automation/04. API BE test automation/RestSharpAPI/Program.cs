using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using RestSharpAPI;

var client = new RestClient(new RestClientOptions("https://api.github.com")
{
    Authenticator = new HttpBasicAuthenticator("StPKr", "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")
});

var request = new RestRequest
 ("/repos/testnakov/test-nakov-repo/issues", Method.Post);

request.AddHeader("Content-Type", "application/json");
request.AddJsonBody(new { title = "Gosho", body = "Pesho" });

var response = client.Execute(request);
Console.WriteLine(response.StatusCode);