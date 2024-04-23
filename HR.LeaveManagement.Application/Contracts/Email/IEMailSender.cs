
using HR.LeaveManagement.Application.Models.Email;

namespace HR.LeaveManagement.Application.Contracts.Email
{
    public interface IEMailSender
    {
        Task<bool> SendEmail(EmailMessage email);
    }
}
