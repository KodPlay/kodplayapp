using Furion.DatabaseAccessor;

namespace KodPlay_Server.Database
{
    public class ServerInfo : IEntity //不需要 Furion 为实体添加任何内置特性，选用 IEntity，无键实体选用 IEntityNotKey
    {

        public int? Sid { get; set; } //服务器编号

        public string? IP { get; set; } //服务器IP地址
        
        public string? Port { get; set; } //服务器端口



        // https://furion.baiqian.ltd/docs/entity/
    }
}
