using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual Collection<Product>? Products { get; set; }
    }
}
