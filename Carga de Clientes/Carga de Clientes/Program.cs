internal class Program
{
    static void Main(string[] args)
    {
        ClientManager clientManager = new ClientManager();
        clientManager.LoadInitialClients();
        clientManager.ShowClients();
        clientManager.LoadNewClients();
    }
}
