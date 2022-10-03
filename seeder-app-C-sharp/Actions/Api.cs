using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;

namespace seeder_app_C_sharp.Actions
{
    internal class Api
    {
        public static Structs.CurrentServer Gather(Config config)
        {
            var query = new Dictionary<string, string>()
            {
                ["groupid"] = config.groupId
            };
            var uri = QueryHelpers.AddQueryString("https://manager-api.gametools.network/api/getseeder", query);
            HttpResponseMessage httpResponse = new HttpClient().GetAsync(uri).Result;
            string responseContent = httpResponse.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<Structs.CurrentServer>(responseContent);
        }

        public static void PingBackend(Config config, Structs.GameInfo game_info, GameReader.CurrentServerReader current_server_reader)
        {
            var payload = new { 
                groupid = config.groupId,
                isrunning = game_info.Is_Running,
                hostname = config.hostname,
                servername = current_server_reader.ServerName,
                gameid = current_server_reader.GameId
            };
            string stringPayload = JsonConvert.SerializeObject(payload);
            StringContent httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponse = new HttpClient().PostAsync("https://manager-api.gametools.network/api/seederinfo", httpContent).Result;
            _ = httpResponse.Content.ReadAsStringAsync().Result;
        }

        public static Structs.ServerList FindServer(Config config)
        {
            var query = new Dictionary<string, string>()
            {
                ["name"] = Uri.EscapeDataString(config.messageServer),
                ["region"] = "all",
                ["platform"] = "pc",
                ["limit"] = "1",
                ["lang"] = "en-us"
            };
            var uri = QueryHelpers.AddQueryString("https://api.gametools.network/bf1/servers/", query);
            HttpResponseMessage httpResponse = new HttpClient().GetAsync(uri).Result;
            string responseContent = httpResponse.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<Structs.ServerList>(responseContent);
        }

        public static void PostPlayerlist(GameReader.CurrentServerReader currentServerReader, Guid guid)
        {
            var payload = new
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
            string dataString = JsonConvert.SerializeObject(payload);
            string jwtData = Jwt.Create(guid, dataString);
            string stringPayload = JsonConvert.SerializeObject(new { data = jwtData });
            StringContent httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponse = new HttpClient().PostAsync("https://api.gametools.network/seederplayerlist/bf1", httpContent).Result;
            _ = httpResponse.Content.ReadAsStringAsync().Result;
        }
    }
}
