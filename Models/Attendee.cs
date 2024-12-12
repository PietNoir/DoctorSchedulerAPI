using System.ComponentModel.DataAnnotations;

namespace DoctorSchedulerAPI.Models;

public class Attendee
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public string Name { get; set; }

    [Required, EmailAddress, MaxLength(100)]
    public string Email { get; set; }

    public bool IsAttending { get; set; }
    
    public bool HasResponded { get; set; } = false;
}