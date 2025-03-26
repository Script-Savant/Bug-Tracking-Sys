using Bug_Tracking_Sys.Models;

namespace Bug_Tracking_Sys.Services.Abstractions
{
    public interface IBugService
    {
        Task<IEnumerable<Bug>> GetAllBugsAsync();
        Task<Bug> GetBugByIdAsync(int id);
        Task CreateBugAsync(Bug bug);
        Task UpdateBugAsync(Bug bug);
        Task ResolveBugAsync(int id);
    }
}
