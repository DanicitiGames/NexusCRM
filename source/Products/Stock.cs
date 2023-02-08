namespace NexusCRM.Products
{
    public class Stock:IComparable<Stock>
    {
        public Product Product { get; internal set; }
        public int quantity { get; internal set; }
        public void SetQuantity(int value)
        {
            this.quantity = value;
        }
        public void SetProduct(Product product)
        {
            this.Product = product;
        }
        public string ToString() => $"Produto: {Product.Name}\nID:{Product.Id}\nQuantidade: {quantity}";
        public int CompareTo(Stock other)
        {
            if (other == null) return 1;
            return this.quantity.CompareTo(other.quantity);
        }
    }
}
