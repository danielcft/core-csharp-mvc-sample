using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoMVC.Models;

namespace TodoMVC.Controllers
{
    public class HomeController : Controller
    {
     private AppDbContext _db;

     public HomeController(AppDbContext db)
     {
        _db = db;
     }

    public IActionResult Index()
    {
      return View(_db.Todo.ToList());
    }

     public IActionResult CreateTodo()
      {
        return View(new Todo());
      }

      public async Task<IActionResult> CreateTodoPost(Todo todo)
      {
        _db.Todo.Add(todo);
        await _db.SaveChangesAsync();
        return RedirectToAction("Index");
      }

      public async Task<IActionResult> DeleteTodo(int id)
      {
        Todo todo = _db.Todo.First(t => t.Id == id);
        _db.Todo.Remove(todo);
        await _db.SaveChangesAsync();

      return RedirectToAction("Index");
      }

    public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
