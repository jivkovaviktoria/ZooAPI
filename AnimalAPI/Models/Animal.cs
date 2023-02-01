using System.ComponentModel.DataAnnotations;

namespace AnimalAPI.Models;

public class Animal
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Color { get; set; }
    public string Type { get; set; }

    public Guid? ZooId { get; set; } 
    public virtual Zoo Zoo { get; set; }
}