using System;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using TraceLib;

public class CryptoHashHelper
{
    private AesCryptoServiceProvider Provider;
    private ICryptoTransform Encryptor;
    private ICryptoTransform Decryptor;
    private SHA256 Hasher;
    private string LogFolderPath = "D:/Rares Laptop/8 Uni/Materiale/Medii si instrumente de programare/laboratoare/Proiect3Medii/CryptoHelper/";
    private string SecretFolderpath = "D:/Rares Laptop/8 Uni/Materiale/Medii si instrumente de programare/laboratoare/Proiect3Medii/CryptoHelper/";

    public CryptoHashHelper()
    {
        try
        {
            Provider = new AesCryptoServiceProvider();
        }
        catch(Exception ex)
        {
            TraceHandler traceHandler = new TraceHandler();
            Task addTask = Task.Run(() => traceHandler.AddReceiverAsync(LogFolderPath + "Log.txt"));
            Task.Run(() => traceHandler.WriteLineAsync("Exception thrown while instantiating crypto provider.\n" +
                "Message: " + ex.Message +
                "\nStack trace: " + ex.StackTrace, addTask));
        }
        Provider.Key = Convert.FromBase64String(File.ReadAllText(SecretFolderpath + "key.txt"));
        Provider.IV = Convert.FromBase64String(File.ReadAllText(SecretFolderpath + "IV.txt"));
        Encryptor = Provider.CreateEncryptor();
        Decryptor = Provider.CreateDecryptor(Provider.Key, Provider.IV);

        try
        {
            Hasher = SHA256.Create();
        }
        catch (Exception ex)
        {
            TraceHandler traceHandler = new TraceHandler();
            Task addTask = Task.Run(() => traceHandler.AddReceiverAsync(LogFolderPath + "Log.txt"));
            Task.Run(() => traceHandler.WriteLineAsync("Exception thrown while instantiating SHA256.\n" +
                "Message: " + ex.Message +
                "\nStack trace: " + ex.StackTrace, addTask));
        }
    }
    public string Encrypt(string text)
    {
        byte[] clearBytes = Encoding.UTF8.GetBytes(text);
        byte[] encryptedByte;

        using (MemoryStream memoryStream = new MemoryStream())
        {
            using (CryptoStream cryptoStream = new CryptoStream(memoryStream
                , Encryptor
                , CryptoStreamMode.Write))
            {
                cryptoStream.Write(clearBytes, 0, clearBytes.Length);
                cryptoStream.Close();
            }
            encryptedByte = memoryStream.ToArray();
        }
        return Convert.ToBase64String(encryptedByte);
    }
    public string Decrypt(string encryptedText)
    {
        byte[] encryptedBytes = Convert.FromBase64String(encryptedText);
        byte[] clearBytes;

        using (MemoryStream memoryStream = new MemoryStream())
        {
            using (CryptoStream cryptoStream = new CryptoStream(memoryStream
                    , Decryptor
                    , CryptoStreamMode.Write))
            {
                cryptoStream.Write(encryptedBytes, 0, encryptedBytes.Length);
                cryptoStream.Close();
            }
            clearBytes = memoryStream.ToArray();
        }
        return Encoding.UTF8.GetString(clearBytes);
    }
    public string GetHash(string text)
    {
        byte[] bytes = Hasher.ComputeHash(Encoding.UTF8.GetBytes(text));
        StringBuilder stringBuilder = new StringBuilder();
        for (int i = 0; i < bytes.Length; ++i)
        {
            stringBuilder.Append(bytes[i].ToString("x2"));
        }
        return stringBuilder.ToString();
    }
}