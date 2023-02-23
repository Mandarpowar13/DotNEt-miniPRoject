using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoppingApp.Models
{
    public class Category
    {
        [Key]
        public string cat_id { get; set; }

        public string cat_name { get; set; }

        public string cat_desc { get; set;}

        public List<Item> Items { get; set; }

    }
}