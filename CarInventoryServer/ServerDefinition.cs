using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarInventoryProto;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using static CarInventoryProto.CarInventory;

namespace CarInventoryServer
{
    class ServerDefinition : CarInventoryBase
    {
        // Fancy database
        static CarList carList = new CarList();

        public override Task<Empty> AddCar(Car request, ServerCallContext context)
        {
            carList.Cars.Add(request);

            Console.WriteLine($"Adding {request.Brand} {request.Model}");
            return Task.FromResult(new Empty());
        }

        public override Task<CarList> ListAllCars(Car request, ServerCallContext context)
        {
            return Task.FromResult(carList);
        }

        public override Task<Car> RemoveCar(Car request, ServerCallContext context)
        {
            carList.Cars.Remove(request);

            Console.WriteLine($"Removing {request.Brand} {request.Model}");
            return Task.FromResult(request);
        }
    }
}
