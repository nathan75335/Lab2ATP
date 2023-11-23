namespace Lab2ATP.Models
{
    public class ProductElements
    {
        public int Id { get; set; }
        public int ElementId { get; set; }
        public Element? Element { get; set; }
        public int ProductId {  get; set; }
        public Product Product { get; set; }
        public int Number {  get; set; }
    }
}
