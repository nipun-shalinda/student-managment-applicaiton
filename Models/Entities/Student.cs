namespace student_manager.Web.Models.Entities;

public class Student
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
    public string Course { get; set; }
}