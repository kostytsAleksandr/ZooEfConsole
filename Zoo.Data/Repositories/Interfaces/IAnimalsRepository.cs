using System.Collections.Generic;
using Zoo.Data.Models;

namespace Zoo.Data.Repositories.Interfaces
{
    public interface IAnimalsRepository
    {
        IEnumerable<Animal> GetAll();
        Animal Create(Animal model);
    }
}
