using System;
using System.Collections.Generic;
using System.Text;

namespace VideoStreamingShop.Core.Entities
{
    public class Video : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string AgeRate { get; set; }
        public Video() { }
        public Video(string name, string description, decimal price, string ageRate)
        {
            this.Name = name;
            this.Description = description;
            this.Price = price;
            this.AgeRate = ageRate;
        }
    }
}
