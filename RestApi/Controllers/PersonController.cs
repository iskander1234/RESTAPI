using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApi.Data;
using RestApi.Models;

namespace RestApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        private readonly PersonContext _db;

        public PersonController(PersonContext db) //Добавил для проверки 
        {
            _db = db;
            if (!_db.Persons.Any())
            {
                _db.Persons.Add(new Person {Iin = 760724300757, Age = 44});
                _db.SaveChanges();
            }
        }

        [HttpGet] //http://localhost:5000/api/person
        public async Task<ActionResult<IEnumerable<Person>>> Get()
        {
            return await _db.Persons.ToListAsync();
        }
        
        [HttpGet("{Iin}")] //http://localhost:5000/api/person/760724300757 -- Получение пользователя с иин Inn - 760724300757
        public async Task<ActionResult<IEnumerable<Person>>> Get(long Iin)
        {
            
            Person person = await _db.Persons.FirstOrDefaultAsync(i => i.Iin == Iin);
            if (person is null)
            {
                return NotFound();
            }
            return new ObjectResult(person);
        }
        
        // [HttpPost("{Iin}")] //http://localhost:5000/api/person/760724300757 -- 
        // public async Task<ActionResult<IEnumerable<Person>>> Post(long Iin)
        // {
        //     Person person = new Person();
        //     
        //     if (person is null)
        //     {
        //         
        //     }
        //
        //     _db.Persons.Add(person);
        //     await _db.SaveChangesAsync();
        //     return Ok(person);
        // }
        //
        //
        // public static int CalculateAge(DateTime BirthDate)
        // {
        //     int YearsPassed = DateTime.Now.Year - BirthDate.Year;
        //     if (DateTime.Now.Month < BirthDate.Month || (DateTime.Now.Month == BirthDate.Month && DateTime.Now.Day < BirthDate.Day))
        //     {
        //         YearsPassed--;
        //     }
        //     return YearsPassed;
        // }
        //
    }
}