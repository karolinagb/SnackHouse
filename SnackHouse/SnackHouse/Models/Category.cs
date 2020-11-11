using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SnackHouse.Models
{
    public class Category
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string CategoryName { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        public ICollection<Snack> Snacks { get; set; }
    }
}
