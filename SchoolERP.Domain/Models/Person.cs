namespace SchoolERP.Domain.Models;

public class Person : BaseObject
{
    public string? Title { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? MiddleName { get; set; }
    public string? Gender { get; set; }
    public DateTime? DateOfBirth { get; set; }
}