using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;


namespace Hotel
{
    public static class Client
    {      
        public static int ClientLogin(string login, string password)
        {            
            string serverIP = GlobalVariables.ip;
            int serverPort = 1488;

            TcpClient client = new TcpClient(serverIP, serverPort);
            NetworkStream stream = client.GetStream();
            
            string[] mass = { "1", login, password };
            string requestJson = JsonSerializer.Serialize(mass);
            byte[] requestBytes = Encoding.UTF8.GetBytes(requestJson);
            stream.Write(requestBytes, 0, requestBytes.Length); 
            
            byte[] responseBytes = new byte[1024];
            int bytesRead = stream.Read(responseBytes, 0, responseBytes.Length);
            string responseJson = Encoding.UTF8.GetString(responseBytes, 0, bytesRead);
            
            client.Close();
            return int.Parse(responseJson);                      
        }

        public static int ClientRegister(string name, string surname, string login, string password)
        {
            string serverIP = GlobalVariables.ip;
            int serverPort = 1488;

            TcpClient client = new TcpClient(serverIP, serverPort);
            NetworkStream stream = client.GetStream();

            string[] mass = { "2", name, surname, login, password };
            string requestJson = JsonSerializer.Serialize(mass);
            byte[] requestBytes = Encoding.UTF8.GetBytes(requestJson);
            stream.Write(requestBytes, 0, requestBytes.Length);

            byte[] responseBytes = new byte[1024];
            int bytesRead = stream.Read(responseBytes, 0, responseBytes.Length);
            string answer = Encoding.UTF8.GetString(responseBytes, 0, bytesRead);

            client.Close();
            return int.Parse(answer);
        }

        public static List<Room> ClientFindRoom(DateTime checkIn, DateTime checkOut)
        {
            string serverIP = GlobalVariables.ip;
            int serverPort = 1488;

            TcpClient client = new TcpClient(serverIP, serverPort);
            NetworkStream stream = client.GetStream();

            string[] mass = { "6", checkIn.ToString("yyyy-MM-dd"), checkOut.ToString("yyyy-MM-dd") };
            string requestJson = JsonSerializer.Serialize(mass);
            byte[] requestBytes = Encoding.UTF8.GetBytes(requestJson);
            stream.Write(requestBytes, 0, requestBytes.Length);

            byte[] responseBytes = new byte[1024];
            int bytesRead = stream.Read(responseBytes, 0, responseBytes.Length);
            string answer = Encoding.UTF8.GetString(responseBytes, 0, bytesRead);

            List<Room> rooms = ParseList(answer);

            client.Close();
            return rooms;
        }

        public static void ClientBook(string login, string type, DateTime checkIn, DateTime checkOut)
        {
            string serverIP = GlobalVariables.ip;
            int serverPort = 1488;

            TcpClient client = new TcpClient(serverIP, serverPort);
            NetworkStream stream = client.GetStream();

            string[] mass = { "7", login, type, checkIn.ToString("yyyy-MM-dd"), checkOut.ToString("yyyy-MM-dd") };
            string requestJson = JsonSerializer.Serialize(mass);
            byte[] requestBytes = Encoding.UTF8.GetBytes(requestJson);
            stream.Write(requestBytes, 0, requestBytes.Length);
        }

        private static List<Room> ParseList(string input)
        {
            List<Room> roomList = new List<Room>();
            string[] lines = input.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in lines)
            {
                string[] parts = line.Trim().Split(' ');
                if (parts.Length == 4 &&
                    int.TryParse(parts[0], out int id) &&
                    int.TryParse(parts[3], out int capacity) &&
                    float.TryParse(parts[2], out float cost))
                {
                    Room room = new Room(id, parts[1], capacity, cost);
                    roomList.Add(room);
                }
            }
            return roomList;
        }
    }
}
