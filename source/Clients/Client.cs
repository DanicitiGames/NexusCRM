namespace NexusCRM.Clients
{
    public class Client:IComparable<Client>
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Identifier { get; private set; }
        public string Address { get; private set; }
        public string Phone { get; private set; }
        public string Email { get; private set; }
        public string CreateDate { get; private set; }
        public int Status { get; private set; }
        public Client(int id, string name)
        {
            this.Id = id;
            this.Name = name;
            this.Status = 0;
        }
        public void SetId(int id) { this.Id = id; }
        public void SetName(string name) { this.Name = name; }
        public void SetIdentifier(string identifier) { this.Identifier = identifier; }
        public void SetAddress(string address) { this.Address = address; }
        public void SetPhone(string phone) { this.Phone = phone; }
        public void SetEmail(string email) { this.Email = email; }
        public void SetCreateDate(string createDate) { this.CreateDate = createDate; }
        public void SetStatus(int status) { this.Status = status; }
        public int CompareTo(Client other)
        {
            if (other == null) return 1;
            return this.Id.CompareTo(other.Id);
        }
        public new string ToString
        {
            get
            {
                string text = $"ID: {this.Id}\nNome: {this.Name}";
                if (this.Identifier != "N/A" && this.Identifier != "") { text += $"\nCPF/CNPJ: {this.Identifier}"; }
                if (this.Address != "N/A" && this.Address != "") { text += $"\nEndereço: {this.Address}"; }
                if (this.Phone != "N/A" && this.Phone != "") { text += $"\nTelefone:{this.Phone}"; }
                if (this.Email != "N/A" && this.Email != "") { text += $"\nE-mail: {this.Email}"; }
                return text;
            }
        }
    }
}
