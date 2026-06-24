using Cw._21.Abstraction;

namespace CW._21.Domain.OtpLogs;

public class OtpLog : BaseEntity
{
    public OtpLog(string code, string emailOrPhone, DateTime expiresAt)
    {
        Code = code;
        EmailOrPhone = emailOrPhone;
        ExpiresAt = expiresAt;
    }

    public string Code { get; set; } // must be hashed to get more secured
    // can add user and attemps for more control 
    public string EmailOrPhone { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime ExpiresAt { get; set; }
    public bool IsUsed { get; set; } = false;
}