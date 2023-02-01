using NexusCRM.Products;
using NexusCRM.Clients;

namespace NexusCRM.Providers
{
    public class Provider:Client
    {
        public List<Product> Products { get; private set; }
        public Provider(int id, string name):base(id, name)
        {
            Products = new List<Product>();
        }
        public void SetProduct(Product product) 
        {
            Products = new List<Product> { product };
            product.AddProviderByProduct(this);
        }
        public void AddProduct(Product product2)
        {
            if (Products.Count > 0)
            {
                if (Products.FirstOrDefault(product => product.Id == product2.Id) != null) { return; }
            }
            Products.Add(product2);
            product2.AddProviderByProduct(this);
        }
        public void AddProductByProvider(Product product)
        {
            Products.Add(product);
        }
        public int CompareTo(Provider other)
        {
            if (other == null) return 1;
            return this.Id.CompareTo(other.Id);
        }
        public new string ToString
        {
            get
            {
                string text = $"ID: {this.Id}\nNome: {this.Name}";
                if (this.Identifier != "") { text += $"\nCPF/CNPJ: {this.Identifier}"; }
                if (this.Address != "") { text += $"\nEndereço: {this.Address}"; }
                if (this.Phone != "") { text += $"\nTelefone:{this.Phone}"; }
                if (this.Email != "") { text += $"\nE-mail: {this.Email}"; }
                if (this.Products[0] != null) 
                { 
                    text += "\nProdutos:"; 
                    for(int i = 0; i < Products.Count; i++)
                    {
                        text += $"\n[{this.Products[i].Name}]({this.Products[i].Id})";
                    }
                }
                return text;
            }
        }
    }
}
