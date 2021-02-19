using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Zoo.Data.Models;
using Zoo.Data.Repositories.Interfaces;

namespace Zoo.Data.Repositories
{
    public class AnimalDapperRepository : IAnimalsRepository
    {
        private const string CONNECTION_STRING = "Data Source=.;Initial Catalog=Zoo;Integrated Security=True";

        public Animal Create(Animal model)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                var queryString = $"INSERT INTO Animals(Name,BreedId) OUTPUT INSERTED.id VALUES(\'{model.Name}\',{model.BreedId})";

                var insertedId = connection.ExecuteScalar(queryString);
                var insertedIdInt = Convert.ToInt32(insertedId);
                model.Id = insertedIdInt;

                return model;
            }
        }

        public IEnumerable<Animal> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                return connection.Query<Animal>("SELECT * FROM Animals");
            }
        }
    }
}
