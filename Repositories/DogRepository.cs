using DogoMvc.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogoMvc.Repositories
{
    public class DogRepository : IDogRepository
    {
        private readonly IConfiguration _config;
        private readonly IOwnerRepository _ownerRepository;
        public SqlConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }
        public DogRepository(IConfiguration config)
        {
            _config = config;
            _ownerRepository = new OwnerRepository(config);
        }
        public void AddDog(Dog dog)
        {
            throw new NotImplementedException();
        }

        public void DeleteDogById(int id)
        {
            throw new NotImplementedException();
        }

        public Dog GetDogById(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT Name, Breed, Id, OwnerId, ImageUrl, Notes
                                        FROM Dog;";
                    cmd.Parameters.AddWithValue("Id", id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    Dog dog = null;
                    while (reader.Read())
                    {
                        dog = new Dog()
                        {
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            Breed = reader.GetString(reader.GetOrdinal("Breed")),
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            ImageUrl = reader.IsDBNull(reader.GetOrdinal("ImageUrl")) ? null : reader.GetString(reader.GetOrdinal("ImageUrl")),
                            Owner = _ownerRepository.GetOwner(reader.GetInt32(reader.GetOrdinal("Id"))),
                            Notes = reader.IsDBNull(reader.GetOrdinal("Notes")) ? null : reader.GetString(reader.GetOrdinal("Notes")),
                        };
                    }
                    return dog;
                }
            }
        }

        public List<Dog> GetDogs()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                List<Dog> dogs = new List<Dog>();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT Name, Breed, Id, OwnerId, ImageUrl, Notes
                                        FROM Dog;";
                    SqlDataReader reader = cmd.ExecuteReader();

                    Dog dog = null;
                    while (reader.Read())
                    {
                        dog = new Dog()
                        {
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            Breed = reader.GetString(reader.GetOrdinal("Breed")),
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            ImageUrl =reader.IsDBNull(reader.GetOrdinal("ImageUrl"))?null: reader.GetString(reader.GetOrdinal("ImageUrl")),
                            Owner = _ownerRepository.GetOwner(reader.GetInt32(reader.GetOrdinal("Id"))),
                            Notes = reader.IsDBNull(reader.GetOrdinal("Notes"))?null : reader.GetString(reader.GetOrdinal("Notes")),
                        };
                        dogs.Add(dog);
                    }
                    return dogs;
                }
            }
        }

        public void UdpateDog(Dog dog)
        {
            throw new NotImplementedException();
        }

        public List<Dog> GetDogsByOwnerId(int ownerId)
        {
            throw new NotImplementedException();
        }
    }
}
