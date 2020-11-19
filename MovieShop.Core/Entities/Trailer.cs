namespace MovieShop.Core.Entities
{
    public class Trailer
    {
        public int Id { get; set; }
        
        //Foreign Key from movie table which is Id as PK there
        public int MovieId { get; set; }
        public string TrailerUrl { get; set; }
        public string Name { get; set; }
        
        //Navigation propertites, it help us navigate to related entities.
        public Movie Movie { get; set; }
    }
}