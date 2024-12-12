using System.ComponentModel.DataAnnotations;

namespace DoctorSchedulerAPI.Models;

public class Event
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(200)]
    public string Title { get; set; }

    [MaxLength(500)]
    public string Description { get; set; }

    [Required]
    public DateTime StartTime { get; set; }

    [Required]
    public DateTime EndTime { get; set; }

    public List<Attendee> Attendees { get; set; } = new();
}