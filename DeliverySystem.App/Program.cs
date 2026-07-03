using DeliverySystem.Core.Models;
using DeliverySystem.Core.Repositories;
using DeliverySystem.Core.Services;

// Assign to Van
var d1 = new Delivery("DEL-001", "123 High Street, London", 150m);
var d2 = new Delivery("DEL-002", "456 Park Lane, London", 200m);
var d3 = new Delivery("DEL-003", "789 Kings Road, London", 200m); // exceeds Van limit

// Assign to Truck
var d4 = new Delivery("DEL-004", "10 Industrial Way, Manchester", 2000m);
var d5 = new Delivery("DEL-005", "22 Warehouse Road, Manchester", 2500m);

// Assign to Motorcycle
var d6 = new Delivery("DEL-006", "5 Shop Street, Birmingham", 10m);
var d7 = new Delivery("DEL-007", "8 Market Place, Birmingham", 10m); // exceeds Motorcycle limit

var repo = new InMemoryVehicleRepository();
var service = new VehicleAssignmentService(repo);

service.AddDelivery("VAN-001", d1);
service.AddDelivery("VAN-001", d2);
service.AddDelivery("VAN-001", d3);
service.AddDelivery("TRK-001", d4);
service.AddDelivery("TRK-001", d5);
service.AddDelivery("MCY-001", d6);
service.AddDelivery("MCY-001", d7);

var reportService = new DispatchReportService(repo);
Console.WriteLine(reportService.GetReport().Value);