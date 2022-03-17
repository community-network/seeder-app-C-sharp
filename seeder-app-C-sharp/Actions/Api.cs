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
            webClient.QueryString.Add("name", WebUtility.UrlEncode(config.messageServer));
            webClient.QueryString.Add("region", "all");
            webClient.QueryString.Add("platform", "pc");
            webClient.QueryString.Add("limit", "1");
            webClient.QueryString.Add("lang", "en-us");
            string data = webClient.DownloadString(new Uri("https://api.gametools.network/bf1/servers/"));
            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            return json_serializer.Deserialize<Structs.ServerList>(data);
        }

        public static void PostPlayerlist(GameReader.CurrentServerReader current_server_reader, string currentServerId, Guid guid)
        {
            var post = new
            {
                guid = guid.ToString(),
                serverinfo = new {
                    name = current_server_reader.ServerName,
                    gameId = currentServerId
                }, 
                teams = new { 
                    team1 = current_server_reader.PlayerLists_Team1, 
                    team2 = current_server_reader.PlayerLists_Team2 
                }
            };
            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            var dataString = json_serializer.Serialize(post);
            WebClient webClient = new WebClient();
            webClient.Headers.Add(HttpRequestHeader.ContentType, "application/json");
            Int64 unixTimestamp = (Int64)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            webClient.Headers.Add("authentication", (unixTimestamp / 60 * 5963827110).ToString());
            webClient.UploadString(new Uri("https://api.gametools.network/seederplayerlist/bf1"), "POST", dataString);
        }
    }
}
