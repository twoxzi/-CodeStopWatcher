using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Twoxzi.Test
{
    public class Class1
    {
        public static void Main()
        {
            Int32 i = 10;
            while(i-- > 0)
            {
                CodeStopWatcher watcher = new CodeStopWatcher("Test");
                watcher.Execute(x =>
                {
                    Thread.Sleep(2000);
                    x.Anchor("note1");
                    WebClient client = new WebClient();
                    client.DownloadData("http://www.baidu.com");
                    x.Anchor("note2");
                });
            }
        }
    }
}
