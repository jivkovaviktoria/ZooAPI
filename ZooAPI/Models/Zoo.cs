using System.ComponentModel.DataAnnotations;

namespace ZooAPI.Models;

public class Zoo
{
    public Zoo()
    {
        this.Animals = new List<Animal>();
    }
    
    [Key]
    public Guid Id { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    [Required]
    public string City { get; set; }
    public virtual IEnumerable<Animal> Animals { get; set; }
}