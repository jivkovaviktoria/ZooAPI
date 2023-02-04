namespace ZooAPI.Data.Models;

public class Zoo : BaseEntity
{
    public Zoo()
    {
        this.Animals = new List<Animal>();
    }
    public string Name { get; set; }
    public string Location { get; set; }
    
    //Navigation properties
    public ICollection<Animal> Animals { get; set; }
}