namespace SchoolERP.Domain.Models;

public class Student : Person
{
    public IEnumerator<PupilClass> StudentClasses { get; set; }
}