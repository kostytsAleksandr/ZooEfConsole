using System.Collections.Generic;
using Zoo.Domain.Models;

namespace Zoo.Domain.Sevices.Interfaces
{
    public interface IAnimalService
    {
        IEnumerable<AnimalModel> GetAll();
        AnimalModel Create(AnimalModel model);
    }
}
