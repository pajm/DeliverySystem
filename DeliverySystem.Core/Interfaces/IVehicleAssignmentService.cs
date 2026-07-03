using DeliverySystem.Core.Models;

namespace DeliverySystem.Core.Interfaces
{
    public interface IVehicleAssignmentService
    {
        Result<Delivery> AddDelivery(string reg, Delivery delivery);
    }
}
