using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Data.Entity;
using Newtonsoft.Json.Linq;


public class DataManager
{
    public List<Car> LoadJson(string filePath)
    {
        string jsonData = File.ReadAllText(filePath);
        return JsonConvert.DeserializeObject<List<Car>>(jsonData);
    }

    public List<Car> LoadXml(string filePath)
    {
        var xDocument = XDocument.Load(filePath);
        return xDocument.Descendants("Car")
                        .Select(car => new Car
                        {
                            carId = (int)car.Element("carId"),
                            Make = (string)car.Element("Make"),
                            Model = (string)car.Element("Model"),
                            Year = (int)car.Element("Year")
                        }).ToList();
    }

    public void SaveDataAsXml(List<Car> cars, string filePath)
    {
        var xDocument = new XDocument(
            new XElement("Cars",
                cars.Select(car => new XElement("Car",
                    new XElement("carId", car.carId),
                    new XElement("Make", car.Make),
                    new XElement("Model", car.Model),
                    new XElement("Year", car.Year)
                ))
            )
        );
        xDocument.Save(filePath);
    }

    public void GenerateJson () {
        JObject json = new JObject(
            new JProperty("data",
            new JObject("item",
            new JArray(
                from voiture in car
                orderby voiture.Model
                select new JObject(
                    new JProperty("model", voiture.Model)
                    )
                )
            )
            )
        );
    }

