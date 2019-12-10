using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twoxzi
{
    public class CodeStopWatcherLog
    {
        public int Id { get; set; }
        /// <summary>
        /// 监测名称
        /// </summary>
        public String WatchName { get; set; }
        /// <summary>
        /// 会话ID
        /// </summary>
        public String SessionId { get; set; }
        /// <summary>
        /// 节点名称
        /// </summary>
        public String NodeName { get; set; }
        /// <summary>
        /// 记录时间
        /// </summary>
        public DateTime LogTime { get; set; }
        /// <summary>
        /// 运行时间
        /// </summary>
        public Int64 ElapsedTicks { get; set; }
    }
}
