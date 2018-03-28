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
        public override Task<Empty> AddCar(Car request, ServerCallContext context)
        {
            Console.WriteLine($"Adding car: {request.Model}");
            return Task.FromResult(new Empty());
        }

        public override Task<CarList> ListAllCars(Car request, ServerCallContext context)
        {
            return base.ListAllCars(request, context);
        }

        public override Task<Car> RemoveCar(Car request, ServerCallContext context)
        {
            return base.RemoveCar(request, context);
        }
    }
}
