namespace DeliverySystem.Core.Models
{
    public class Truck : Vehicle
    {
        public Truck(string registrationNumber, string driverName, decimal maxPayloadKg, int NumberOfAxles)
        : base(registrationNumber, driverName, maxPayloadKg)
        {
            this.NumberOfAxles = NumberOfAxles;
        }
        public int NumberOfAxles { get; set; }
        public override Result<Delivery> AssignDelivery(Delivery delivery)
        {
            return base.AssignDelivery(delivery);
        }
    }
}
