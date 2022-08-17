using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HousePlantClient.Models;

namespace HousePlantClient.Controllers
{ 
  public class PlantsController : Controller
  {
    public IActionResult Index()
    {
      var allPlants = Plant.GetPlants();
      return View(allPlants);
    }

    [HttpPost]
    public IActionResult Index(Plant plant)
    {
      Plant.Post(plant);
      return RedirectToAction("Index");
    }
    
    public IActionResult Details(int id)
    {
      var plant = Plant.GetDetails(id);
      return View(plant);
    }

    public IActionResult Edit(int id)
    {
      var plant = Plant.GetDetails(id);
      return View(plant);
    }

    [HttpPost]
    public IActionResult Details(int id, Plant plant)
    {
      plant.PlantId = id ;
      Plant.Put(plant);
      return RedirectToAction("Details", id);
    }

    public IActionResult Delete(int id)
    {
      Plant.Delete(id);
      return RedirectToAction("Index");
    }
  }
}