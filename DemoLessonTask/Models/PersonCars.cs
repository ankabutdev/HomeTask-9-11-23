namespace DemoLessonTask.Models;

public class PersonCars
{
    public int Id { get; set; }

    public int PersonId { get; set; }

    public int CarId { get; set; }

    public Person Persons { get; set; }

    public Car Cars { get; set; }
}
