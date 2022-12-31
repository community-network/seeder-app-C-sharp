using System.Collections.Generic;

namespace seeder_app_C_sharp.Structs;

internal class ServerList
{
    public List<ServerInfo> servers { get; set; }
}

internal class ServerInfo
{
    public string gameId { get; set; }
}
