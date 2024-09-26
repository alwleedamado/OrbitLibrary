﻿namespace OrbitLibrary.Data.Entities
{
    public class BookAuthors
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public Book Book { get; set; }
    }
}
