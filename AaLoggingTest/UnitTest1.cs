namespace AaLoggingTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestDebug()
        {
            string message = $"Debug message {DateTime.Now}";
            AaTools.AaLogging.Debug(message);
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void Error()
        {
            string message = $"Error message {DateTime.Now}";
            AaTools.AaLogging.Error(message);
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void ExceptionError()
        {
            try { throw new Exception("Exception message"); }
            catch (Exception ex) { AaTools.AaLogging.Error(ex); }
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void Info()
        {
            string message = $"Info message {DateTime.Now}";
            AaTools.AaLogging.Info(message);
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void Warn()
        {
            string message = $"Warn message {DateTime.Now}";
            AaTools.AaLogging.Warn(message);
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void SeriLogCall()
        {
            TestObject testObject = new TestObject { Name = "Test", Age = 99 };
            AaTools.AaSerilog.GetInstance().Information("Test object {@TestObject}", testObject);
            Assert.IsTrue(true);
        }
    }

    public class TestObject
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
