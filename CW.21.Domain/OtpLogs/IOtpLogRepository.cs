using CW._21.Domain.Generics;

namespace CW._21.Domain.OtpLogs;

public interface IOtpLogRepository : IGenericRepository<OtpLog>
{
    Task AddAsync(OtpLog otpLog);
    Task<OtpLog?> GetValidCodeAsync(string emailOrPhone, string code);
    Task UpdateAsync(OtpLog otpLog);
}