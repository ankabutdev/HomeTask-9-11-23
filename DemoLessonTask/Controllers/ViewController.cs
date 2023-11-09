using DemoLessonTask.DataContext;
using DemoLessonTask.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoLessonTask.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class ViewController : ControllerBase
{
    private readonly AppDbContext _context;

    public ViewController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet()]
    public async Task<IActionResult> ManyToManyPersonCarsAsync()
    {
        var result = await _context.Persons
            .Include(x => x.PersonCars)
            .ThenInclude(y => y.Cars)
            .ToListAsync();

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> OneToManyCarPersonsAsync()
    {
        var cars = await _context.Cars
            .Include(x => x.CarPersons)
            .ThenInclude(y => y.Persons)
            .ToListAsync();

        return Ok(cars);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var cars = await _context.Cars.ToListAsync();
        var persons = await _context.Persons.ToListAsync();

        return Ok(new
        {
            Cars = cars,
            Persons = persons
        });
    }

    [HttpPost]
    public async Task<IActionResult> CreatePersonCarsAsync(string carName, string personName)
    {
        var car = new Car
        {
            Name = carName
        };

        await _context.Cars.AddAsync(car);

        var person = new Person
        {
            Name = personName
        };

        await _context.Persons.AddAsync(person);

        var personCar = new PersonCars
        {
            Persons = person,
            Cars = car
        };

        await _context.PersonCars.AddAsync(personCar);

        await _context.SaveChangesAsync();

        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCarAsync(int carId, string carname)
    {
        var car = await _context.Cars.FindAsync(carId);

        if (car is null)
            return NotFound();

        car.Name = carname;

        await _context.SaveChangesAsync();

        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteCarAsync(int carId)
    {
        var car = await _context.Cars.FindAsync(carId);
        if (car is null)
            return NotFound();

        _context.Cars.Remove(car);

        await _context.SaveChangesAsync();

        return Ok("true");
    }

    [HttpPut]
    public async Task<IActionResult> UpdatePersonAsync(int personId, string personName)
    {
        var person = await _context.Persons.FindAsync(personId);

        if (person is null)
            return NotFound();

        person.Name = personName;

        await _context.SaveChangesAsync();

        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeletePersonAsync(int personId)
    {
        var person = await _context.Cars.FindAsync(personId);
        if (person is null)
            return NotFound();

        _context.Cars.Remove(person);

        await _context.SaveChangesAsync();

        return Ok("true");
    }
}