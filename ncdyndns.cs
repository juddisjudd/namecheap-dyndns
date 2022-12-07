using System;
using System.Net;

namespace NamecheapDynamicDNS
{
    class Program
    {
        static void Main(string[] args)
        {
            // Set the Namecheap API user and key
            string apiUser = "API_USERNAME";
            string apiKey = "API_KEY";

            // Set the domain name and hostname to update
            string domainName = "example.com";
            string hostName = "www";

            // Get the current IP address
            string currentIP = new WebClient().DownloadString("http://checkip.dyndns.org/");
            currentIP = currentIP.Replace("Current IP Address: ", "").Trim();

            // Set up the Namecheap API request URL
            string apiURL = "https://dynamicdns.park-your-domain.com/update";
            apiURL += "?host=" + hostName + "&domain=" + domainName;
            apiURL += "&password=" + currentIP + "&ip=" + currentIP;

            // Set the Namecheap API request credentials
            NetworkCredential apiCredentials = new NetworkCredential(apiUser, apiKey);

            // Create a web client to make the API request
            WebClient client = new WebClient();
            client.Credentials = apiCredentials;

            // Make the API request and get the response
            string response = client.DownloadString(apiURL);

            // Print the response
            Console.WriteLine(response);
        }
    }
}
