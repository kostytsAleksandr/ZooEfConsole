using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Zoo.Data.Models;
using Zoo.Data.Repositories.Interfaces;

namespace Zoo.Data.Repositories
{
    public class AnimalsAdoNetRepository : IAnimalsRepository
    {
        private const string CONNECTION_STRING = "Data Source=.;Initial Catalog=Zoo;Integrated Security=True";

        public Animal Create(Animal model)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                var queryString = "INSERT INTO Animals(Name,BreedId) OUTPUT INSERTED.id VALUES(@Name,@BreedId)";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@Name", model.Name);
                command.Parameters.AddWithValue("@BreedId", model.BreedId);


                connection.Open();

                var animalId = command.ExecuteScalar();

                var animalIdInt = Convert.ToInt32(animalId);
                model.Id = animalIdInt;

                return model;
            }
        }

        public IEnumerable<Animal> GetAll()
        {
            var result = new List<Animal>();

            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                var queryString = "SELECT * FROM Animals";
                SqlCommand command = new SqlCommand(queryString, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(new Animal
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        BreedId = reader.GetInt32(2)
                    });
                }
                reader.Close();

                return result;
            }
        }


    }
}
