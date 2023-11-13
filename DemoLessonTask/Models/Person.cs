namespace DemoLessonTask.Models;

public class Person
{
    public int Id { get; set; }
    public string Name { get; set; }

    public virtual ICollection<PersonCars> PersonCars { get; set; }
}
