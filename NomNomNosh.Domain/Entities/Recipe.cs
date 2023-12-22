namespace NomNomNosh.Domain.Entities
{
    public class Recipe
    {
        public Guid Recipe_Id { get; set; }
        public Guid Member_Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Published_Date { get; set; }
        public string Main_Image { get; set; }
        public decimal Average_Rating { get; set; }
    }
}