using DeliverySystem.Core.Models;

namespace ExtensionMethods.Core.Extensions
{
    public static class VehicleExtensions
    {
        public static bool IsOverloaded(this Vehicle v)
        {
            var currentWeight = v.GetDeliveries().Sum(d => d.WeightKg);
            if (currentWeight > v.MaxPayloadKg) return true;
            return false;
        }

        public static decimal AvailablePayload(this Vehicle v)
        {
            var currentWeight = v.GetDeliveries().Sum(d => d.WeightKg);
            return v.MaxPayloadKg - currentWeight;
        }
    }
}
