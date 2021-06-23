using DogoMvc.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;


namespace DogoMvc.Repositories
{
    public interface IWalkerRepository
    {
        List<Walker> GetAllWalkers();
        Walker GetWalkerById(int id);
    }

}
