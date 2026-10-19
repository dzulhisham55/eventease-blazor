using System.ComponentModel.DataAnnotations;

namespace EventEase.Models;

/// <summary>A registration the attendee fills in on the registration form.</summary>
public class RegistrationRequest
{
    [Required(ErrorMessage = "Please enter your full name.")]
    [StringLength(60, MinimumLength = 2, ErrorMessage = "Names are 2 to 60 characters.")]
    public string FullName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please enter your email address.")]
    [EmailAddress(ErrorMessage = "That does not look like a valid email address.")]
    public string Email { get; set; } = string.Empty;
}

/// <summary>A saved registration, held in memory for the life of the session.</summary>
public class Registration
{
    public int Id { get; set; }
    public int EventId { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public bool CheckedIn { get; set; }
    public DateTime RegisteredAt { get; set; } = DateTime.Now;
}
