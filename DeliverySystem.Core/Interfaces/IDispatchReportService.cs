using DeliverySystem.Core.Models;

namespace DeliverySystem.Core.Interfaces
{
    public interface IDispatchReportService
    {
        Result<string> GetReport();
    }
}
