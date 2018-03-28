using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CarInventoryProto.CarInventory;

namespace CarInventoryServer
{
    class Program : CarInventoryBase
    {
        const int Port = 50051;

        static void Main(string[] args)
        {
            Server server = new Server
            {
                Services = { BindService(new ServerDefinition()) },
                Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) }
            };
            server.Start();

            Console.WriteLine("Press any key to stop the server...");
            Console.ReadKey();

            server.ShutdownAsync().Wait();
        }
    }
}
