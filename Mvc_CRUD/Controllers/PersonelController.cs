using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using Mvc_CRUD.Context;

namespace Mvc_CRUD.Controllers
{
  public class PersonelController : Controller
  {
    private readonly DataContext _dataContext;

    public PersonelController(DataContext dataContext)
    {
      _dataContext = dataContext;
    }

    public IActionResult Index()
    {
      var data = _dataContext.Personel.ToList();
      return View(data);
    }


  }
}
