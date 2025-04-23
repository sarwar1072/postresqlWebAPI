using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using System.Linq;
namespace CrudewebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        [HttpGet("getall")]
        public IActionResult GetAllStudents()
        {
            var student = new Students();

           var data= student.ListOfStudent();
            if(data != null) {
                return Ok(data);

            }
            return BadRequest(); ;
        }

        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            var student = new Students();
            var data=student.ListOfStudent().Where(x=>x.Id==id); 
            if (data.Any())
            {
                return Ok(data);

            }
            return BadRequest();
        }
       
    }
    class Students
    {
        public int Id { get; set; } 
        public string? Name { get; set; }    
        public string? Email { get; set; }
        public List<Students> ListOfStudent()
        {
            var list = new List<Students>() {

                 new Students{Id=1,Name="Sarwar",Email="sarwar@gmail.com"},
                 new Students{Id=2,Name="mahmud",Email="mahmud@gmail.com"},
                 new Students{Id=3,Name="milon",Email="milon@gmail.com"},
                 new Students{Id=4,Name="farid",Email="farid@gmail.com"},
            };
            return list;
        }

    }
}
