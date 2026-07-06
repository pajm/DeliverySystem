# Delivery System

Manages delivery assignments across vehicle types (Truck, Motorcycle) with dispatch reporting and vehicle tracking capabilities.

## Key Components
- **Models**: `Delivery` (delivery record), `Truck`, `Motorcycle` (vehicle types), `Result` (operation outcome)
- **Interfaces**: `IDispatchReportService`, `IVehicleAssignmentService`, `IVehicleRepository`
- **Extensions**: `VehicleExtensions`

## Functionality
- Tracks deliveries and assigns them to appropriate vehicles
- Generates dispatch reports for completed deliveries
- Manages vehicle inventory and availability
- Supports extensible vehicle types

## Extensions

### VehicleExtensions
Provides useful helper methods for `Vehicle` objects:

- **`IsOverloaded()`** — Checks if a vehicle’s current payload exceeds its maximum capacity.
- **`AvailablePayload()`** — Returns the remaining payload capacity in kilograms.

```csharp
// Example usage
if (vehicle.IsOverloaded())
{
    Console.WriteLine("Vehicle is overloaded!");
}

decimal remaining = vehicle.AvailablePayload();
