namespace EsleyterEduardoBA.Domain.DTOs;

public class ResponseDto
{
    public int ResponseId { get; set; }
    public int TicketId { get; set; }
    public int UserId { get; set; }
    public string Content { get; set; } = string.Empty;
    public DateTime? CreatedAt { get; set; }
}