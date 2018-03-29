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

            var firstCar = new Car
            {
                Brand = "Chrysler",
                Model = "300C",
                ModelYear = 2006,
            };

            var secondCar = new Car
            {
                Brand = "Mercedes",
                Model = "CLK",
                ModelYear = 2003,
            };

            client.AddCar(firstCar);
            client.AddCar(secondCar);

            var allCars = client.ListAllCars(firstCar);
            Console.WriteLine(allCars);
            client.RemoveCar(secondCar);
            Console.WriteLine(client.ListAllCars(firstCar));

            channel.ShutdownAsync().Wait();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
