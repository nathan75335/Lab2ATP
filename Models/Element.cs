namespace Lab2ATP.Models;

public class Element
{
    public int Id { get; set; }
    public int? GroupId { get; set; }
    public Group? Group { get; set; }        
    public string Name { get; set; }
    public List<ProductElements> ProductElements { get; set; }
}
