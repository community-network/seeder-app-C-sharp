using System;
using System.Collections.Generic;

namespace seeder_app_C_sharp.Structs;

internal class CurrentServer
{
    public string gameId { get; set; }
    public string groupId { get; set; }
    public Int64 timeStamp { get; set; }
    public string action { get; set; }
    public Dictionary<string, Dictionary<string, string>> keepAliveSeeders { get; set; }
    public List<string> seederArr { get; set; }
    public bool rejoin { get; set; }
}
