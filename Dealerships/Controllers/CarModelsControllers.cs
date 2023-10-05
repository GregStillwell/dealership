using Microsoft.AspNetCore.Mvc;
using Dealerships.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Dealerships.Controllers
{
  public class CarModelsController : Controller
  {
    private readonly DealershipsContext _db;
    public CarModelsController(DealershipsContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      List<CarModels> carModel = _db.CarModels
                            .Include(carModel => carModel.Makes)
                            .ToList();
      return View(carModel);
    }
    public ActionResult Create()
    {
      ViewBag.MakeId = new SelectList(_db.Makes, "MakeId", "Name");
      return View();
    }
    [HttpPost]
    public ActionResult Create(CarModels carModels)
    {
      if (carModels.CarModelId == 0)
      {
        return RedirectToAction("Create");
      }
      _db.CarModels.Add(carModels);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Details(int id)
    {
      CarModels thisCarModel = _db.CarModels
        .Include(carModel => carModel.Makes)
        .FirstOrDefault(carModel => carModel.CarModelId == id);
      return View(thisCarModel);
    }
    public ActionResult Edit(int id)
    {
      CarModels thisCarModel = _db.CarModels.FirstOrDefault(carModel => carModel.CarModelId == id);
      ViewBag.MakesId = new SelectList(_db.Makes, "MakesId", "Name");
      return View(thisCarModel);
    }
    [HttpPost]
    public ActionResult Edit(CarModels carModel)
    {
      _db.CarModels.Update(carModel);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}