namespace Lab2ATP.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? DepartmentId { get; set; }
    public Department? Department { get; set; }
    public List<ProductElements> ProductElements { get; set; }
}
