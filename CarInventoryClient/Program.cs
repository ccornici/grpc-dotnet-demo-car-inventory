using CarInventoryProto;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarInventoryClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Channel channel = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);
            var client = new CarInventory.CarInventoryClient(channel);

            var reply = client.AddCar(new Car
            {
                Brand = "Chrysler",
                Model = "300C",
                ModelYear = 2006
            });
            Console.WriteLine("Added car");

            channel.ShutdownAsync().Wait();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
