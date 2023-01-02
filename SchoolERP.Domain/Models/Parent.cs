
namespace SchoolERP.Domain.Models;

public class Parent : Person
{
    public List<Student> Wards { get; set; }
}