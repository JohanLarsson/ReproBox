namespace ReproBox.Tests
{
    using System;
    using System.Diagnostics;
    using System.IO;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using TestStack.White;
    using TestStack.White.UIItems;
    using TestStack.White.WindowsAPI;

    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void Hangs()
        {
            using (var application = Application.AttachOrLaunch(CreateStartInfo()))
            {
                var window = application.GetWindow("MainWindow");
                window.Get<TextBox>("TextBox")
                      .Text = "foo";
                window.Keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
                window.Get<TextBox>("Button").Click();
            }
        }

        private static ProcessStartInfo CreateStartInfo()
        {
            var testAssembly = new Uri(typeof(UnitTest).Assembly.Location).LocalPath;
            var fileName = Path.Combine(Path.GetDirectoryName(testAssembly), Path.GetFileNameWithoutExtension(testAssembly).Replace(".Tests", "") + ".exe");
            Assert.AreEqual(true, File.Exists(fileName));
            var processStartInfo = new ProcessStartInfo { FileName = fileName };
            return processStartInfo;
        }
    }
}
