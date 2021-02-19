using System.Collections.Generic;
using Zoo.Data.Models;
using Zoo.Data.Repositories.Interfaces;
using System.Linq;

namespace Zoo.Data.Repositories
{
    public class AnimalsEFRepository : IAnimalsRepository
    {
        //private const string CONNECTION_STRING = "Data Source=.;Initial Catalog=Zoo;Integrated Security=True";

        public AnimalsEFRepository()
        {
        }

        public Animal Create(Animal model)
        {
            using (var ctx = new ZooContext("Default"))
            {

                model.Breed = new Breed() { Name = "SuperBreed" };
                model.BreedId = 0;

                ctx.Animals.Add(model);
                ctx.SaveChanges();
            };

            return model;
        }

        public IEnumerable<Animal> GetAll()
        {
            using (var ctx = new ZooContext("Default"))
            {
                return ctx.Animals.ToList();
            };
        }
    }
}
