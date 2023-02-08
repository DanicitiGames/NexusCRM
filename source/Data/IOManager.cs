using NexusCRM.Providers;
using NexusCRM.Clients;
using NexusCRM.Products;
using System.Collections;

namespace NexusCRM.Data
{
    internal class IOManager
    {
        public List<Product> productsList = new();
        public List<Provider> providerList = new();
        public List<Client> clientList = new();
        public List<Stock> stockList = new();
        public ArrayList Import(int type)
        {
            ArrayList data = new();
            switch(type)
            {
                case 0:
                    foreach(Product product in productsList)
                    {
                        data.Add(product);
                    }
                    break;
                case 1:
                    foreach(Provider provider in providerList)
                    {
                        data.Add(provider);
                    }
                    break;
                case 2:
                    foreach(Client client in clientList)
                    {
                        data.Add(client);
                    }
                    break;
                case 3:
                    foreach(Stock stock in stockList)
                    {
                        data.Add(stock);
                    }
                    break;
            }
            return data;
        }
        public void Start()
        {
            CheckFiles();
            GetData(0);
            GetData(2);
            GetData(3);
            GetData(1);
        }
        public void SaveData(ArrayList list)
        {
            switch (list[0].GetType().Name)
            {
                case "Product":
                    productsList.Clear();
                    CleanData(2);
                    foreach (Product product in list)
                    {
                        productsList.Add(product);
                        AddData(2,new string[] { 
                            product.Id.ToString(), 
                            product.Price.ToString(), 
                            product.TransportPrice.ToString(), 
                            product.Name, 
                            product.Description,
                            product.Category,
                            product.Transport,
                            product.Warranty
                        });
                    }
                    break;
                case "Provider":
                    providerList.Clear();
                    CleanData(1);
                    foreach (Provider provider in list)
                    {
                        providerList.Add(provider);
                        AddData(1, new string[] { provider.Id.ToString(), provider.Name, provider.Identifier, provider.Address, provider.Phone, provider.Email, provider.ProductsToString });
                    }
                    break;
                case "Client":
                    clientList.Clear();
                    CleanData(0);
                    foreach (Client client in list)
                    {
                        clientList.Add(client);
                        AddData(0, new string[] { client.Id.ToString(), client.Name, client.Identifier, client.Address, client.Phone, client.Email});
                    }
                    break;
                case "Stock":
                    stockList.Clear();
                    CleanData(3);
                    foreach(Stock stock in list)
                    {
                        stockList.Add(stock);
                        AddData(3, new string[] { stock.Product.Id.ToString(), stock.quantity.ToString()});
                    }
                    break;
            }
        }
        public bool AddData(int type, string[] values)
        {
            try
            {
                string[] FilePath = new string[] { "./data/clients.csv", "./data/providers.csv", "./data/products.csv", "./data/stock.csv" };
                int byteCount = File.ReadAllBytes(FilePath[type]).Length;
                using (var fs = new FileStream(FilePath[type], FileMode.Open))
                using (var writer = new BinaryWriter(fs))
                {
                    writer.Seek(byteCount, SeekOrigin.Begin);
                    switch (type)
                    {
                        case 0:
                            writer.Write(int.Parse(values[0]));
                            for (int i = 1; i < 6; i++)
                            {
                                writer.Write(values[i]);
                            }
                            break;
                        case 1:
                            writer.Write(int.Parse(values[0]));
                            for (int i = 1; i < 7; i++)
                            {
                                writer.Write(values[i]);
                            }
                            break;
                        case 2:
                            writer.Write(int.Parse(values[0]));
                            for(int i = 1; i < 8; i++)
                            {
                                writer.Write(values[i]);
                            }
                            break;
                        case 3:
                            writer.Write(int.Parse(values[0]));
                            writer.Write(int.Parse(values[1]));
                            break;
                    }
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public void CleanData(int type)
        {
            string[] FilePath = new string[] { "./data/clients.csv", "./data/providers.csv", "./data/products.csv", "./data/stock.csv" };
            try
            {
                File.WriteAllText(FilePath[type],"");
            }
            catch {}
        }
        public ArrayList GetData(int type)
        {
            try
            {
            string[] FilePath = new string[] { "./data/clients.csv", "./data/providers.csv", "./data/products.csv", "./data/stock.csv" };
            int lines = File.ReadAllLines(FilePath[type]).Length;
            using (var fs = new FileStream(FilePath[type], FileMode.Open))
            using (var reader = new BinaryReader(fs))
            {
                ArrayList data = new();
                bool finish = false;
                switch(type)
                    {
                        case 0:
                            while (!finish)
                            {
                                try
                                {
                                    Client client = new(reader.ReadInt32(),reader.ReadString());
                                    client.SetIdentifier(reader.ReadString());
                                    client.SetAddress(reader.ReadString());
                                    client.SetPhone(reader.ReadString());
                                    client.SetEmail(reader.ReadString());
                                    List<Client> clientClone = clientList.FindAll(clientV => clientV.Id == client.Id);
                                    if (clientClone.Count != 0)
                                    {
                                        for(int i = 0; i < clientClone.Count; i++)
                                        {
                                            clientList.Remove(clientClone[i]);
                                            data.Remove(clientClone[i]);
                                        }
                                    }
                                    clientList.Add(client);
                                    data.Add(client);
                                }
                                catch
                                {
                                    finish = true;
                                }
                            }
                            break;
                        case 1:
                            while (!finish)
                            {
                                try
                                {
                                    Provider provider = new(reader.ReadInt32(), reader.ReadString());
                                    provider.SetIdentifier(reader.ReadString());
                                    provider.SetAddress(reader.ReadString());
                                    provider.SetPhone(reader.ReadString());
                                    provider.SetEmail(reader.ReadString());
                                    provider.ProductsByString(reader.ReadString(), productsList);
                                    providerList.Add(provider);
                                    data.Add(provider);
                                }
                                catch
                                {
                                    finish = true;
                                }
                            }
                            break;
                        case 2:
                            while (!finish)
                            {
                                try
                                {
                                    int id = reader.ReadInt32();
                                    string[] values = { reader.ReadString(), reader.ReadString() };
                                    Product product = new(id, reader.ReadString(), decimal.Parse(values[0]));
                                    product.SetTransportPrice(decimal.Parse(values[1]));
                                    product.SetDescription(reader.ReadString()); 
                                    product.SetCategory(reader.ReadString());
                                    product.SetTransport(reader.ReadString()); 
                                    product.SetWarranty(reader.ReadString());
                                    productsList.Add(product);
                                    data.Add(product);
                                }
                                catch
                                {
                                    finish = true;
                                }
                            }
                            break;
                        case 3:
                            while (!finish)
                            {
                                try
                                {
                                    Product product = productsList.FirstOrDefault(product => product.Id == reader.ReadInt32());
                                    Stock stock = new();
                                    stock.SetProduct(product);
                                    stock.SetQuantity(reader.ReadInt32());
                                    stockList.Add(stock);
                                    data.Add(stock);
                                }
                                catch
                                {
                                    finish = true;
                                }
                            }
                            break;
                    }
                    return data;
            }
            }
            catch
            {
                return null;
            }
        }
        public void CheckFiles()
        {
            string[] FilePath = new string[] { "./data/clients.csv", "./data/providers.csv", "./data/products.csv", "./data/stock.csv" };
            for(int i = 0; i < FilePath.Length; i++)
            {
                if (!File.Exists(FilePath[i])){ File.Create(FilePath[i]); }
            }
        }
    }
}
