using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

class Program
{
    private static readonly byte[] aesKey = Encoding.UTF8.GetBytes("A1B2C3D4E5F6G7H8"); // 16 bytes
    private static readonly byte[] aesIV = Encoding.UTF8.GetBytes("1H2G3F4E5D6C7B8A");  // 16 bytes

    static void Main()
    {
        string filePath = "customers.xml";
        XDocument doc = XDocument.Load(filePath);

        foreach (var customer in doc.Descendants("customer"))
        {
            // Encrypt credit card
            var creditCard = customer.Element("creditcard")?.Value;
            if (!string.IsNullOrEmpty(creditCard))
            {
                string encrypted = EncryptCreditCard(creditCard);
                customer.Element("creditcard").Value = encrypted;
            }

            // Salt + hash password
            var password = customer.Element("password")?.Value;
            if (!string.IsNullOrEmpty(password))
            {
                string salt = GenerateSalt();
                string hashed = HashPassword(password, salt);
                customer.Element("password").Value = $"{salt}:{hashed}";
            }
        }

        // Save the modified file
        doc.Save("customers_protected.xml");
        Console.WriteLine("Encryption and hashing complete. Saved to customers_protected.xml.");
    }

    static string EncryptCreditCard(string plainText)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = aesKey;
            aes.IV = aesIV;

            ICryptoTransform encryptor = aes.CreateEncryptor();
            byte[] inputBytes = Encoding.UTF8.GetBytes(plainText);
            byte[] encryptedBytes = encryptor.TransformFinalBlock(inputBytes, 0, inputBytes.Length);

            return Convert.ToBase64String(encryptedBytes);
        }
    }

    static string GenerateSalt()
    {
        byte[] saltBytes = new byte[16];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(saltBytes);
        }
        return Convert.ToBase64String(saltBytes);
    }

    static string HashPassword(string password, string salt)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            string combined = salt + password;
            byte[] hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(combined));
            return Convert.ToBase64String(hash);
        }
    }
}
