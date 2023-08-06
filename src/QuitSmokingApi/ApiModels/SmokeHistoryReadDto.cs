namespace QuitSmokingApi.ApiModels;

public record SmokeHistoryReadDto(int UserId, DateTime SmokedDate, double Cost);
