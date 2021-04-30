using Lesson6Practice;
using NUnit.Framework;

namespace Task1.Tests
{
    public class Tests
    {
        private UserService userService;

        [SetUp]
        public void Setup()
        {
            userService = new UserService();       
        }

        [Test]
        public void Test1()
        {
            string login = "Marina";
            Assert.IsFalse(userService.ValidateLogin(ref login));
        }
    }
}