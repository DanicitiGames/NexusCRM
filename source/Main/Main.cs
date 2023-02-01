using NexusCRM.Products;
using NexusCRM.Providers;
using NexusCRM.Clients;

namespace NexusCRM.Main
{
    internal class Main
    {
        private List<Product> productsList = new();
        private List<Provider> providerList = new();
        private List<Client> clientList = new();
        private List<Stock> stockList = new();
        public void Start()
        {
            char option = '0';
            while (option != '5')
            {
                option = '0';
                Console.Clear();
                Console.WriteLine("--------------------------------");
                Console.WriteLine("--          NexusCRM          --");
                Console.WriteLine("--1. Gerenciador Produtos     --");
                Console.WriteLine("--2. Gerenciador Fornecedores --");
                Console.WriteLine("--3. Gerenciador Clientes     --");
                Console.WriteLine("--4. Gerenciador Estoque      --");
                Console.WriteLine("--5. Sair do Sistema          --");
                Console.WriteLine("--------------------------------\n");
                Console.Write("Digite a opção desejada: ");
                try { option = char.Parse(Console.ReadLine()); } catch { }
                switch (option)
                {
                    case '1':
                        ProductManager();
                        break;
                    case '2':
                        ProviderManager();
                        break;
                    case '3':
                        ClientManager();
                        break;
                    case '4':
                        StockManager();
                        break;
                    default:
                        break;
                }
            }
        }
        void ProductManager()
        {
            char option = '0';
            while (option != '7')
            {
                option = '0';
                Console.Clear();
                Console.WriteLine("--------------------------------");
                Console.WriteLine("--  Gerenciador de produtos   --");
                Console.WriteLine("--1. Adicionar produto        --");
                Console.WriteLine("--2. Remover produto          --");
                Console.WriteLine("--3. Listar produtos          --");
                Console.WriteLine("--4. Editar produto           --");
                Console.WriteLine("--5. Buscar produto           --");
                Console.WriteLine("--6. Atribuir fornecedor      --");
                Console.WriteLine("--7. Voltar                   --");
                Console.WriteLine("--------------------------------\n");
                Console.Write("Digite a opção desejada: ");
                try { option = char.Parse(Console.ReadLine()); } catch { }
                switch (option)
                {
                    case '1':
                        RegisterProduct();
                        break;
                    case '2':
                        RemoveProduct();
                        break;
                    case '3':
                        ListProduct();
                        break;
                    case '4':
                        EditProduct();
                        break;
                    case '5':
                        SearchProduct();
                        break;
                    case '6':
                        AssignProviderToProduct();
                        break;
                    default:
                        break;
                }
            }
        }
        void ProviderManager()
        {
            char option = '0';
            while (option != '7')
            {
                option = '0';
                Console.Clear();
                Console.WriteLine("---------------------------------");
                Console.WriteLine("-- Gerenciador de Fornecedores --");
                Console.WriteLine("--1. Adicionar fornecedor      --");
                Console.WriteLine("--2. Remover fornecedor        --");
                Console.WriteLine("--3. Listar fornecedores       --");
                Console.WriteLine("--4. Editar fornecedor         --");
                Console.WriteLine("--5. Buscar fornecedor         --");
                Console.WriteLine("--6. Atribuir produto          --");
                Console.WriteLine("--7. Voltar                    --");
                Console.WriteLine("---------------------------------\n");
                Console.Write("Digite a opção desejada: ");
                try { option = char.Parse(Console.ReadLine()); } catch { }
                switch (option)
                {
                    case '1':
                        RegisterProvider();
                        break;
                    case '2':
                        RemoveProvider();
                        break;
                    case '3':
                        ListProvider();
                        break;
                    case '4':
                        EditProvider();
                        break;
                    case '5':
                        SearchProvider();
                        break;
                    case '6':
                        AssignProviderToProduct();
                        break;
                    default:
                        break;
                }
            }
        }
        void ClientManager()
        {
            char option = '0';
            while (option != '6')
            {
                option = '0';
                Console.Clear();
                Console.WriteLine("-------------------------------");
                Console.WriteLine("--  Gerenciador de Clientes  --");
                Console.WriteLine("--1. Adicionar cliente       --");
                Console.WriteLine("--2. Remover cliente         --");
                Console.WriteLine("--3. Listar clientes         --");
                Console.WriteLine("--4. Editar cliente          --");
                Console.WriteLine("--5. Buscar cliente          --");
                Console.WriteLine("--6. Voltar                  --");
                Console.WriteLine("-------------------------------\n");
                Console.Write("Digite a opção desejada: ");
                try { option = char.Parse(Console.ReadLine()); } catch { }
                switch (option)
                {
                    case '1':
                        RegisterClient();
                        break;
                    case '2':
                        RemoveClient();
                        break;
                    case '3':
                        ListClient();
                        break;
                    case '4':
                        EditClient();
                        break;
                    case '5':
                        SearchClient();
                        break;
                    default:
                        break;
                }
            }
        }
        void StockManager()
        {
            char option = '0';
            while (option != '5')
            {
                option = '0';
                Console.Clear();
                Console.WriteLine("------------------------------");
                Console.WriteLine("--  Gerenciador de Estoque  --");
                Console.WriteLine("--1. Adicionar produto      --");
                Console.WriteLine("--2. Listar estoque         --");
                Console.WriteLine("--3. Alterar quantidade     --");
                Console.WriteLine("--4. Remover produto        --");
                Console.WriteLine("--5. Voltar                 --");
                Console.WriteLine("-------------------------------\n");
                Console.Write("Digite a opção desejada: ");
                try { option = char.Parse(Console.ReadLine()); } catch { }
                switch (option)
                {
                    case '1':
                        StockAdd();
                        break;
                    case '2':
                        StockList();
                        break;
                    case '3':
                        StockQuantity();
                        break;
                    case '4':
                        RemoveStock();
                        break;
                    default:
                        break;
                }
            }
        }
        void RegisterProduct()
        {
            int id = 0;
            string name = "";
            decimal price = -1m;
            string category = null;
            string transport = null;
            decimal transportPrice;
            string warranty = null;
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("--  Cadastro de Produto  --");
            Console.WriteLine("---------------------------\n");
            Console.WriteLine("->Informe dados do produto:");
            while (id == 0)
            {
                Console.Write("*ID: ");
                int VerifyID;
                try { 
                    VerifyID = int.Parse(Console.ReadLine());
                    if(VerifyID > 0 && ConsultProductValidID(VerifyID))
                    {
                        id = VerifyID;
                    };
                } catch { }
            }
            while (name == "")
            {
                Console.Write("*Nome do produto: ");
                try { name = Console.ReadLine(); }
                catch { }
            }
            while (price < 0)
            {
                Console.Write("*Valor: ");
                try { price = decimal.Parse(Console.ReadLine()); }
                catch { }
            }
            Console.Write("Categoria: ");
            try { category = "" + Console.ReadLine(); }
            catch { }
            Console.Write("Tipo de transporte: ");
            try { transport = "" + Console.ReadLine(); }
            catch { }
            Console.Write("Valor transporte: ");
            transportPrice = 0m;
            try { transportPrice = decimal.Parse(Console.ReadLine()); }
            catch { }
            Console.Write("Garantia: ");
            try { warranty = "" + Console.ReadLine(); }
            catch { };
            Product product = new(id, name, price);
            product.SetCategory(category);
            product.SetTransport(transport);
            product.SetTransportPrice(transportPrice);
            product.SetWarranty(warranty);
            productsList.Add(product);
            Console.WriteLine("Produto cadastrado com sucesso!");
            Console.ReadKey();
        }
        void RegisterProvider()
        {
            int id = 0;
            string name = "";
            string identifier = "";
            string adress = "";
            string phone = "";
            string email = "";
            Console.Clear();
            Console.WriteLine("----------------------------");
            Console.WriteLine("-- Cadastro de Fornecedor --");
            Console.WriteLine("----------------------------\n");
            Console.WriteLine("->Informe dados do fornecedor:");
            while(id == 0)
            {
                Console.Write("*ID: ");
                int VerifyID;
                try
                {
                    VerifyID = int.Parse(Console.ReadLine());
                    if (VerifyID > 0 && ConsultProviderValidID(VerifyID))
                    {
                        id = VerifyID;
                    };
                } catch { }
            }
            while(name == "")
            {
                Console.Write("*Nome: ");
                string VerifyName;
                try
                {
                    VerifyName = Console.ReadLine();
                    if(VerifyName != "" && VerifyName != null)
                    {
                        name = VerifyName;
                    }
                } catch { }
            }
            Console.Write("CPF/CNPJ: "); try{ identifier = ""+Console.ReadLine(); } catch { }
            Console.Write("Endereço: "); try { adress = "" + Console.ReadLine(); } catch { }
            Console.Write("Celular: "); try { phone = "" + Console.ReadLine(); } catch { }
            Console.Write("E-mail: "); try { email = "" + Console.ReadLine(); }catch { }
            Provider provider = new(id, name);
            provider.SetIdentifier(identifier);
            provider.SetAddress(adress);
            provider.SetPhone(phone);
            provider.SetEmail(email);
            providerList.Add(provider);
            Console.WriteLine("Fornecedor cadastrado com sucesso!");
            Console.ReadKey();
        }
        void RegisterClient()
        {
            int id = 0;
            string name = "";
            string identifier = "";
            string adress = "";
            string phone = "";
            string email = "";
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("--  Cadastro de Cliente  --");
            Console.WriteLine("---------------------------\n");
            Console.WriteLine("->Informe dados do cliente:");
            while (id == 0)
            {
                Console.Write("*ID: ");
                int VerifyID;
                try
                {
                    VerifyID = int.Parse(Console.ReadLine());
                    if (VerifyID > 0 && ConsultClientValidID(VerifyID))
                    {
                        id = VerifyID;
                    };
                }
                catch { }
            }
            while (name == "")
            {
                Console.Write("*Nome: ");
                string VerifyName;
                try
                {
                    VerifyName = Console.ReadLine();
                    if (VerifyName != "" && VerifyName != null)
                    {
                        name = VerifyName;
                    }
                }
                catch { }
            }
            Console.Write("CPF/CNPJ: "); try { identifier = "" + Console.ReadLine(); } catch { }
            Console.Write("Endereço: "); try { adress = "" + Console.ReadLine(); } catch { }
            Console.Write("Celular: "); try { phone = "" + Console.ReadLine(); } catch { }
            Console.Write("E-mail: "); try { email = "" + Console.ReadLine(); } catch { }
            Client client = new(id, name);
            client.SetIdentifier(identifier);
            client.SetAddress(adress);
            client.SetPhone(phone);
            client.SetEmail(email);
            clientList.Add(client);
            Console.WriteLine("Cliente cadastrado com sucesso!");
            Console.ReadKey();
        }
        void ListProduct()
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("--   Lista de Produtos   --");
            Console.WriteLine("---------------------------\n");
            if (productsList.Count == 0)
            {
                Console.WriteLine("Não há produtos a serem exibidos!");
                Console.ReadKey();
                return;
            }
            productsList.Sort();
            foreach (Product product in productsList)
            {
                Console.WriteLine(product.ToString);
                Console.WriteLine("----------------------------\n");
            }
            Console.ReadKey();
        }
        void ListProvider()
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("-- Lista de Fornecedores --");
            Console.WriteLine("---------------------------\n");
            if (providerList.Count == 0)
            {
                Console.WriteLine("Não há fornecedores a serem exibidos!");
                Console.ReadKey();
                return;
            }
            providerList.Sort();
            foreach (Provider provider in providerList)
            {
                Console.WriteLine(provider.ToString);
                Console.WriteLine("----------------------------\n");
            }
            Console.ReadKey();
        }
        void ListClient()
        {
            Console.Clear();
            Console.WriteLine("-----------------------");
            Console.WriteLine("-- Lista de Clientes --");
            Console.WriteLine("-----------------------\n");
            if (clientList.Count == 0)
            {
                Console.WriteLine("Não há clientes a serem exibidos!");
                Console.ReadKey();
                return;
            }
            clientList.Sort();
            foreach (Client client in clientList)
            {
                Console.WriteLine(client.ToString);
                Console.WriteLine("----------------------------\n");
            }
            Console.ReadKey();
        }
        void RemoveProduct()
        {
            int id;
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("--    Remover Produto    --");
            Console.WriteLine("---------------------------\n");
            Console.Write("Informe o ID do produto: ");
            try { id = int.Parse(Console.ReadLine()); }
            catch { return; }
            Product product = ConsultProductById(id);
            if (product == null)
            {
                Console.WriteLine("Produto não encontrado!");
                Console.ReadKey();
                return;
            }
            productsList.Remove(product);
            Console.WriteLine($"O produto '{product.Name}' foi removido com sucesso!");
            Console.ReadKey();
        }
        void RemoveProvider()
        {
            int id;
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("--  Remover Fornecedor   --");
            Console.WriteLine("---------------------------\n");
            Console.Write("Informe o ID do fornecedor: ");
            try { id = int.Parse(Console.ReadLine()); }
            catch { return; }
            Provider provider = ConsultProviderById(id);
            if (provider == null)
            {
                Console.WriteLine("Fornecedor não encontrado!");
                Console.ReadKey();
                return;
            }
            providerList.Remove(provider);
            Console.WriteLine($"O fornecedor '{provider.Name}' foi removido com sucesso!");
            Console.ReadKey();
        }
        void RemoveClient()
        {
            int id;
            Console.Clear();
            Console.WriteLine("------------------------");
            Console.WriteLine("--  Remover Cliente   --");
            Console.WriteLine("------------------------\n");
            Console.Write("Informe o ID do cliente: ");
            try { id = int.Parse(Console.ReadLine()); }
            catch { return; }
            Client client = ConsultClientById(id);
            if (client == null)
            {
                Console.WriteLine("Cliente não encontrado!");
                Console.ReadKey();
                return;
            }
            clientList.Remove(client);
            Console.WriteLine($"O cliente '{client.Name}' foi removido com sucesso!");
            Console.ReadKey();
        }
        void RemoveStock()
        {
            int id;
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("--  Remover do estoque   --");
            Console.WriteLine("---------------------------\n");
            Console.Write("Informe o ID do produto: ");
            try { id = int.Parse(Console.ReadLine()); }
            catch { return; }
            Stock stock = stockList.FirstOrDefault(stock => stock.Product.Id == id);
            if (stock == null)
            {
                Console.WriteLine("Produto não foi encontrado no estoque!");
                Console.ReadKey();
                return;
            }
            stockList.Remove(stock);
            Console.WriteLine($"O produto '{stock.Product.Name}' foi removido do estoque com sucesso!");
            Console.ReadKey();
        }
        void EditProduct()
        {
            char option = '0';
            int productPos = 0;
            int id;
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("--    Editar Produto     --");
            Console.WriteLine("---------------------------\n");
            Console.Write("Informe o id do produto: ");
            try { id = int.Parse(Console.ReadLine()); }
            catch { return; }
            Product product = null;
            foreach (Product p in productsList)
            {
                if (p.Id == id)
                {
                    product = p; break;
                }
                productPos++;
            }
            if (product == null)
            {
                Console.WriteLine("Produto não encontrado!");
                Console.ReadKey();
                return;
            }
            while (option != '9')
            {
                option = '0';
                Console.Clear();
                Console.WriteLine("---------------------------");
                Console.WriteLine("--    Editar Produto     --");
                Console.WriteLine("---------------------------");
                Console.WriteLine($"1. ID: {product.Id}");
                Console.WriteLine($"2. Nome: {product.Name}");
                Console.WriteLine($"3. Descrição: {product.Description}");
                Console.WriteLine($"4. Categoria: {product.Category}");
                Console.WriteLine($"5. Preço: {product.Price}");
                Console.WriteLine($"6. Transporte: {product.Transport}");
                Console.WriteLine($"7. Preço do transporte: {product.TransportPrice}");
                Console.WriteLine($"8. Garantia: {product.Warranty}");
                Console.WriteLine($"9. Sair");
                Console.Write("\nO que você deseja editar? ");
                try { option = char.Parse(Console.ReadLine()); } catch { }
                switch (option)
                {
                    case '1':
                        Console.Write("ID: ");
                        try
                        {
                            int VerifyID = int.Parse(Console.ReadLine());
                            if (VerifyID <= 0 || !ConsultProductValidID(VerifyID)) { break; }
                            productsList[productPos].SetId(VerifyID);
                        }
                        catch { };
                        break;
                    case '2':
                        Console.Write("Nome: ");
                        try
                        {
                            string name = Console.ReadLine();
                            if (name == null || name == "") { break; }
                            productsList[productPos].SetName(name);
                        }
                        catch { };
                        break;
                    case '3':
                        Console.Write("Descrição: ");
                        try { productsList[productPos].SetDescription(Console.ReadLine()); } catch { }
                        break;
                    case '4':
                        Console.Write("Categoria: ");
                        try { productsList[productPos].SetCategory(Console.ReadLine()); } catch { }
                        break;
                    case '5':
                        Console.Write("Preço: ");
                        decimal price = decimal.Parse(Console.ReadLine());
                        if (price < 0) { break; }
                        try { productsList[productPos].SetPrice(price); } catch { }
                        break;
                    case '6':
                        Console.Write("Transporte: ");
                        try { productsList[productPos].SetTransport(Console.ReadLine()); } catch { }
                        break;
                    case '7':
                        Console.Write("Preço do transporte: ");
                        decimal tprice = decimal.Parse(Console.ReadLine());
                        if (tprice < 0) { break; }
                        try { productsList[productPos].SetTransportPrice(tprice); } catch { }
                        break;
                    case '8':
                        Console.Write("Garantia: ");
                        try { productsList[productPos].SetWarranty(Console.ReadLine()); } catch { }
                        break;
                    case '9':
                        return;
                    default:
                        break;
                }
            }
        }
        void EditProvider()
        {
            char option = '0';
            int providerPos = 0;
            int id;
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("--  Editar Fornecedor    --");
            Console.WriteLine("---------------------------\n");
            Console.Write("Informe o id do fornecedor: ");
            try { id = int.Parse(Console.ReadLine()); }
            catch { return; }
            Provider provider = null;
            foreach (Provider p in providerList)
            {
                if (p.Id == id)
                {
                    provider = p; break;
                }
                providerPos++;
            }
            if (provider == null)
            {
                Console.WriteLine("Fornecedor não encontrado!");
                Console.ReadKey();
                return;
            }
            while (option != '7')
            {
                option = '0';
                Console.Clear();
                Console.WriteLine("---------------------------");
                Console.WriteLine("--  Editar Fornecedor    --");
                Console.WriteLine("---------------------------");
                Console.WriteLine($"1. ID: {provider.Id}");
                Console.WriteLine($"2. Nome: {provider.Name}");
                Console.WriteLine($"3. CPF/CNPJ: {provider.Identifier}");
                Console.WriteLine($"4. Endereço: {provider.Address}");
                Console.WriteLine($"5. Telefone: {provider.Phone}");
                Console.WriteLine($"6. E-mail: {provider.Email}");
                Console.WriteLine($"7. Sair");
                Console.Write("\nO que você deseja editar? ");
                try { option = char.Parse(Console.ReadLine()); } catch { }
                switch (option)
                {
                    case '1':
                        Console.Write("ID: ");
                        try
                        {
                            int VerifyID = int.Parse(Console.ReadLine());
                            if (VerifyID <= 0 || !ConsultProviderValidID(VerifyID)) { break; }
                            providerList[providerPos].SetId(VerifyID);
                        }
                        catch { };
                        break;
                    case '2':
                        Console.Write("Nome: ");
                        try
                        {
                            string name = Console.ReadLine();
                            if (name == null || name == "") { break; }
                            providerList[providerPos].SetName(name);
                        }
                        catch { };
                        break;
                    case '3':
                        Console.Write("CPF/CNPJ: ");
                        try { providerList[providerPos].SetIdentifier(Console.ReadLine()); } catch { }
                        break;
                    case '4':
                        Console.Write("Endereço: ");
                        try { providerList[providerPos].SetAddress(Console.ReadLine()); } catch { }
                        break;
                    case '5':
                        Console.Write("Telefone: ");
                        try { providerList[providerPos].SetPhone(Console.ReadLine()); } catch { }
                        break;
                    case '6':
                        Console.Write("E-mail: ");
                        try { providerList[providerPos].SetEmail(Console.ReadLine()); } catch { }
                        break;
                    case '7':
                        return;
                    default:
                        break;
                }
            }
        }
        void EditClient()
        {
            char option = '0';
            int clientPos = 0;
            int id;
            Console.Clear();
            Console.WriteLine("------------------------");
            Console.WriteLine("--  Editar Cliente    --");
            Console.WriteLine("------------------------\n");
            Console.Write("Informe o id do cliente: ");
            try { id = int.Parse(Console.ReadLine()); }
            catch { return; }
            Client client = null;
            foreach (Client c in clientList)
            {
                if (c.Id == id)
                {
                    client = c; break;
                }
                clientPos++;
            }
            if (client == null)
            {
                Console.WriteLine("Cliente não encontrado!");
                Console.ReadKey();
                return;
            }
            while (option != '7')
            {
                option = '0';
                Console.Clear();
                Console.WriteLine("------------------------");
                Console.WriteLine("--  Editar Cliente    --");
                Console.WriteLine("------------------------");
                Console.WriteLine($"1. ID: {client.Id}");
                Console.WriteLine($"2. Nome: {client.Name}");
                Console.WriteLine($"3. CPF/CNPJ: {client.Identifier}");
                Console.WriteLine($"4. Endereço: {client.Address}");
                Console.WriteLine($"5. Telefone: {client.Phone}");
                Console.WriteLine($"6. E-mail: {client.Email}");
                Console.WriteLine($"7. Sair");
                Console.Write("\nO que você deseja editar? ");
                try { option = char.Parse(Console.ReadLine()); } catch { }
                switch (option)
                {
                    case '1':
                        Console.Write("ID: ");
                        try
                        {
                            int VerifyID = int.Parse(Console.ReadLine());
                            if (VerifyID <= 0 || !ConsultClientValidID(VerifyID)) { break; }
                            clientList[clientPos].SetId(VerifyID);
                        }
                        catch { };
                        break;
                    case '2':
                        Console.Write("Nome: ");
                        try
                        {
                            string name = Console.ReadLine();
                            if (name == null || name == "") { break; }
                            clientList[clientPos].SetName(name);
                        }
                        catch { };
                        break;
                    case '3':
                        Console.Write("CPF/CNPJ: ");
                        try { clientList[clientPos].SetIdentifier(Console.ReadLine()); } catch { }
                        break;
                    case '4':
                        Console.Write("Endereço: ");
                        try { clientList[clientPos].SetAddress(Console.ReadLine()); } catch { }
                        break;
                    case '5':
                        Console.Write("Telefone: ");
                        try { clientList[clientPos].SetPhone(Console.ReadLine()); } catch { }
                        break;
                    case '6':
                        Console.Write("E-mail: ");
                        try { clientList[clientPos].SetEmail(Console.ReadLine()); } catch { }
                        break;
                    case '7':
                        return;
                    default:
                        break;
                }
            }
        }
        void SearchProduct()
        {
            int option = 0;
            Console.Clear();
            Console.WriteLine("--------------------------");
            Console.WriteLine("--   Procurar produto   --");
            Console.WriteLine("--------------------------\n");
            Console.Write("Deseja pesquisar por (1) ID, (2) NOME ou (3) CATEGORIA ? ");
            try { option = int.Parse(Console.ReadLine()); } catch { }
            switch (option)
            {
                case 1:
                    Console.Write("Informe o ID: ");
                    int id;
                    try { id = int.Parse(Console.ReadLine()); } catch { break; }
                    Product product = ConsultProductById(id);
                    if (product == null)
                    {
                        Console.WriteLine("Produto não encontrado!");
                        Console.ReadKey();
                        break;
                    }
                    Console.WriteLine("--------------------------");
                    Console.WriteLine(product.ToString);
                    Console.WriteLine("--------------------------");
                    Console.ReadKey();
                    break;
                case 2:
                    Console.Write("Informe o nome: ");
                    string name;
                    try { name = Console.ReadLine(); } catch { break; }
                    List<Product> products = ConsultProductByName(name);
                    if (products.Count == 0)
                    {
                        Console.WriteLine("Nenhum produto encontrado!");
                        Console.ReadKey();
                        break;
                    }
                    Console.WriteLine("--------------------------");
                    foreach (Product p in products)
                    {
                        Console.WriteLine(p.ToString);
                        Console.WriteLine("--------------------------");
                    }
                    Console.ReadKey();
                    break;
                case 3:
                    Console.Write("Informe a categoria: ");
                    string category;
                    try { category = Console.ReadLine(); } catch { break; }
                    if (category == null) { break; }
                    List<Product> list = ConsultProductByCategory(category);
                    if (list.Count == 0)
                    {
                        Console.WriteLine("Nenhum produto encontrado!");
                        Console.ReadKey();
                        break;
                    }
                    Console.WriteLine("--------------------------");
                    foreach (Product p in list)
                    {
                        Console.WriteLine(p.ToString);
                        Console.WriteLine("--------------------------");
                    }
                    Console.ReadKey();
                    break;
                default:
                    return;
            }
        }
        void SearchProvider()
        {
            int option = 0;
            Console.Clear();
            Console.WriteLine("--------------------------");
            Console.WriteLine("-- Procurar Fornecedor  --");
            Console.WriteLine("--------------------------\n");
            Console.Write("Deseja pesquisar por (1) ID ou (2) NOME ? ");
            try { option = int.Parse(Console.ReadLine()); } catch { }
            switch (option)
            {
                case 1:
                    Console.Write("Informe o ID: ");
                    int id;
                    try { id = int.Parse(Console.ReadLine()); } catch { break; }
                    Provider provider = ConsultProviderById(id);
                    if (provider == null)
                    {
                        Console.WriteLine("Fornecedor não encontrado!");
                        Console.ReadKey();
                        break;
                    }
                    Console.WriteLine("--------------------------");
                    Console.WriteLine(provider.ToString);
                    Console.WriteLine("--------------------------");
                    Console.ReadKey();
                    break;
                case 2:
                    Console.Write("Informe o nome: ");
                    string name;
                    try { name = Console.ReadLine(); } catch { break; }
                    List<Provider> providers = ConsultProviderByName(name);
                    if (providers.Count == 0)
                    {
                        Console.WriteLine("Nenhum fornecedor encontrado!");
                        Console.ReadKey();
                        break;
                    }
                    Console.WriteLine("--------------------------");
                    foreach (Provider p in providers)
                    {
                        Console.WriteLine(p.ToString);
                        Console.WriteLine("--------------------------");
                    }
                    Console.ReadKey();
                    break;
                default:
                    return;
            }
        }
        void SearchClient()
        {
            int option = 0;
            Console.Clear();
            Console.WriteLine("-----------------------");
            Console.WriteLine("-- Procurar Cliente  --");
            Console.WriteLine("-----------------------\n");
            Console.Write("Deseja pesquisar por (1) ID ou (2) NOME ? ");
            try { option = int.Parse(Console.ReadLine()); } catch { }
            switch (option)
            {
                case 1:
                    Console.Write("Informe o ID: ");
                    int id;
                    try { id = int.Parse(Console.ReadLine()); } catch { break; }
                    Client client = ConsultClientById(id);
                    if (client == null)
                    {
                        Console.WriteLine("Cliente não encontrado!");
                        Console.ReadKey();
                        break;
                    }
                    Console.WriteLine("--------------------------");
                    Console.WriteLine(client.ToString);
                    Console.WriteLine("--------------------------");
                    Console.ReadKey();
                    break;
                case 2:
                    Console.Write("Informe o nome: ");
                    string name;
                    try { name = Console.ReadLine(); } catch { break; }
                    List<Client> clients = ConsultClientByName(name);
                    if (clients.Count == 0)
                    {
                        Console.WriteLine("Nenhum cliente encontrado!");
                        Console.ReadKey();
                        break;
                    }
                    Console.WriteLine("--------------------------");
                    foreach (Client c in clients)
                    {
                        Console.WriteLine(c.ToString);
                        Console.WriteLine("--------------------------");
                    }
                    Console.ReadKey();
                    break;
                default:
                    return;
            }
        }
        void AssignProviderToProduct()
        {
            int id1;
            int id2;
            Console.Clear();
            Console.WriteLine("----------------------------");
            Console.WriteLine("--  Atribuir Fornecedor   --");
            Console.WriteLine("----------------------------\n");
            Console.Write("Informe o ID do produto: ");
            try { id1 = int.Parse(Console.ReadLine()); }
            catch { return; }
            Product product = ConsultProductById(id1);
            if (product == null)
            {
                Console.WriteLine("Produto não encontrado!");
                Console.ReadKey();
                return;
            }
            Console.Write("Informe o ID do fornecedor: ");
            try { id2 = int.Parse(Console.ReadLine()); }
            catch { return; }
            Provider provider = ConsultProviderById(id2);
            if(provider == null)
            {
                Console.WriteLine("Fornecedor não encontrado!");
                Console.ReadKey();
                return;
            }
            product.AddProvider(provider);
            Console.WriteLine($"Agora '{provider.Name}' tem '{product.Name}' em seus produtos!");
            Console.ReadKey();
        }
        void StockAdd()
        {
            int id;
            Console.Clear();
            Console.WriteLine("----------------------------");
            Console.WriteLine("--  Adicionar ao estoque  --");
            Console.WriteLine("----------------------------\n");
            Console.Write("Informe o ID do produto: ");
            try { id = int.Parse(Console.ReadLine()); }
            catch { return; }
            Product product = ConsultProductById(id);
            if (product == null)
            {
                Console.WriteLine("Produto não encontrado!");
                Console.ReadKey();
                return;
            }
            if (stockList.FirstOrDefault(stock => stock.Product.Id == product.Id) != null) 
            {
                Console.WriteLine($"'{product.Name}' já está no estoque!");
                Console.ReadKey();
                return;
            }
            Stock stock = new Stock();
            stock.SetProduct(product);
            stock.SetQuantity(0);
            stockList.Add(stock);
            Console.WriteLine($"Agora '{product.Name}' está no estoque!");
            Console.ReadKey();
        }
        void StockList()
        {
            Console.Clear();
            Console.WriteLine("--------------------------");
            Console.WriteLine("--   Lista do Estoque   --");
            Console.WriteLine("--------------------------\n");
            if (stockList.Count == 0)
            {
                Console.WriteLine("Não há produtos a serem exibidos!");
                Console.ReadKey();
                return;
            }
            stockList.Sort();
            foreach (Stock stock in stockList)
            {
                Console.WriteLine(stock.ToString());
                Console.WriteLine("----------------------------\n");
            }
            Console.ReadKey();
        }
        void StockQuantity()
        {
            int id;
            int newQuantity;
            Console.Clear();
            Console.WriteLine("--------------------------");
            Console.WriteLine("--  Alterar quantidade  --");
            Console.WriteLine("--------------------------\n");
            Console.Write("Informe o ID do produto: ");
            try { id = int.Parse(Console.ReadLine()); }
            catch { return; }
            Stock stock = stockList.FirstOrDefault(stock => stock.Product.Id == id);
            if (stock == null)
            {
                Console.WriteLine($"({id}) não está no estoque!");
                Console.ReadKey();
                return;
            }
            Console.WriteLine($"Produto: {stock.Product.Name}\nQuantidade: {stock.quantity}");
            Console.Write("Informe a nova quantidade do produto: ");
            try { newQuantity = int.Parse(Console.ReadLine()); }
            catch { return; }
            for(int i = 0; i < stockList.Count; i++)
            {
                if(stockList[i].Product.Id == id)
                {
                    stockList[i].SetQuantity(newQuantity);
                    Console.WriteLine($"Agora '{stockList[i].Product.Name}' tem {stockList[i].quantity} unidades!");
                    break;
                }
            }
            Console.ReadKey();
        }
        Product ConsultProductById(int id) => productsList.FirstOrDefault(product => product.Id == id);
        Provider ConsultProviderById(int id) => providerList.FirstOrDefault(provider => provider.Id == id);
        Client ConsultClientById(int id) => clientList.FirstOrDefault(client => client.Id == id);
        List<Product> ConsultProductByCategory(string category)
        {
            return (from product in productsList where product.Category == category select product).ToList();
        }
        List<Product> ConsultProductByName(string name)
        {
            return (from product in productsList where product.Name.ToLower().Contains(name.ToLower()) select product).ToList();
        }
        List<Provider> ConsultProviderByName(string name)
        {
            return (from provider in providerList where provider.Name.ToLower().Contains(name.ToLower()) select provider).ToList();
        }
        List<Client> ConsultClientByName(string name)
        {
            return (from client in clientList where client.Name.ToLower().Contains(name.ToLower()) select client).ToList();
        }
        bool ConsultProductValidID(int id)
        {
            return productsList.FirstOrDefault(product => product.Id == id) == null;
        }
        bool ConsultProviderValidID(int id)
        {
            return providerList.FirstOrDefault(provider => provider.Id == id) == null;
        }
        bool ConsultClientValidID(int id)
        {
            return clientList.FirstOrDefault(client => client.Id == id) == null;
        }
    }
}
