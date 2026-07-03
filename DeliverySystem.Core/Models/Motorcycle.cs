namespace DeliverySystem.Core.Models
{
    public class Motorcycle : Vehicle
    {
        public Motorcycle(string registrationNumber, string driverName, decimal maxPayloadKg)
        : base(registrationNumber, driverName, maxPayloadKg)
        {
        }
        public override Result<Delivery> AssignDelivery(Delivery delivery)
        {
            if (deliveries.Count >= 1)
                return Result<Delivery>.Fail("Motorcycle can only carry one delivery");

            return base.AssignDelivery(delivery);
        }
    }
}
