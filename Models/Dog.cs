using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogoMvc.Models
{
    public class Dog
    {
        public string Breed { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }
        public string Notes { get; set; }
        public string ImageUrl { get; set; }
        public Owner Owner { get; set; }
        public int OwnderId { get; set; }
    }
}
