namespace DemoLessonTask.Models;

public class PersonCars
{
    public int Id { get; set; }

    public int PersonId { get; set; }

    public int CarId { get; set; }

    public virtual Person Persons { get; set; }

    public virtual Car Cars { get; set; }
}
