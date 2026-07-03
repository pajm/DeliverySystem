using DeliverySystem.Core.Interfaces;
using DeliverySystem.Core.Models;

namespace DeliverySystem.Core.Repositories
{
    public class InMemoryVehicleRepository : IVehicleRepository
    {
        private readonly List<Vehicle> _vehicles = new List<Vehicle> {
            new Van("VAN-001", "John Smith", 500m),
            new Truck("TRK-001", "Jane Doe", 5000m, 4),
            new Motorcycle("MCY-001", "Bob Jones", 50m),
        };

        private readonly new List<(string DeliveryId, string Reason)> _failedAssignments = new List<(string DeliveryId, string Reason)>();

        public Result<Delivery> AddDelivery(Vehicle vehicle, Delivery delivery)
        {
            var result = vehicle.AssignDelivery(delivery);
            if (!result.IsSuccess)
            {
                _failedAssignments.Add(new(delivery.DeliveryId, result.Error));
            }
            return result;
        }

        public void AddVehicle(Vehicle vehicle)
        {
            _vehicles.Add(vehicle);
        }

        public Result<List<Vehicle>> GetVehicles()
        {
            return Result<List<Vehicle>>.Ok(_vehicles);
        }

        public Result<Vehicle> GetVehicleById(string reg)
        {
            return Result<Vehicle>.Ok(_vehicles.Where(a => a.RegistrationNumber == reg).FirstOrDefault());
        }

        public Result<List<(string DeliveryId, string Reason)>> GetFailedAssignments()
        {
            return Result<List<(string DeliveryId, string Reason)>>.Ok(_failedAssignments);
        }
    }
}
