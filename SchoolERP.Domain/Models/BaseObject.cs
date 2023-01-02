namespace SchoolERP.Domain.Models;

public abstract class BaseObject
{
    public long Id { get; init; }
    public string? CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}