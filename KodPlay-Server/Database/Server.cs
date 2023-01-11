using Furion.DatabaseAccessor;

namespace KodPlay_Server.Database
{
    public class Server : IEntity //不需要 Furion 为实体添加任何内置特性，选用 IEntity，无键实体选用 IEntityNotKey
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string? Name { get; set; }
        // https://furion.baiqian.ltd/docs/entity/
    }
}
