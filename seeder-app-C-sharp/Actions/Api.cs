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

        public static void PingBackend(Config config, Structs.GameInfo game_info, GameReader.CurrentServerReader current_server_reader)
        {
            var post = new { 
                groupid = config.groupId,
                isrunning = game_info.Is_Running,
                hostname = config.hostname,
                servername = current_server_reader.ServerName,
                gameid = current_server_reader.GameId
            };
            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            var dataString = json_serializer.Serialize(post);
            WebClient webClient = new WebClient();
            webClient.Headers.Add(HttpRequestHeader.ContentType, "application/json");
            webClient.UploadString(new Uri("https://manager-api.gametools.network/api/seederinfo"), "POST", dataString);
        }

        public static Structs.ServerList FindServer(Config config)
        {
            WebClient webClient = new WebClient();
            webClient.QueryString.Add("name", Uri.EscapeDataString(config.messageServer));
            webClient.QueryString.Add("region", "all");
            webClient.QueryString.Add("platform", "pc");
            webClient.QueryString.Add("limit", "1");
            webClient.QueryString.Add("lang", "en-us");
            string data = webClient.DownloadString(new Uri("https://api.gametools.network/bf1/servers/"));
            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            return json_serializer.Deserialize<Structs.ServerList>(data);
        }

        public static void PostPlayerlist(GameReader.CurrentServerReader currentServerReader, Guid guid)
        {
            var post = new
            {
                guid = guid.ToString(),
                serverinfo = new
                {
                    name = currentServerReader.ServerName,
                    gameId = currentServerReader.GameId
                },
                teams = new
                {
                    team1 = currentServerReader.PlayerListsTeam1,
                    team2 = currentServerReader.PlayerListsTeam2,
                    scoreteam1 = currentServerReader.ServerScoreTeam1,
                    scoreteam2 = currentServerReader.ServerScoreTeam2,
                    scoreteam1FromKills = currentServerReader.Team1ScoreFromKill,
                    scoreteam2FromKills = currentServerReader.Team2ScoreFromKill,
                    scoreteam1FromFlags = currentServerReader.Team1ScoreFromFlags,
                    scoreteam2FromFlags = currentServerReader.Team2ScoreFromFlags,
                }
            };
            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            string dataString = json_serializer.Serialize(post);
            WebClient webClient = new WebClient();
            string jwtData = Jwt.Create(guid, dataString);
            webClient.Headers.Add(HttpRequestHeader.ContentType, "application/json");
            string postData = json_serializer.Serialize(new { data = jwtData });
            webClient.UploadString(new Uri("https://api.gametools.network/seederplayerlist/bf1"), "POST", postData);
        }
    }
}
