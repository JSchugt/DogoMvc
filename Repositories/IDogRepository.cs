using DogoMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogoMvc.Repositories
{
    public interface IDogRepository
    {
        List<Dog> GetDogs();
        Dog GetDogById(int id);
        void AddDog(Dog dog);

        void DeleteDogById(int id);

        void UdpateDog(Dog dog);
        List<Dog> GetDogsByOwnerId(int ownerId);

    }

}
