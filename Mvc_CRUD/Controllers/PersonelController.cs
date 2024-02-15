using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using Mvc_CRUD.Context;
using Mvc_CRUD.Models;

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

    [HttpGet]

    public IActionResult Create()
    {
      return View();
    }

    [HttpPost]

    public IActionResult Create(Personel model)
    {
      if (model is null)
        return BadRequest();

      if (!ModelState.IsValid)
        return View(model);

      var data = _dataContext.Personel.FirstOrDefault(t => t.SicilNo== model.SicilNo);
      if(data != null)
      {
        ModelState.AddModelError("SicilNo", "Bu sicil numaralı kayıt zaten mevcut.");
        return View(model);
      }

      _dataContext.Personel.Add(model);
      _dataContext.SaveChanges();

      return RedirectToAction(nameof(Index));             
    }




  }
}
