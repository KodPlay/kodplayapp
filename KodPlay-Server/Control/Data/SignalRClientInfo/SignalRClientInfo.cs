namespace KodPlay_Server.Control.Data.SignalRClientInfo
{
    public class SignalRClientInfo
    {
        private string _client_name;
        private string _client_ip = "192.168.1.1";
        private string _connectionid;
        //计算机名
        public string ClientName
        {
            set { _client_name = value; }
            get { return _client_name; }
        }
        //计算机IP
        public string ClientIP
        {
            set { _client_ip = value; }
            get { return _client_ip; }
        }
        //通信连接id
        public string ConnectionId
        {
            set { _connectionid = value; }
            get { return _connectionid; }
        }

    }
}
