namespace WebApiSample.Models
{
    public class StockItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } =  string.Empty;    
        public DateTime CreatedDate { get; set; }
        public string Image { get; set; } = string.Empty;  
        public int Qty { get; set; }
    }
}
