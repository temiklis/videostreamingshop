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
        public AgeRating AgeRate { get; set; }
        public List<VideoImage> Images { get; set; }
        public VideoFile LinkedFile { get; set; }

        public bool IsCompleted;
        public Video() { }
        public Video(string name, string description, decimal price, AgeRating ageRate)
        {
            this.Name = name;
            this.Description = description;
            this.Price = price;
            this.AgeRate = ageRate;
        }

        public void RegisterImage(VideoImage image)
        {
            if (Images == null)
                Images = new List<VideoImage>();

            Images.Add(image);
        }
    }
}
