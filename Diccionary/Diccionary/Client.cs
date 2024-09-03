public class Client
{
    string name;
    string lastName;
    int phoneNumber;
    int totalSpent;
    int purchases;
    int id = 0;

    Random random;

    List<string> names = new List<string>();
    private Dictionary<int, Client> clientsDirectory = new Dictionary<int, Client>();

    public Client()
    {
        random = new Random();

        id = random.Next(00000000, 99999999);
        name = GenerateRandomName(5);
        lastName = GenerateRandomName(4);
        phoneNumber = random.Next(1100000000, 1199999999);
        totalSpent = random.Next(0,10000);
        purchases = random.Next(0, 10);
    }

    private string GenerateRandomName(int length)
    {
       char[] letters = new char[length];

        for (int i = 0; i < length; i++)
        {
            letters[i] = (char)('A' + random.Next(0, 26));
        }

        return new string(letters);
    }

    public void Add()
    {
        clientsDirectory = new Dictionary<int, Client>();

        for(int i = 0; i < 5; i++)
        {
            Client client = new Client();
            clientsDirectory.Add(client.id, client);
        }

        LoadClients();
        LoadNewClient();
    }

    public void LoadNewClient()
    {
        Console.WriteLine("Do you want to create a new client? (yes/no)");
        string answer = Console.ReadLine();
        if (answer == "yes")
        {
            AddClient();
        }
        else
        {
            return;
        }
    }

    public void LoadClients()
    {
        foreach (var client in clientsDirectory.Values)
        {
            Console.WriteLine($"ID: {client.id} -- Name: {client.name} -- Last Name: {client.lastName} -- Phone Number: {client.phoneNumber} -- Total Spent: {client.totalSpent} -- Purchases: {client.purchases} \n");
        }
    }

    public void AddClient()
    {
        while (true)
        {
            Console.WriteLine("ID (8 digits or less): ");
            if (int.TryParse(Console.ReadLine(), out id) && id >= 1 && id <= 99999999)
            {
                break;
            }
            else
            {
            Console.WriteLine("Id not allowed. Enter a new one.");
            }
        }
               
        Console.WriteLine("Name: ");
        name = Console.ReadLine();
            
        Console.WriteLine("Last Name: ");
        lastName = Console.ReadLine();

        while (true)
        {
            Console.WriteLine("Phone number (10 digits and have to start with 11): ");
            if (int.TryParse(Console.ReadLine(), out phoneNumber) && phoneNumber >= 1100000000 && phoneNumber <= 1199999999)
            {
                break;
            }
            else
            {
                Console.WriteLine("Phone Number not allowed. Enter a new one.");
            }
        }

        while (true)
        {
            Console.WriteLine("Total spent (4 digits or less): ");
            if (int.TryParse(Console.ReadLine(), out totalSpent) && totalSpent >= 0 && totalSpent <= 10000)
            {
                break;
            }
            else
            {
                Console.WriteLine("amount not allowed. Enter a new one.");
            }
        }

        while (true)
        {
            Console.WriteLine("Purchases (1 digit): ");
            if (int.TryParse(Console.ReadLine(), out purchases) && purchases >= 0 && purchases <= 9)
            {
                break;
            }
            else
            {
                Console.WriteLine("amount not allowed. Enter a new one.");
            }
        }

        CompareIds();
    }
    

    public void CompareIds()
    {
        if (clientsDirectory.ContainsKey(id))
        {
            var client = clientsDirectory[id];
            client.totalSpent += totalSpent;
            client.purchases += 1;
            Console.WriteLine("A client with the same ID already exists. The data has been merged");
        }
        else
        {
            clientsDirectory.Add(id, new Client
            {
                id = this.id,
                name = this.name,
                lastName = this.lastName,
                phoneNumber = this.phoneNumber,
                totalSpent = this.totalSpent,
                purchases = this.purchases
            });
            

            Console.WriteLine("A new client has been added");
        }
        LoadClients();
        LoadNewClient();
    }
}
