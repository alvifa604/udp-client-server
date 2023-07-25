using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UDP.Client;

public class Client
{
    private readonly Socket _socket;
    private readonly IPEndPoint _endPoint;

    public Client(int port, IPAddress address)
    {
        _socket = new(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        _endPoint = new(address, port);
    }

    public void SendMessage(string message)
    {
        byte[] bytes = Encoding.ASCII.GetBytes(message);
        int byteLength =_socket.SendTo(bytes, _endPoint);
        Console.WriteLine($"Message sent. ({byteLength} Bytes)");
    }
}