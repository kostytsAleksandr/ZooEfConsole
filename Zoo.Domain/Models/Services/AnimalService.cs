using System.Collections.Generic;
using Zoo.Data.Models;
using Zoo.Data.Repositories.Interfaces;
using Zoo.Domain.Models;
using Zoo.Domain.Sevices.Interfaces;

namespace Zoo.Domain.Sevices
{
    public class AnimalService : IAnimalService
    {
        private readonly IAnimalsRepository _animalsRepository;

        public AnimalService(IAnimalsRepository animalsRepository)
        {
            _animalsRepository = animalsRepository;
        }

        public AnimalModel Create(AnimalModel model)
        {
            var animal = new Animal 
            {
                Name = model.Name, 
                BreedId = model.BreedId 
            };

            _animalsRepository.Create(animal);

            model.Id = animal.Id;

            return model;
        }

        public IEnumerable<AnimalModel> GetAll()
        {
            var animals = _animalsRepository.GetAll();
            // Create BL instances from DAL instances
            var result = new List<AnimalModel>();

            foreach (var animal in animals)
            {
                result.Add(new AnimalModel
                {
                    Id = animal.Id,
                    BreedId = animal.BreedId,
                    Name = animal.Name
                });
            }

            return result;
        }
    }
}
