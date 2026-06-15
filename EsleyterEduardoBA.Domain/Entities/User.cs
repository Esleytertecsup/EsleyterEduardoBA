namespace EsleyterEduardoBA.Domain.Entities;

public class User
{
    public int UserId { get; set; }
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public ICollection<Role> Roles { get; set; } = new List<Role>();
    public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}