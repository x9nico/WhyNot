﻿using System.Data.Entity;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;
using WhyNot.Migrations;
using WhyNot;


public class FileManager
{
    /*public List<Car> LoadJson(string filePath)
    {
        string jsonData = File.ReadAllText(filePath);
        return JsonConvert.DeserializeObject<List<Car>>(jsonData);
    }*/

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


    public static void GenerateJson()
    {
        using (var db = new CarContext())
        {
            // Premièrement, exécutez la requête et récupérez les résultats dans une liste.
            var cars = db.Cars
                .OrderBy(car => car.Model)
                .Select(car => new
                {
                    car.Model,
                    car.carId,
                    car.Make,
                    car.Year
                })
                .ToList(); // Exécution de la requête ici

            // Deuxièmement, construisez le JSON avec les données récupérées.
            JArray carArray = new JArray(
                cars.Select(car => new JObject(
                    new JProperty("model", car.Model),
                    new JProperty("carId", car.carId),
                    new JProperty("make", car.Make),
                    new JProperty("year", car.Year)
                ))
            );

            JObject json = new JObject(
                new JProperty("data", new JObject(
                    new JProperty("item", carArray)
                ))
            );

            Console.WriteLine(json.ToString());
        }
    }


}

