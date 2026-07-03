using DeliverySystem.Core.Interfaces;
using DeliverySystem.Core.Models;
using System.Text;

namespace DeliverySystem.Core.Services
{
    public class DispatchReportService : IDispatchReportService
    {
        private readonly IVehicleRepository _vehicleRepository;

        public DispatchReportService(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public Result<string> GetReport()
        {
            var sb = new StringBuilder();

            sb.AppendLine("================================");
            sb.AppendLine("Dispatch Report");
            sb.AppendLine("================================");

            var vehicles = _vehicleRepository.GetVehicles();
            foreach (var vehicle in vehicles.Value)
            {
                var currentWeight = vehicle.GetDeliveries().Sum(d => d.WeightKg);
                sb.AppendLine($"{vehicle.GetType().Name} | {vehicle.RegistrationNumber} | Driver: {vehicle.DriverName} | Payload: {currentWeight}/{vehicle.MaxPayloadKg}kg");
                foreach (var delivery in vehicle.GetDeliveries())
                {
                    sb.AppendLine($"{delivery.DeliveryId} -> {delivery.DestinationAddress} ({delivery.WeightKg}kg)");
                }
                sb.AppendLine("");
            }

            sb.AppendLine("================================");
            sb.AppendLine("Failed Assignments:");

            var failed = _vehicleRepository.GetFailedAssignments();
            foreach (var failedAssignment in failed.Value)
            {
                sb.AppendLine($"{failedAssignment.DeliveryId} -> {failedAssignment.Reason}");
            }

            sb.AppendLine("================================");

            return Result<string>.Ok(sb.ToString());
        }
    }
}
