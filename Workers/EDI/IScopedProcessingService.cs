using System.Threading;
using System.Threading.Tasks;

namespace Workers.EDI
{
    public interface IScopedProcessingService
    {
        Task DoWork(CancellationToken stoppingToken);
    }
}