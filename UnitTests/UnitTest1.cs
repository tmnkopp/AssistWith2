using AssistWith.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests
{

    [TestClass]
    public class UnitTests
    { 
        [TestMethod]
        public void TemplateRoot_Returns_Path()
        {
            var _config = ConfigurationHelper.GetConfiguration(Environment.CurrentDirectory);
            var item =  _config.GetSection("AppSettings").GetSection("TemplateRoot").Value;
            Assert.IsNotNull(item);
        }
    }
}
