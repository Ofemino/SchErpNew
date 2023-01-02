namespace SchoolERP.Domain.Models;

public class ClassHistory : BaseObject
{
    public int StudentId { get; set; }
    public string ClassYear { get; set; }
    public string ClassTerm { get; set; }
}