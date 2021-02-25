namespace VideoStreamingShop.Core.Entities
{
    public class VideoImage : Entity
    {
        public string Name { get; set; }
        public string Uri { get; set; }

        public VideoImage(string name, string uri)
        {
            this.Name = name;
            this.Uri = uri;
        }
    }
}