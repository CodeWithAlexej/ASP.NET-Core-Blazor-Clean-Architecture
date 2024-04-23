namespace HR.LeaveManagement.Domain.Common
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateTimeModified { get; set; }
    }
}
