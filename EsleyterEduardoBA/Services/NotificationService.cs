namespace EsleyterEduardoBA.Services;

public class NotificationService
{
    public void SendNotification(string user)
    {
        Console.WriteLine($"Notificación enviada a {user} en {DateTime.Now}");
    }

    public void LimpiarTicketsAntiguos()
    {
        Console.WriteLine($"Limpieza de tickets ejecutada en {DateTime.Now}");
    }
}