using DoctorSchedulerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DoctorSchedulerAPI.Data;

public class ScheduleContext : DbContext
{
    public ScheduleContext(DbContextOptions<ScheduleContext> options) : base(options) { }

    public DbSet<Event> Events { get; set; }
    public DbSet<Attendee> Attendees { get; set; }
}