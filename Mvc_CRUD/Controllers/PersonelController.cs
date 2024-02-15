using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using Mvc_CRUD.Context;
using Mvc_CRUD.Models;
using System.Reflection.Metadata.Ecma335;

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

    [HttpGet]

    public IActionResult Delete(int? id)
    {
      if (id is null)
        return BadRequest();

      var data = _dataContext.Personel.Find(id);
      if (data == null)
        return NotFound();
      return View(data);
    }

    [HttpPost]
    public IActionResult DeleteConfirm(int? id)
    {
      var data = _dataContext.Personel.Find(id);
      _dataContext.Personel.Remove(data);
      _dataContext.SaveChanges();

      return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Edit(int? id)
    {
      if (id is null)
        return BadRequest();

      var data = _dataContext.Personel.Find(id);
      if (data == null)
        return NotFound();
      return View(data);
    }

    [HttpPost]

    public IActionResult Edit(Personel model)
    {
      if (model is null)
        return BadRequest(model);

      if(!ModelState.IsValid)
        return View(model);

      var data = _dataContext.Personel.FirstOrDefault(t => t.SicilNo == model.SicilNo && t.Id != model.Id);
      if (data != null)
      {
        ModelState.AddModelError("SicilNo", "Eklediğiniz sicil numarası zaten mevcut.");
        return View(model);
      }

      data = _dataContext.Personel.FirstOrDefault(t => t.Id == model.Id);

      data.Ad = model.Ad;
      data.Soyad = model.Soyad;
      data.DogumYili= model.DogumYili;
      data.SicilNo = model.SicilNo;
      data.Aktif=model.Aktif;

      _dataContext.Update(data);
      _dataContext.SaveChanges();

      return RedirectToAction(nameof(Index));


    }


  }
}
