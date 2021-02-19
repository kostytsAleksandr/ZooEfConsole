using System.Collections.Generic;
using Zoo.Data.Models;
using Zoo.Data.Repositories.Interfaces;

namespace Zoo.Data.Repositories
{
    public class AnimalsListRepository : IAnimalsRepository
    {
        private readonly IList<Animal> _animals;

        public AnimalsListRepository()
        {
            _animals = new List<Animal>();

            for (int i = 0; i < 10; i++)
            {
                _animals.Add(new Animal
                {
                    Id = i,
                    Name = $"Name_{i}",
                    BreedId = i+1,
                });
            }
        }

        public Animal Create(Animal model)
        {
            model.Id = _animals.Count;

            _animals.Add(model);

            return model;
        }

        public IEnumerable<Animal> GetAll()
        {
            return _animals;
        }
    }
}
