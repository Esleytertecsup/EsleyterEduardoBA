using EsleyterEduardoBA.Services;
using Hangfire;
using Microsoft.AspNetCore.Mvc;

namespace EsleyterEduardoBA.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JobsController : ControllerBase
{
    [HttpPost("fire-and-forget")]
    public IActionResult FireAndForget()
    {
        BackgroundJob.Enqueue(() =>
            new NotificationService().SendNotification("usuario1"));
        return Ok("Job fire-and-forget encolado.");
    }

    [HttpPost("delayed")]
    public IActionResult Delayed()
    {
        BackgroundJob.Schedule(() =>
                new NotificationService().SendNotification("usuario2"),
            TimeSpan.FromMinutes(10));
        return Ok("Job delayed encolado para 10 minutos.");
    }

    [HttpPost("recurrente")]
    public IActionResult Recurrente()
    {
        RecurringJob.AddOrUpdate(
            "job-notificacion-diaria",
            () => new NotificationService().SendNotification("usuario_diario"),
            Cron.Daily);
        return Ok("Job recurrente registrado.");
    }
    
    [HttpPost("limpieza")]
    public IActionResult LimpiezaRecurrente()
    {
        RecurringJob.AddOrUpdate(
            "job-limpieza-tickets",
            () => new NotificationService().LimpiarTicketsAntiguos(),
            Cron.Weekly);
        return Ok("Job de limpieza semanal registrado.");
    }
}