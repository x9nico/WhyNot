
/*var manager = new DataManager();
var carsFromJson = manager.LoadJson(@"JsonData.json");
var carsFromXml = manager.LoadXml(@"XmlData.xml");

// Exemple de tri des voitures par année
var sortedCars = carsFromJson.OrderBy(car => car.Year).ToList();

// Exemple de filtrage des voitures par année
var recentCars = carsFromJson.Where(car => car.Year > 2010).ToList();

// Sauvegarder les données JSON transformées en XML
manager.SaveDataAsXml(sortedCars, @"SortedCars.xml");*/

FileManager.GenerateJson();
//FileManager.JsonQuery.QueryJson();
FileManager.XmlQuery.QueryXml();

Console.ReadLine();

public class Car
{
    public int carId {  get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
}




