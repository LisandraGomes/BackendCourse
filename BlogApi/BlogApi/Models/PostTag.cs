using Dapper.Contrib.Extensions;

namespace BlogApi.Models
{
    [Table("PostTag")]
    public class PostTag
    {
        public int PostId { get; set; }
        public int TagId { get; set; }
    }
}