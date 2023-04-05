namespace CRUDWithDapper.Models
{
    public class Category
    {
        public Category(string title, string url, string summary, string description, int order)
        {
            Id = new Guid();
            Title = title;
            Url = url;
            Summary = summary;
            Description = description;
            Order = order;
            Featured = true;
        }

        //public Category(string title, string url, string summary, string desciption)
        //{
        //    Id = new Guid();
        //    Title = title;
        //    Url = url;
        //    Summary = summary;
        //    Description = desciption;
        //    Featured = true;
        //}
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Summary { get; set; }
        public int Order { get; set; }
        public string Description { get; set; }
        public bool Featured { get; set; }
    }
}
