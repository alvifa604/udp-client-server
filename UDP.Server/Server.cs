using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UDP.Server;

public class Server
{
    private readonly int _port;
    private readonly UdpClient _server;
    private IPEndPoint _endPoint;

    public Server(int port)
    {
        _port = port;
        _server = new(port);
        _endPoint = new(IPAddress.Any, port);
    }

    public void Listen()
    {
        try
        {
            Console.WriteLine($"Now listening at port {_port}");
            while (true)
            {
                Console.WriteLine("Waiting for datagrams...");
                byte[] bytes = _server.Receive(ref _endPoint);

                Console.WriteLine($"{_endPoint} sent datagrams:");
                Console.WriteLine($"{Encoding.ASCII.GetString(bytes, 0, bytes.Length)}");
                Console.WriteLine();
            }
        }
        catch (SocketException e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            _server.Close();
        }
    }

    ~Server()
    {
        _server.Close();
    }
}
