namespace Zoo.Data.Models
{
    public class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int BreedId { get; set; }
        public Breed Breed { get; set; }
    }
}
