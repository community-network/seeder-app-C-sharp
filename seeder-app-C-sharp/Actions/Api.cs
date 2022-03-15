using System;
using System.Net;
using System.Web.Script.Serialization;

namespace seeder_app_C_sharp.Actions
{
    internal class Api
    {
        public static Structs.CurrentServer Gather(Config config)
        {
            WebClient webClient = new WebClient();
            webClient.QueryString.Add("groupid", config.groupId);
            string data = webClient.DownloadString(new Uri("https://manager-api.gametools.network/api/getseeder"));
            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            return json_serializer.Deserialize<Structs.CurrentServer>(data);
        }

        public static void PingBackend(Config config, Structs.GameInfo game_info)
        {
            var post = new { groupid = config.groupId, isrunning = game_info.Is_Running, hostname = config.hostname };
            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            var dataString = json_serializer.Serialize(post);
            WebClient webClient = new WebClient();
            webClient.Headers.Add(HttpRequestHeader.ContentType, "application/json");
            webClient.UploadString(new Uri("https://manager-api.gametools.network/api/seederinfo"), "POST", dataString);
        }

        public static Structs.ServerList FindServer(Config config)
        {
            WebClient webClient = new WebClient();
            webClient.QueryString.Add("name", config.messageServer);
            webClient.QueryString.Add("region", "all");
            webClient.QueryString.Add("platform", "pc");
            webClient.QueryString.Add("limit", "1");
            webClient.QueryString.Add("lang", "en-us");
            string data = webClient.DownloadString(new Uri("https://api.gametools.network/bf1/servers/"));
            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            return json_serializer.Deserialize<Structs.ServerList>(data);
        }
    }
}
