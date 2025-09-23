using Microsoft.AspNetCore.Mvc;
using MVCSession2.Models;
using System.Xml.Linq;

namespace MVCSession2.Controllers
{
    public class MoviesController : Controller
    {
        //public string Index(int? id, string name)
        //{
        //    return $"Id :: {id} Name :: {name}";
        //}

        public string Index() {
            return $"Hello From Index";
        }
        #region Example 1
        //Get BaseUrl/Movies/GetMovie?id=10&name=filmname
        //[HttpGet]
        //public ContentResult GetMovie(int? id, string name)
        //{
        //    //ContentResult result = new ContentResult();
        //    //result.Content = $"Movie:: {id} </br> {name}";
        //    //result.ContentType = "text/html";
        //    //result.StatusCode = 700;
        //    //return result;
        //    return Content($"Movie:: {id} </br> {name}", "text/html");

        //} 
        #endregion

        [HttpGet]
        public IActionResult GetMovie(int? id, string name)
        {
            //if id=0> Bad Request
            //id < 10 -> NotFound
            //id >= 10 -> Return Data
            if (id == 0)
                return BadRequest();
            else if (id < 10)
                return NotFound();
            else
                return Content($"Movie With Name: {name},, Id: {id}");
        }

        //Get BaseUrl/Movies/TestRedirectToAction
        [HttpGet]

        public IActionResult TestRedirectToAction()
        {
            //return RedirectToAction("GetMovie");
            //return RedirectToAction(nameof(GetMovie), "Movies", new { id = 15, name = "test"});
            return RedirectToRoute("Default", new { Controller = "Movies", Action = "GetMovie", id = 16, name = "test" });
            //return Redirect("https://www.youtube.com/");
        }

        [HttpPost]
        public IActionResult TestModelBindeing([FromRoute] int id, [FromQuery] string name)
        {
            return Content($"Hello {name} your id is {id}");
        }


        [HttpGet]

        //public IActionResult AddMovie(string Title, Movie movie, int Id)
        //{
        //    //if(movie is null) return BadRequest();
        //    //else
        //    return Content($"Hello {movie.Title} your id is {movie.Id}");
        //}
        
        //public IActionResult AddMovie(int[] arr)
        //{
        //    return Content($"Hello {arr[0]} your id is {arr[1]}");
        //}

        public IActionResult AddMovie(string Title, Movie movie, int Id, int[] arr)
        {
            return Content($"Hello {arr[0]} your id is {arr[1]}");

        }
    }
}
    
