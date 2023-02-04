namespace ZooAPI.Data.Models;

public class Animal : BaseEntity
{
    public string Type { get; set; }
    public string Name { get; set; }
    
    //Navigation properties
    public Guid ZooId { get; set; }
    public Zoo Zoo { get; set; }
}