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
            string[] exts = { "hoge", "fuga" };
            return new AutoBackup(pwd, pwd + "\\test", exts);
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
            var now = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            var newFileName = a.NewFileName("C:\\foo\\bar\\piyo.moge");
            var pwd = Directory.GetCurrentDirectory();
            Assert.AreEqual(pwd + "\\test\\piyo" + now + ".moge", newFileName);
        }
    }
}