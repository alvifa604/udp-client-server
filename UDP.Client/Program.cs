using System.Net;
using System.Net.Sockets;
using UDP.Client;

IPAddress? GetIpAddress()
{
    try
    {
        string hostName = Dns.GetHostName();
        IPAddress[] addresses = Dns.GetHostAddresses(hostName);
        foreach (IPAddress address in addresses)
        {
            if (address.AddressFamily == AddressFamily.InterNetwork) 
                return address;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("Error: " + ex.Message);
    }

    return null;
}

IPAddress? address = GetIpAddress();
if (address is null)
{
    Console.WriteLine("No valid Ip Address found");
    return;
}

Client client = new(5000, address);
while (true)
{
    Console.Write("Your message >> ");
    string message = Console.ReadLine() ?? "Null";
    client.SendMessage(message);
}

