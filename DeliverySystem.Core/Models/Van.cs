namespace DeliverySystem.Core.Models
{
    public class Van : Vehicle
    {
        public Van(string registrationNumber, string driverName, decimal maxPayloadKg)
        : base(registrationNumber, driverName, maxPayloadKg)
        {
        }

        public override Result<Delivery> AssignDelivery(Delivery delivery)
        {
            return base.AssignDelivery(delivery);
        }
    }
}
