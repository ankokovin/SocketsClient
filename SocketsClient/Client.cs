using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace Sockets
{
    public partial class frmMain : Form
    {
        private TcpClient Client = new TcpClient();     // клиентский сокет
        private IPAddress IP;                           // IP-адрес клиента
        private TcpListener Listener;                   // сокет сервера
        private List<Thread> Threads = new List<Thread>();      // список потоков приложения (кроме родительского)
        private bool _continue = true;                          // флаг, указывающий продолжается ли работа с сокетами
        private Socket ServerSocket;
        private UdpClient udpClient;
        private int serverUdpPort = 5000;
        private int clientUdpPort = 5001;
        // конструктор формы
        public frmMain()
        {
            InitializeComponent();

            IPHostEntry hostEntry = Dns.GetHostEntry(Dns.GetHostName());    // информация об IP-адресах и имени машины, на которой запущено приложение
            IP = hostEntry.AddressList[0];                                  // IP-адрес, который будет указан в заголовке окна для идентификации клиента
            int Port = 1011;
            // определяем IP-адрес машины в формате IPv4
            foreach (IPAddress address in hostEntry.AddressList)
                if (address.AddressFamily == AddressFamily.InterNetwork)
                {
                    IP = address;
                    break;
                }

            this.Text += "     " + IP.ToString();                           // выводим IP-адрес текущей машины в заголовок формы
            Listener = new TcpListener(IP, Port);
            Listener.Start();
            // создаем и запускаем поток, выполняющий обслуживание клиентского сокета
            Threads.Clear();
            Threads.Add(new Thread(ReceiveMessage));
            Threads[Threads.Count - 1].Start();
            udpClient = new UdpClient(clientUdpPort, AddressFamily.InterNetwork);
            Threads.Add(new Thread(receive_ip));
            Threads.Last().Start();
        }
        // работа с клиентскими сокетами
        private void ReceiveMessage()
        {
            // входим в бесконечный цикл для работы с серверным сокетом
            while (_continue)
            {
                ServerSocket = Listener.AcceptSocket();           // получаем ссылку на очередной серверный сокет
                Threads.Add(new Thread(ReadMessages));          // создаем и запускаем поток, обслуживающий конкретный серверный сокет
                Threads[Threads.Count - 1].Start(ServerSocket);
            }
        }

        private void ReadMessages(object ServerSock)
        {
            string msg = "";        // полученное сообщение

            // входим в бесконечный цикл для работы с клиентским сокетом
            while (_continue)
            {
                byte[] buff = new byte[1024];                           // буфер прочитанных из сокета байтов
                ((Socket)ServerSock).Receive(buff);                     // получаем последовательность байтов из сокета в буфер buff
                msg = System.Text.Encoding.Unicode.GetString(buff);     // выполняем преобразование байтов в последовательность символов
                rtbMessages.Invoke((MethodInvoker)delegate
                {
                    if (msg.Replace("\0", "") != "")
                        rtbMessages.Text += "\n >> " + msg;             // выводим полученное сообщение на форму
                });
                Thread.Sleep(500);
            }
        }

        // подключение к серверному сокету
        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                int Port = 1010;                                // номер порта, через который выполняется обмен сообщениями
                IPAddress sIP = IPAddress.Parse(cbServerIp.Text);      // разбор IP-адреса сервера, указанного в поле tbIP
                Client.Connect(sIP, Port);                       // подключение к серверному сокету
                send(IP.ToString() + " << " + tbName.Text);
                btnConnect.Enabled = false;
                btnSend.Enabled = true;
            }
            catch
            {
                MessageBox.Show("Введен некорректный IP-адрес");
            }
        }

        // отправка сообщения
        private void btnSend_Click(object sender, EventArgs e)
        {
            send(IP.ToString() + " >> " + tbMessage.Text);   
        }

        private void send(string msg)
        {
            byte[] buff = Encoding.Unicode.GetBytes(msg);   // выполняем преобразование сообщения (вместе с идентификатором машины) в последовательность байт
            Stream stm = Client.GetStream();                                                    // получаем файловый поток клиентского сокета
            stm.Write(buff, 0, buff.Length);                                                    // выполняем запись последовательности байт
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Client.Close();         // закрытие клиентского сокета
        }


        private void receive_ip()
        {
            string msg = "";
            IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, clientUdpPort);
            while (_continue)
            {
                byte[] bytes = udpClient.Receive(ref groupEP);
                msg = System.Text.Encoding.Unicode.GetString(bytes);     // выполняем преобразование байтов в последовательность символов
                if (msg != "")
                {
                    cbServerIp.Invoke((MethodInvoker)delegate
                    {
                        cbServerIp.Items.Add(msg);
                        if (cbServerIp.Items.Count == 1) cbServerIp.SelectedIndex = 0;
                    });
                }

            }
        }

        private void bLoadServerList_Click(object sender, EventArgs e)
        {
            cbServerIp.Items.Clear();
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPAddress broadcast = IPAddress.Parse("10.0.129.255");
            byte[] sendbuf = Encoding.ASCII.GetBytes(IP.ToString());
            IPEndPoint ep = new IPEndPoint(broadcast, serverUdpPort);
            s.SendTo(sendbuf, ep);
            btnConnect.Enabled = true;
        }
    }
}