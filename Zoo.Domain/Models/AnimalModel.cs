namespace Zoo.Domain.Models
{
    public class AnimalModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BreedId { get; set; }

        public BreedModel Breed { get; set; }
    }
}
