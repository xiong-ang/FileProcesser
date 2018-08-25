using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileProcesser
{
    class Program
    {
        static void Main(string[] args)
        {
            //FileHelper.OpenFile(@"https://www.baidu.com");
            //FileHelper.OpenFile(@"C:\Users\xiongang\Desktop\CShape并发编程经典实例.PDF");
            //FileHelper.OpenFolder(@"C:\");
            FileHelper.OpenFolderAndSelectFile(@"C:\Users\xiongang\Desktop\CShape并发编程经典实例.PDF");
        }
    }
}
