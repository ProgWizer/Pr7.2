using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pr7._2;
using System;
using VigenereApp;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void EncryptVigenere_KnownTextAndKey_ReturnsKnownCipher()
        {
            string result = VigenereCipher.EncryptVigenere("ATTACKATDAWN", "LEMON");

            Assert.AreEqual("LXFOPVEFRNHR", result);
        }

        [TestMethod]
        public void DecryptVigenere_KnownCipherAndKey_ReturnsKnownText()
        {
            string result = VigenereCipher.DecryptVigenere("LXFOPVEFRNHR", "LEMON");

            Assert.AreEqual("ATTACKATDAWN", result);
        }

        [TestMethod]
        public void EncryptDecrypt_WithShortKey_ReturnsOriginalText()
        {
            string text = "HELLO WORLD";
            string key = "KEY";

            string encrypted = VigenereCipher.EncryptVigenere(text, key);
            string decrypted = VigenereCipher.DecryptVigenere(encrypted, key);

            Assert.AreEqual(text, decrypted);
        }

        [TestMethod]
        public void EncryptDecrypt_WithLongKey_ReturnsOriginalText()
        {
            string text = "TEST";
            string key = "VERYLONGKEY";

            string encrypted = VigenereCipher.EncryptVigenere(text, key);
            string decrypted = VigenereCipher.DecryptVigenere(encrypted, key);

            Assert.AreEqual(text, decrypted);
        }

        [TestMethod]
        public void EncryptVigenere_WithSpacesAndPunctuation_KeepsSymbols()
        {
            string result = VigenereCipher.EncryptVigenere("HELLO, WORLD!", "KEY");

            Assert.AreEqual("RIJVS, UYVJN!", result);
        }

        [TestMethod]
        public void DecryptVigenere_WithSpacesAndPunctuation_KeepsSymbols()
        {
            string result = VigenereCipher.DecryptVigenere("RIJVS, UYVJN!", "KEY");

            Assert.AreEqual("HELLO, WORLD!", result);
        }

        [TestMethod]
        public void EncryptVigenere_EmptyText_ThrowsException()
        {
            Assert.ThrowsException<ArgumentException>(() =>
                VigenereCipher.EncryptVigenere("", "KEY"));
        }

        [TestMethod]
        public void EncryptVigenere_EmptyKey_ThrowsException()
        {
            Assert.ThrowsException<ArgumentException>(() =>
                VigenereCipher.EncryptVigenere("HELLO", ""));
        }

        [TestMethod]
        public void DecryptVigenere_EmptyCipher_ThrowsException()
        {
            Assert.ThrowsException<ArgumentException>(() =>
                VigenereCipher.DecryptVigenere("", "KEY"));
        }

        [TestMethod]
        public void DecryptVigenere_EmptyKey_ThrowsException()
        {
            Assert.ThrowsException<ArgumentException>(() =>
                VigenereCipher.DecryptVigenere("RIJVS", ""));
        }

        [TestMethod]
        public void EncryptVigenere_KeyWithNumbers_ThrowsException()
        {
            Assert.ThrowsException<ArgumentException>(() =>
                VigenereCipher.EncryptVigenere("HELLO", "K3Y"));
        }

        [TestMethod]
        public void DecryptVigenere_KeyWithNumbers_ThrowsException()
        {
            Assert.ThrowsException<ArgumentException>(() =>
                VigenereCipher.DecryptVigenere("RIJVS", "K3Y"));
        }
    }
}
