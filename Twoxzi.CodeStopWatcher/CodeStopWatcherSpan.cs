using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twoxzi
{
    public class CodeStopWatcherSpan
    {
        private CodeStopWatcher Parent { get; set; }
        internal CodeStopWatcherSpan(CodeStopWatcher parent)
        {
            Parent = parent;

        }

        /// <summary>
        /// 设定锚点, SetAnchor
        /// </summary>
        /// <param name="Name"></param>
        public void Anchor(String Name)
        {
            Parent.Stopwatch.Stop();
            Parent.Context.CodeStopWatcherLog.Add(new CodeStopWatcherLog()
            {
                LogTime = DateTime.Now,
                ElapsedTicks = Parent.Stopwatch.ElapsedTicks,
                SessionId = Parent.SessionId,
                WatchName = Parent.WatchName,
                NodeName = Name
            });
            Parent.Stopwatch.Restart();
            //Parent.Stopwatch.Start();
        }
    }
}
