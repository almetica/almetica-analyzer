using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tera.Analytics;

namespace TeraAnalyse
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Starting TERA.exe");

            var gamePath = @"D:\Tera Clients\TERA-93.04-EU\Binaries\TERA.exe";
            var analyzer = new GameClientAnalyzer(gamePath);
            var result = await analyzer.Analyze();

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"key.yaml"))
            {
                file.WriteLine("key: " + BitConverter.ToString(result.DataCenterKey).Replace("-", ""));
                file.WriteLine("iv: " + BitConverter.ToString(result.DataCenterIv).Replace("-", ""));
                file.Flush();
                file.Close();
            }

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"opcode.yaml"))
            {
                foreach (KeyValuePair<ushort, string> packet in result.PacketNamesByOpcode)
                {
                    file.WriteLine(packet.Value + ": " + packet.Key);
                }
                file.Flush();
                file.Close();
            }

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"messages.yaml"))
            {
                UInt32 i = 0;
                foreach (string msg in result.SystemMessageReadableIds)
                {
                    file.WriteLine("- " + msg);
                    i++;
                }
                file.Flush();
                file.Close();
            }

            Console.WriteLine("Finished extracting the data.");

            return;
        }
    }
}
