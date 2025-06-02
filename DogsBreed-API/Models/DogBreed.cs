using System.ComponentModel.DataAnnotations;

namespace DogBreeds.Models
{
    public class DogBreed
    {
        [Required(ErrorMessage = "Breed name is required")]
        [StringLength(50, ErrorMessage = "Breed name cannot exceed 50 characters")]
        public string Name { get; set; }
        public List<string> SubBreeds { get; set; } = new List<string>();
    }
}
