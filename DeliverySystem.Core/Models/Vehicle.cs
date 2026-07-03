namespace DeliverySystem.Core.Models
{
    public abstract class Vehicle
    {
        public string RegistrationNumber { get; set; }
        public string DriverName { get; set; }
        public decimal MaxPayloadKg { get; set; }

        protected List<Delivery> deliveries = new List<Delivery>();

        public Vehicle(string registrationNumer, string driverName, decimal maxPayloadKg)
        {
            this.RegistrationNumber = registrationNumer;
            this.DriverName = driverName;
            this.MaxPayloadKg = maxPayloadKg;
        }

        public virtual Result<Delivery> AssignDelivery(Delivery delivery)
        {
            if (delivery == null)
                return Result<Delivery>.Fail("Delivery cannot be null");

            var currentWeight = deliveries.Sum(d => d.WeightKg);
            if (currentWeight + delivery.WeightKg > MaxPayloadKg)
                return Result<Delivery>.Fail("Payload limit exceeded");

            deliveries.Add(delivery);
            return Result<Delivery>.Ok(delivery);
        }

        public IReadOnlyList<Delivery> GetDeliveries()
        {
            return deliveries.AsReadOnly();
        }
    }
}
