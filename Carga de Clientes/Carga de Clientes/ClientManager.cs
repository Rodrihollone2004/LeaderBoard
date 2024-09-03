internal class ClientManager
{
    private readonly Dictionary<int, Client> clients = new Dictionary<int, Client>();

    public void LoadInitialClients()
    {
        clients.Add(46023891, new Client("Bautista", "Virgallito", "1126545327", 1000.5f, 3));
        clients.Add(87654321, new Client("Iara", "Ticozzi", "1162345678", 2500.75f, 5));
        clients.Add(11223344, new Client("Rodrigo", "Fretes", "1113456789", 1500.0f, 4));
        clients.Add(44332211, new Client("Franco", "Valenzuela", "1194567890", 3000.9f, 6));
        clients.Add(12345678, new Client("Federico", "Olive", "1135678901", 500.25f, 2));
    }

    public void LoadNewClients()
    {
        while (true)
        {
            Console.WriteLine("Enter the client's ID number or 'exit' to finish:");
            string idInput = Console.ReadLine();

            if (idInput == "exit")
            {
                break;
            }

            if (!int.TryParse(idInput, out int id))
            {
                Console.WriteLine("Invalid ID. Please enter a valid numeric ID.");
                continue;
            }

            if (clients.ContainsKey(id))
            {
                UpdateExistingClient(id);
            }
            else
            {
                AddNewClient(id);
            }

            ShowClients();
        }
    }

    private void UpdateExistingClient(int id)
    {
        Console.WriteLine("The client already exists. Enter the amount spent:");
        string inputAmount = Console.ReadLine();

        if (float.TryParse(inputAmount, out float amountSpent))
        {
            clients[id].TotalSpent += amountSpent;
            clients[id].Purchases += 1;
            Console.WriteLine("Values updated successfully.");
        }
        else
        {
            Console.WriteLine("Invalid amount. Please try again.");
        }
    }

    private void AddNewClient(int id)
    {
        Console.WriteLine("Enter the client's first name:");
        string firstName = Console.ReadLine();

        Console.WriteLine("Enter the client's last name:");
        string lastName = Console.ReadLine();

        Console.WriteLine("Enter the client's phone number:");
        string phone = Console.ReadLine();

        Console.WriteLine("Enter the amount spent:");
        string inputAmount = Console.ReadLine();

        if (float.TryParse(inputAmount, out float totalSpent))
        {
            clients.Add(id, new Client(firstName, lastName, phone, totalSpent, 1));
            Console.WriteLine("Client added successfully.");
        }
        else
        {
            Console.WriteLine("Invalid amount. Could not add the client.");
        }
    }

    public void ShowClients()
    {
        Console.WriteLine("Loaded Clients:");
        foreach (var client in clients)
        {
            Console.WriteLine($"ID: {client.Key}, {client.Value}");
        }
        Console.WriteLine();
    }
}