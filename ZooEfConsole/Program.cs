using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo.Controllers;
using Zoo.Data.Repositories;
using Zoo.Domain.Sevices;
using Zoo.Models;

namespace ZooEfConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var repository = new AnimalsEFRepository();
            var service = new AnimalService(repository);
            var controller = new AnimalsController(service);

            var animalPostModel = new AnimalPostModel { Name = "Puzo EntityFramework32", BreedId = 1 };

            controller.Create(animalPostModel);

            var animals = controller.GetAll();
        }
    }
}
