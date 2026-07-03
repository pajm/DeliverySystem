using DeliverySystem.Core.Interfaces;
using DeliverySystem.Core.Models;

namespace DeliverySystem.Core.Services
{
    public class VehicleAssignmentService : IVehicleAssignmentService
    {
        private readonly IVehicleRepository _vehicleRepository;
        public VehicleAssignmentService(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public Result<Delivery> AddDelivery(string reg, Delivery delivery)
        {
            var vehicle = _vehicleRepository.GetVehicleById(reg);
            if (vehicle == null) return Result<Delivery>.Fail("No vehicle found");

            return _vehicleRepository.AddDelivery(vehicle.Value, delivery);
        }
    }
}
