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
    public class AutoBackupTests
    {
        private AutoBackup a;
        private string myString;

        private AutoBackup Setup()
        {
            var pwd = Directory.GetCurrentDirectory();
            var dest = pwd + @"\test";
            if (Directory.Exists(dest))
            {
                Directory.Delete(dest, true);
            }
            Directory.CreateDirectory(dest);
            string[] exts = { "hoge", "fuga", "txt"};
            return new AutoBackup(pwd,  dest, exts);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void AutoBackupTest()
        {
            var a = new AutoBackup("not\\exsist\\path", "and so on", null);
        }

        [TestMethod()]
        public void StartTest()
        {
            var a = Setup();
            a.Start();
            var timeStr = a.GetTimeString();
            var pwd = Directory.GetCurrentDirectory();
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

            var file = Directory.GetFiles(pwd + @"\test")[0];
            StreamReader sr = new StreamReader(file,
                                               System.Text.Encoding.GetEncoding("shift_jis"));
            var output = sr.ReadToEnd();
            sr.Close();

            Assert.AreEqual(input, output);
        }


        [TestMethod()]
        public void StopTest()
        {
        }

        [TestMethod()]
        public void ExtensionTest()
        {
            var ext = Path.GetExtension(@"C:\hoge\fuga.foo");
            Assert.AreEqual("foo", ext.Remove(0, 1));
            var exts = "hoge\nfuga\nfoo\nbar".Split('\n');
            Assert.AreEqual("hoge\nfuga\nfoo\nbar",
                            String.Join("\n", exts));
            Assert.IsTrue(Array.Exists(exts, e => e == "hoge"));
            SetProp("mymy");
        }

        private void SetProp(string myString)
        {
            this.myString = myString;
            Assert.AreEqual(this.myString, "mymy");
        }

        [TestMethod()]
        public void NewFileNameTest()
        {
            var a = Setup();
            var timeString = a.GetTimeString();
            var newFileName = a.NewFileName("C:\\foo\\bar\\piyo.moge", timeString);
            var pwd = Directory.GetCurrentDirectory();
            Assert.AreEqual(pwd + "\\test\\piyo" + timeString + ".moge", newFileName);
        }
    }
}