using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HousePlantClient.Models
{
  public class Plant
  {
    public int PlantId { get; set; }
    public string Name { get; set; }
    public string CommonName { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }
    public string Sunlight { get; set; }
    public string Water { get; set; }
    public string Humidity { get; set; }
    public string Soil { get; set; }
    public string Propagation { get; set; }
    public int TempMin { get; set; }
    public int TempMax { get; set; }

    public static List<Plant> GetPlants()
    {
      var apiCallTask = ApiHelper.GetAll();
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Plant> plantList = JsonConvert.DeserializeObject<List<Plant>>(jsonResponse.ToString());

      return plantList;
    } 

    public static Plant GetDetails(int id)
    {
      var apiCallTask = ApiHelper.Get(id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Plant plant = JsonConvert.DeserializeObject<Plant>(jsonResponse.ToString());

      return plant;
    }

    public static void Post(Plant plant)
    {
      string jsonPlant = JsonConvert.SerializeObject(plant);
      var apiCallTask = ApiHelper.Post(jsonPlant);
    }

    public static void Put(Plant plant)
    {
      string jsonPlant = JsonConvert.SerializeObject(plant);
      var apiCallTask = ApiHelper.Put(plant.PlantId, jsonPlant);
    }

    public static void Delete(int id)
    {
      var apiCallTask = ApiHelper.Delete(id);
    }
  }
}