using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Text;
using TaskScheduler;
using XSystem.Security.Cryptography;

namespace TestTaskScheduler
{
    [TestClass]
    public class IntegrationTest
    {
        [TestMethod]
        public void FullProcess()
        {
            var recordList = Task.Reader();
            Task.Writer(recordList);

            const string originalFile = @"./Reference.csv";
            const string copiedFile = @"C:\Users\Maciek\Desktop\Zadania.csv";

            var originalHash = GetFileHash(originalFile);
            var copiedHash = GetFileHash(copiedFile);

            Assert.AreEqual(copiedHash, originalHash);

        }

        public string GetFileHash(string filename)
        {
            var hash = new SHA1Managed();
            var clearBytes = File.ReadAllBytes(filename);
            var hashedBytes = hash.ComputeHash(clearBytes);
            return ConvertBytesToHex(hashedBytes);
        }

        public string ConvertBytesToHex(byte[] bytes)
        {
            var sb = new StringBuilder();

            for (var i = 0; i < bytes.Length; i++)
            {
                sb.Append(bytes[i].ToString("x"));
            }
            return sb.ToString();
        }

    }
}