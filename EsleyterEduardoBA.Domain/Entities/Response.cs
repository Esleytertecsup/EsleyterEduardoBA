namespace EsleyterEduardoBA.Domain.Entities;

public class Response
{
    public int ResponseId { get; set; }
    public string Content { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public int TicketId { get; set; }
    public Ticket Ticket { get; set; } = null!;
    public int UserId { get; set; }
    public User User { get; set; } = null!;
}