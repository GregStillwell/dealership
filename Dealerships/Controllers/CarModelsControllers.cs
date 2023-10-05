using Microsoft.AspNetCore.Mvc;
using Dealership.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Dealership.Controllers
{
  public class CarModelsController : Controller
  {
    private readonly DealershipContext _db;
    public CarModelsController(DealershipContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      List<CarModels> model = _db.CarModels
                            .Include(model => model.Makes)
                            .ToList();
      return View(model);
    }
    public ActionResult Create()
    {
      ViewBag.MakeId = new SelectList(_db.Makes, "MakeId", "Name");
      return View();
    }
    [HttpPost]
    public ActionResult Create(Makes makes)
    {
      if (model.MakeId == 0)
      {
        return RedirectToAction("Create");
      }
      _db.Models.Add(model);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Details(int id)
    {
      Models thisCarModel = _db.CarModels
        .Include(model => model.Makes)
        .FirstOrDefault(model => model.CarModelId == id);
      return View(thisCarModel);
    }
    public ActionResult Edit(int id)
    {
      CarModels thisCarModel = _db.CarModels.FirstOrDefault(model => model.ModelId == id);
      ViewBag.MakesId = new SelectList(_db.Makes, "MakesId", "Name");
      return View(thisCarModel);
    }
    [HttpPost]
    public ActionResult Edit(CarModels model)
    {
      _db.CarModels.Update(model);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}