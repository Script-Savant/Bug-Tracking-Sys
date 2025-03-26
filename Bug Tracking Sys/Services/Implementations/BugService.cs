using Bug_Tracking_Sys.Services.Abstractions;
using Bug_Tracking_Sys.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bug_Tracking_Sys.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Bug_Tracking_Sys.Services.Implementations
{
    public class BugService : IBugService
    {
        private readonly AppDbContext _db;

        public BugService(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IEnumerable<Bug>> GetAllBugsAsync()
        {
           var bugs = await _db.Bugs.ToListAsync();

           return bugs;
        }

        public async Task<Bug> GetBugByIdAsync(int id)
        {
            var bug = await _db.Bugs
               .Include(b => b.History)
               .FirstOrDefaultAsync(b => b.BugId == id);

            if (bug == null) throw new KeyNotFoundException($"Bug with ID {id} not found");

            return bug;
        }

        public async Task CreateBugAsync(Bug bug)
        {
            if (bug == null) throw new ArgumentNullException(nameof(bug));

            // record creation history logic will be here

            bug.CreatedAt = DateTime.UtcNow;
            await _db.Bugs.AddAsync(bug);
            await _db.SaveChangesAsync();

        }

        public async Task UpdateBugAsync(Bug bug)
        {
            if (bug == null) throw new ArgumentNullException(nameof(bug));

            var existingBug = await _db.Bugs
                .FirstOrDefaultAsync(b => b.BugId == bug.BugId);

            if (existingBug == null) throw new KeyNotFoundException($"Bug with ID {bug.BugId} not found");

            // record history before update if status changed will be here

            existingBug.UpdatedAt = DateTime.UtcNow;
            _db.Entry(existingBug).CurrentValues.SetValues(bug);
            await _db.SaveChangesAsync();
        }

        public async Task ResolveBugAsync(int id)
        {
            var bug = await _db.Bugs
                .FirstOrDefaultAsync(b => b.BugId == id);
            if (bug == null) throw new KeyNotFoundException($"Bug with ID {id} not found");


            // record bug resolution date and status logic wii be here


            bug.Status = BugStatus.Resolved;
            bug.ResolvedAt = DateTime.UtcNow;
            await _db.SaveChangesAsync();
        }
    }
}
