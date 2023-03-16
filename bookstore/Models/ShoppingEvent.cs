using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bookstore.Models
{
    public class ShoppingEvent
    {
        //get customer info
        [Key]
        [BindNever]

        public int ShoppingEventId { get; set; }

        [BindNever]
        public ICollection<CartLineItem> Lines { get; set; }


        [Required(ErrorMessage = "Please enter a name: ")]

        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter the first address line: ")]

        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }

        public string AddressLine3 { get; set; }


        [Required(ErrorMessage = "Please enter the city: ")]

        public string City { get; set; }



        [Required(ErrorMessage = "Please enter the state: ")]

        public string State { get; set; }

        public string Zip { get; set; }

        [Required(ErrorMessage = "Please enter the country: ")]

        public string Country { get; set; }

        public bool Anonymous { get; set; }



    }
}
