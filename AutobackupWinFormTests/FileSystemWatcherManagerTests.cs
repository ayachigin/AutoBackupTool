using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutobackupWinForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AutobackupWinForm.Tests
{
    [TestClass()]
    public class FileSystemWatcherManagerTests
    {
        private FileSystemWatcherManager fswm;

        [TestMethod()]
        public void FileSystemWatcherManagerTest()
        {
            var pwd = Directory.GetCurrentDirectory();
            var dest = pwd + @"\test";
            if (Directory.Exists(dest))
            {
                Directory.Delete(dest, true);
            }
            Directory.CreateDirectory(dest);
            string[] exts = { "hoge", "fuga", "txt" };
            fswm = new FileSystemWatcherManager(pwd, dest, exts);


            var timeStr = AutoBackup.GetTimeString();
            var input = "hogefuga" + timeStr;

            System.IO.StreamWriter sw = new System.IO.StreamWriter(
                pwd + @"\test.txt",
                false,
                System.Text.Encoding.GetEncoding("shift_jis"));
            //TextBox1.Textの内容を書き込む
            sw.Write(input);
            //閉じる
            sw.Close();
            Console.WriteLine(pwd);
            System.Threading.Thread.Sleep(6000);
            var fileName = Directory.GetFiles(pwd + @"\test")[0];
            StreamReader sr = new StreamReader(fileName,
                                               System.Text.Encoding.GetEncoding("shift_jis"));
            var output = sr.ReadToEnd();
            sr.Close();

            Assert.AreEqual(input, output);
        }
    }
}