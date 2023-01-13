namespace KodPlay_Server.Database.Read
{
    public class QueryServer
    {

        public int ServerCount()
        {
            var user = new ServerInfo { Sid = 27, IP = "47.14",Port = "27015"};
            return 1;
        }
    }
}
