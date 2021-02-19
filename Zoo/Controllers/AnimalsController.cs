using System.Collections.Generic;
using Zoo.Domain.Models;
using Zoo.Domain.Sevices.Interfaces;
using Zoo.Models;

namespace Zoo.Controllers
{
    public class AnimalsController
    {
        private readonly IAnimalService _animalService;

        public AnimalsController(IAnimalService animalService)
        {
            _animalService = animalService;
        }

        public IEnumerable<AnimalViewModel> GetAll()
        {
            var animals = _animalService.GetAll();

            var result = new List<AnimalViewModel>();

            foreach (var animal in animals)
            {
                result.Add(new AnimalViewModel
                {
                    Id = animal.Id,
                    Name = animal.Name,
                    Breed = animal.Breed.Name,
                    Type = "Unknown"
                });
            }

            return result;
        }

        public AnimalViewModel Create(AnimalPostModel model)
        {
            var animalModel = new AnimalModel
            {
                Name = model.Name,
                BreedId = model.BreedId
            };

            var createResult = _animalService.Create(animalModel);

            var result = new AnimalViewModel
            {
                Id = createResult.Id,
                Name = createResult.Name,
                Breed = "Unknown"
            };

            return result;
        }

        //GetByNameStartsWith(string stratWith)
        //_animalService.GetByNameStartsWith(string)

        //AnimalFormModel
        //AnimalPostModel
    }
}
