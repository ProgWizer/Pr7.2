using System;
using System.Linq;
using System.Text;

namespace VigenereApp
{
    public static class VigenereCipher
    {
        private const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        /// <summary>
        /// Шифрует текст шифром Виженера.
        /// </summary>
        public static string EncryptVigenere(string text, string key)
        {
            ValidateInput(text, key);

            text = text.ToUpper();
            key = key.ToUpper();

            StringBuilder result = new StringBuilder();
            int keyIndex = 0;

            foreach (char symbol in text)
            {
                if (!Alphabet.Contains(symbol))
                {
                    result.Append(symbol);
                    continue;
                }

                char keySymbol = key[keyIndex % key.Length];

                if (!Alphabet.Contains(keySymbol))
                    throw new ArgumentException("Ключ должен содержать только английские буквы.");

                int textPosition = Alphabet.IndexOf(symbol);
                int keyPosition = Alphabet.IndexOf(keySymbol);

                int encryptedPosition = (textPosition + keyPosition) % Alphabet.Length;

                result.Append(Alphabet[encryptedPosition]);
                keyIndex++;
            }

            return result.ToString();
        }

        /// <summary>
        /// Расшифровывает текст шифром Виженера.
        /// </summary>
        public static string DecryptVigenere(string cipher, string key)
        {
            ValidateInput(cipher, key);

            cipher = cipher.ToUpper();
            key = key.ToUpper();

            StringBuilder result = new StringBuilder();
            int keyIndex = 0;

            foreach (char symbol in cipher)
            {
                if (!Alphabet.Contains(symbol))
                {
                    result.Append(symbol);
                    continue;
                }

                char keySymbol = key[keyIndex % key.Length];

                if (!Alphabet.Contains(keySymbol))
                    throw new ArgumentException("Ключ должен содержать только английские буквы.");

                int cipherPosition = Alphabet.IndexOf(symbol);
                int keyPosition = Alphabet.IndexOf(keySymbol);

                int decryptedPosition = (cipherPosition - keyPosition + Alphabet.Length) % Alphabet.Length;

                result.Append(Alphabet[decryptedPosition]);
                keyIndex++;
            }

            return result.ToString();
        }

        /// <summary>
        /// Проверяет входные данные.
        /// </summary>
        private static void ValidateInput(string text, string key)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new ArgumentException("Текст не должен быть пустым.");

            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Ключ не должен быть пустым.");
        }
    }
}