using DeliverySystem.Core.Models;

namespace DeliverySystem.Core.Interfaces
{
    public interface IVehicleRepository
    {
        void AddVehicle(Vehicle vehicle);
        Result<List<Vehicle>> GetVehicles();
        Result<Delivery> AddDelivery(Vehicle vehcile, Delivery delivery);
        Result<Vehicle> GetVehicleById(string reg);
        Result<List<(string DeliveryId, string Reason)>> GetFailedAssignments();
    }
}
