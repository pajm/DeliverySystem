# Delivery System

Manages delivery assignments across vehicle types (Truck, Motorcycle) with dispatch reporting and vehicle tracking capabilities.

## Key Components
- **Models**: `Delivery` (delivery record), `Truck`, `Motorcycle` (vehicle types), `Result` (operation outcome)
- **Interfaces**: `IDispatchReportService`, `IVehicleAssignmentService`, `IVehicleRepository`

## Functionality
- Tracks deliveries and assigns them to appropriate vehicles
- Generates dispatch reports for completed deliveries
- Manages vehicle inventory and availability
- Supports extensible vehicle types

## Usage
1. Create delivery records with pickup/destination data
2. Register vehicles with IVehicleRepository
3. Assign deliveries using IVehicleAssignmentService
4. Generate reports with IDispatchReportService
5. Monitor vehicle availability and utilization