using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;


namespace Twoxzi
{
    /// <summary>
    /// 基于System.Diagnostics.Stopwatch的时间监测工具.需要添加EntityFramework引用,并在ConnectionStrings中增加CodeStopWatcherContext节点
    /// </summary>
    public class CodeStopWatcher
    {
        protected internal string WatchName { get;protected set; }
        protected internal Stopwatch Stopwatch { get;protected set; }
        protected internal CodeStopWatcherContext Context { get; protected set; }
        /// <summary>
        /// 会话Id
        /// </summary>
        public String SessionId { get; protected set; }
        public CodeStopWatcher(String watchName)
        {
            Stopwatch = new Stopwatch();
            WatchName = watchName;
            Context = new CodeStopWatcherContext();
        }

        /// <summary>
        /// 执行代码时间监测
        /// </summary>
        /// <param name="exec"></param>
        public void Execute(Action<CodeStopWatcherSpan> exec)
        {
            if(exec != null)
            {
                SessionId = Guid.NewGuid().ToString();
                CodeStopWatcherSpan span = new CodeStopWatcherSpan(this);
                span.Anchor("Start");
                try
                {
                    exec(span);
                }
                catch(Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    span.Anchor("End");
                    Stopwatch.Stop();
                    Context.SaveChanges();
                }
            }
        }

    }
}
