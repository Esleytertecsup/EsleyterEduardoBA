namespace EsleyterEduardoBA.Domain.Entities;

public class Ticket
{
    public int TicketId { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Status { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public int UserId { get; set; }
    public User User { get; set; } = null!;
    public ICollection<Response> Responses { get; set; } = new List<Response>();
}