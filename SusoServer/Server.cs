using System.Net;
using System.Net.Sockets;
using System.Text;

public class Server
{

    private IPEndPoint _listenOn;
    private UdpClient receiver;


    public Server()
    {
        _listenOn = new(IPAddress.Any, 3333);
        receiver = new(_listenOn);
        receiver.BeginReceive(ReceiveData, receiver);
    }

    private void ReceiveData(IAsyncResult res)
    {
        if (res == null)
        {
            throw new ArgumentNullException();
        }
        UdpClient c = (UdpClient)res.AsyncState;
        IPEndPoint receivedIpEndPoint = new(IPAddress.Any, 0);
        Byte[] receivedBytes = c.EndReceive(res, ref receivedIpEndPoint);
        string receivedText = UTF8Encoding.UTF8.GetString(receivedBytes);
        c.BeginReceive(ReceiveData, res.AsyncState);

    }

}