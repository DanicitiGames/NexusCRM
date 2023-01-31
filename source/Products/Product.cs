using NexusCRM.Providers;

namespace NexusCRM.Products
{
    public class Product
    {
        public int Id { get; private set; }
        //private int uid;
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }
        public string Category { get; private set; }
        public string CreateDate { get; private set; }
        public int Status { get; private set; }
        public string Transport { get; private set; }
        public decimal TransportPrice { get; private set; }
        public string Warranty { get; private set; }
        public Provider[] Providers { get; private set; }
        public Product(int id, string name, decimal price)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
            this.Status = 0;
            this.Providers = new Provider[1];
        }
        public void SetDescription(string text){this.Description = text;}
        public void SetPrice(decimal price){this.Price = price;}
        public void SetQuantity(int quantity){this.Quantity = quantity;}
        public void SetCategory(string category){this.Category = category;}
        public void SetCreateDate(string createDate) { this.CreateDate = createDate;}
        public void SetStatus(int status){this.Status = status;}
        public void SetTransport(string transport){this.Transport = transport;}
        public void SetTransportPrice(decimal transportPrice) { this.TransportPrice = transportPrice;}
        public void SetWarranty(string warranty) { this.Warranty = warranty;}
        public void SetProvider(Provider provider) 
        { 
            Providers = new Provider[]{provider};
            provider.AddProductByProvider(this);
        }
        public void AddProvider(Provider provider) 
        {
            Providers.SetValue(provider, Providers[0] == null ? 0 : Providers.Length);
            provider.AddProductByProvider(this);
        }
        public void AddProviderByProduct(Provider provider)
        {
            Providers.SetValue(provider, Providers[0] == null ? 0 : Providers.Length);
        }
    }
}
