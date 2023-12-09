﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DotnetList5Task2.Models.Shop
{
    public class Article
    {
        public Guid Id {  get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        [DisplayName("Expiry Date")]
        public DateOnly ExpiryDate { get; set; }
        public IEnumerable<string> Categories { get; set; } = new List<string>();
    }
}
