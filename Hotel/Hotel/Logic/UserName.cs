using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace Hotel
{

   public static class UserName
    {
        public static string GetUserName(string login) 
        {
            string serverIP = GlobalVariables.ip;
            int serverPort = 1488;

            TcpClient client = new TcpClient(serverIP, serverPort);
            NetworkStream stream = client.GetStream();

            string[] mass = { "3", login };
            string requestJson = JsonSerializer.Serialize(mass);
            byte[] requestBytes = Encoding.UTF8.GetBytes(requestJson);
            stream.Write(requestBytes, 0, requestBytes.Length);

            byte[] responseBytes = new byte[1024];
            int bytesRead = stream.Read(responseBytes, 0, responseBytes.Length);
            string responseJson = Encoding.UTF8.GetString(responseBytes, 0, bytesRead);

            client.Close();
            return responseJson;
        }
    
        public static string GetUserSurname(string login)
        {
            string serverIP = GlobalVariables.ip;
            int serverPort = 1488;

            TcpClient client = new TcpClient(serverIP, serverPort);
            NetworkStream stream = client.GetStream();

            string[] mass = { "4", login };
            string requestJson = JsonSerializer.Serialize(mass);
            byte[] requestBytes = Encoding.UTF8.GetBytes(requestJson);
            stream.Write(requestBytes, 0, requestBytes.Length);

            byte[] responseBytes = new byte[1024];
            int bytesRead = stream.Read(responseBytes, 0, responseBytes.Length);
            string responseJson = Encoding.UTF8.GetString(responseBytes, 0, bytesRead);

            client.Close();
            return responseJson;
        }

        public static string GetUsersRoom(string login)
        {
            string serverIP = GlobalVariables.ip;
            int serverPort = 1488;

            TcpClient client = new TcpClient(serverIP, serverPort);
            NetworkStream stream = client.GetStream();

            string[] mass = { "5", login };
            string requestJson = JsonSerializer.Serialize(mass);
            byte[] requestBytes = Encoding.UTF8.GetBytes(requestJson);
            stream.Write(requestBytes, 0, requestBytes.Length);

            byte[] responseBytes = new byte[1024];
            int bytesRead = stream.Read(responseBytes, 0, responseBytes.Length);
            string responseJson = Encoding.UTF8.GetString(responseBytes, 0, bytesRead);

            client.Close();
            return responseJson;
        }
    }
}
