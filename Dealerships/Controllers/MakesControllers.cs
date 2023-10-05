using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Dealership.Models;
using System.Collections.Generic;
using System.Linq;

namespace Dealership.Controllers
{
  public class MakesController : Controller
  {
    private readonly DealershipContext _db;

    public MakesController(DealershipContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Makes> model = _db.Makes.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Makes make)
    {
      _db.Makes.Add(make);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Makes thisMake = _db.Makes
                                  .Include(make => make.CarModels)
                                  .FirstOrDefault(make => make.MakeId == id);
      return View(thisMake);
    }

    public ActionResult Edit(int id)
    {
      Makes thisMake = _db.Makes.FirstOrDefault(make => make.MakeId == id);
      return View(thisMake);
    }

    [HttpPost]
    public ActionResult Edit(Makes make)
    {
      _db.Makes.Update(make);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Makes thisMake = _db.Makes.FirstOrDefault(make => make.MakeId == id);
      return View(thisMake);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Makes thisMake = _db.Makes.FirstOrDefault(make => make.MakeId == id);
      _db.Makes.Remove(thisMake);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}