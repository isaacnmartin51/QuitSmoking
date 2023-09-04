
namespace QuitSmoking.Api.DataAccess.Entities;

public abstract class BaseEntity
{
    public Guid Id { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime CreateDate { get; set; }
    public Guid ModidfiedBy { get; set; }
    public DateTime ModifiedDate { get; set; }
}
