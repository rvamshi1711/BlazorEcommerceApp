using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BlazorEcommerceApp.Components.Pages;

namespace BlazorEcommerceApp.Data
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Category name is required.")]
        public string Name { get; set; } = string.Empty;
    }
}