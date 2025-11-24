using System.ComponentModel.DataAnnotations;
using Cleanuparr.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Cleanuparr.Persistence.Models.Events;

/// <summary>
/// Represents an event in the system
/// </summary>
[Index(nameof(Timestamp), IsDescending = [true])]
[Index(nameof(EventType))]
[Index(nameof(Severity))]
[Index(nameof(Message))]
public class AppEvent : IEvent
{
    [Key]
    public Guid Id { get; set; } = Guid.CreateVersion7();

    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    
    [Required]
    public EventType EventType { get; set; }
    
    [Required]
    [MaxLength(1000)]
    public string Message { get; set; } = string.Empty;
    
    /// <inheritdoc/>
    public string? Data { get; set; }
    
    [Required]
    public required EventSeverity Severity { get; set; }
    
    /// <summary>
    /// Optional correlation ID to link related events
    /// </summary>
    public Guid? TrackingId { get; set; }
} 