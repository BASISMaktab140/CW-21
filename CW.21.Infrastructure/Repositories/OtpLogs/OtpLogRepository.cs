using CW._21.Domain.OtpLogs;
using CW._21.Infrastructures.Data;
using CW._21.Infrastructures.Repositories.Generics;
using Microsoft.EntityFrameworkCore;

namespace CW._21.Infrastructures.Repositories.OtpLogs;

public class OtpLogRepository : GenericRepository<OtpLog>, IOtpLogRepository
{
    public OtpLogRepository(AppDbContext context) : base(context)
    {
    }

    public async Task AddAsync(OtpLog otpLog)
    {
        await DbSet.AddAsync(otpLog);
        await SaveChangesAsync();
    }

    public async Task<OtpLog?> GetValidCodeAsync(string emailOrPhone, string code)
    {
        return await DbSet
            .Where(o => o.EmailOrPhone == emailOrPhone
                        && o.Code == code
                        && !o.IsUsed
                        && o.ExpiresAt > DateTime.UtcNow)
            .FirstOrDefaultAsync();
    }

    public async Task UpdateAsync(OtpLog otpLog)
    {
        DbSet.Update(otpLog);
        await SaveChangesAsync();
    }
}