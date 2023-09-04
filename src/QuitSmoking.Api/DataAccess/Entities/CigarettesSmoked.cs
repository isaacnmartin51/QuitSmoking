namespace QuitSmoking.Api.DataAccess.Entities;

public class CigaretteSmoked : BaseEntity
{
    public Guid Id { get; set; }
    public DateTime DateSmoked { get; set; }
}