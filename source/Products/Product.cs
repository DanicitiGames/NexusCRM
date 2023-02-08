using NexusCRM.Providers;

namespace NexusCRM.Products
{
    public class Product:IComparable<Product>
    {
        public int Id { get; private set; }
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
        public List<Provider> Providers { get; private set; }
        public Product(int id, string name, decimal price)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
            this.Status = 0;
            Providers = new List<Provider>();
        }
        public void SetId(int id) { this.Id = id; }
        public void SetName(string name) { this.Name = name; }
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
            Providers = new List<Provider>{provider};
            provider.AddProductByProvider(this);
        }
        public void AddProvider(Provider provider2) 
        {
            if(Providers.Count != null)
            {
                if (Providers.FirstOrDefault(provider => provider.Id == provider2.Id) != null) { return; }
            }
            Providers.Add(provider2);
            provider2.AddProductByProvider(this);
        }
        public void AddProviderByProduct(Provider provider)
        {
            Providers.Add(provider);
        }
        public int CompareTo(Product other)
        {
            if (other == null) return 1;
            return this.Id.CompareTo(other.Id);
        }
        public new string ToString
        {
            get
            {
                string text = $"ID: {this.Id}" +
                  $"\nNome: {this.Name}" +
                  $"\nValor: R$:{this.Price}";
                if (this.Description != "N/A" && this.Description != "") { text += $"\nDescrição: {this.Description}"; }
                if (this.Category != "N/A" && this.Category != "") { text += $"\nCategoria: {this.Category}"; }
                if (this.Transport != "N/A" && this.Transport != "") { text += $"\nTipo de transporte: {this.Transport}"; }
                if (this.TransportPrice != 0m) { text += $"\nValor de transporte: R$:{this.TransportPrice}"; }
                if (this.Warranty != "N/A" && this.Warranty != "") { text += $"\nGarantia: {this.Warranty}"; }
                if (this.Providers.Count != 0)
                {
                    text += "\nFornecedores:";
                    for (int i = 0; i < Providers.Count; i++)
                    {
                        text += $"\n[{this.Providers[i].Name}]({this.Providers[i].Id})";
                    }
                }
                return text;
            }
        }
    }
}
