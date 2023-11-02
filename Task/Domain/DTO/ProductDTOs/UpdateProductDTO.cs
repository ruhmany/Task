using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.ProductDTOs
{
    public class UpdateProductDTO
    {
        public string ProductName { get; set;}
        public double Price { get; set; }
        public int ID { get; set; }
        public string CategoryName { get; set; }
    }
}
