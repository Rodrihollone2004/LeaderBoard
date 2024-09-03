internal class Client
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public float TotalSpent { get; set; }
    public int Purchases { get; set; }

    public Client(string firstName, string lastName, string phone, float totalSpent, int purchases)
    {
        FirstName = firstName;
        LastName = lastName;
        Phone = phone;
        TotalSpent = totalSpent;
        Purchases = purchases;
    }

    public override string ToString()
    {
        return $"First Name: {FirstName}\n- Last Name: {LastName}\n- Phone: {Phone}\n- Total Spent: {TotalSpent}\n- Purchases: {Purchases}\n";
    }
}