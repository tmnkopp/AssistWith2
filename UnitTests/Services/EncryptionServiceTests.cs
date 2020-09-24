using Microsoft.VisualStudio.TestTools.UnitTesting;
using AssistWith.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssistWith.Services.Tests
{
    [TestClass()]
    public class EncryptionServiceTests
    { 
        [TestMethod()]
        public void PasswordGen_Generates()
        {
            string pass = Utils.GeneratePassword(12); 
            Assert.IsTrue(pass.Length > 12);
        } 

        [TestMethod()]
        public void EncryptTest()
        {
            EncryptionService encryptionService = new EncryptionService();
            string salt = encryptionService.CreateSalt(8);
            string encrypted = encryptionService.Encrypt("password", salt);
            string decrypt = encryptionService.Decrypt(encrypted, salt);
            Assert.AreEqual(decrypt, "password");
        } 
    }
}