namespace QuitSmokingApi.Data.Entities;

public class SmokeHistory
{
    public int SmokeHistoryId { get; set; }
    public int UserId { get; set; }
    public DateTime SmokedDate { get; set; }
    public double Cost { get; set; }
}
