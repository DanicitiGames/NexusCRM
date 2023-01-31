using NexusCRM.Products;

namespace NexusCRM.Providers
{
    public class Provider
    {
        public int Id { get; private set; }
        //private int uid;
        public string Name { get; private set; }
        public string Identifier { get; private set; }
        public string Address { get; private set; }
        public string Phone { get; private set; }
        public string Email { get; private set; }
        public string CreateDate { get; private set; }
        public int Status { get; private set; }
        public Product[] Products { get; private set; }
        public Provider(int id, string name)
        {
            this.Id = id;
            this.Name = name;
            this.Status = 0;
            this.Products = new Product[1];
        }
        public void SetName(string name) { this.Name = name; }
        public void SetIdentifier(string identifier) { this.Identifier = identifier;}
        public void SetAddress(string address) { this.Address = address; }
        public void SetPhone(string phone) { this.Phone = phone; }
        public void SetEmail(string email) { this.Email = email; }
        public void SetCreateDate(string createDate) { this.CreateDate = createDate; }
        public void SetStatus(int status) { this.Status = status; }
        public void SetProduct(Product product) 
        {
            Products = new Product[] { product };
            product.AddProviderByProduct(this);
        }
        public void AddProduct(Product product)
        {
            Products.SetValue(product, Products[0] == null ? 0 : Products.Length);
            product.AddProviderByProduct(this);
        }
        public void AddProductByProvider(Product product)
        {
            Products.SetValue(product, Products[0] == null ? 0 : Products.Length);
        }
    }
}
