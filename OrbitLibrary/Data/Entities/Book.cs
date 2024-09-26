namespace OrbitLibrary.Data.Entities
{
    public class Book : Entity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<BookAuthors> Authors { get; set; }  
    }
}
