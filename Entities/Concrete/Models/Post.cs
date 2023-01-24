using Core.Entities;

namespace Entites.Concrete.Models
{
    public class Post:IEntity
    {
        public int Id { get; set; }
        public string  Title { get; set; }
        public string  Description { get; set; }
        public string Image { get;set; }

    }
}
