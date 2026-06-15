namespace EsleyterEduardoBA.Domain.DTOs;

public class TicketDto
{
    public int TicketId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string Status { get; set; } = string.Empty;
    public DateTime? CreatedAt { get; set; }
    public int UserId { get; set; }
}