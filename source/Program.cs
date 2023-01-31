using NexusCRM.Products;
using NexusCRM.Providers;

Provider fornecedor = new(1, "João Alves");
fornecedor.SetIdentifier("012.456.789-01");
fornecedor.SetAddress("Rua zero, numero 0, São Paulo - SP");
fornecedor.SetPhone("+55 55 9 5555-5555");
fornecedor.SetEmail("joaoalves@poliloja.com");
fornecedor.SetCreateDate("31/01/2023 08:06");

Product panela = new(1, "Panela Poliloja SH192D", 90.50m);
panela.SetDescription("Não gruda ovo");
panela.SetQuantity(10);
panela.SetCategory("Cozinha");
panela.SetCreateDate("31/01/2023 08:06");
panela.SetTransport("Zedex");
panela.SetTransportPrice(28.30m);
panela.SetWarranty("1 Mês contra grudamento de ovos");

panela.AddProvider(fornecedor);