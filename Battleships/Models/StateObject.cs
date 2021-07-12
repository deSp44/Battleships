using System.Net.Sockets;
using System.Text;

namespace Battleships.Models
{
    public class StateObject
    {
        public const int BufferSize = 1024; // Buffer size

        public byte[] buffer = new byte[BufferSize]; // Receive buffer

        public StringBuilder sb = new StringBuilder(); // Received data string

        public Socket workSocket = null; // Client socket
    }
}
