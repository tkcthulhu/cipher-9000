using System;

namespace CaesarCipher
{
  class Program
  {
    static void Main(string[] args)
    { 
      Console.WriteLine("Welcome to the Cipher 9000!");
      Console.WriteLine("Would you like to encrypt or decrypt a message?");

      string EnOrDe = Console.ReadLine();

      Console.WriteLine("Please enter the cipher key (The number of letters to alter the alphabet by)");

      string keyAsString = Console.ReadLine();
      int key = Int32.Parse(keyAsString);

      if (EnOrDe.ToLower() == "encrypt") {
        Console.WriteLine("Please enter a message to encrypt");
        string message = Console.ReadLine();

        Encrypt(message, key);
      } 
      else if (EnOrDe.ToLower() == "decrypt")
      {
        Console.WriteLine("Please enter a message to decrypt");
        string message = Console.ReadLine();

        Decrypt(message, key);
      }
    }

    static string Encrypt(string message, int key)
    {

      message = message.ToLower();

      char[] alphabet = new char[] {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};

      char[] messageArray = message.ToCharArray();

      char[] newMessageArray = new char[messageArray.Length];

      for (int x = 0; x < messageArray.Length; x++)
      {
        char letter = messageArray[x];

        if (letter == ' ')
        {
          newMessageArray[x] = ' ';
          continue;
        }

        for (int i = 0; i < alphabet.Length; i++)
        {
          if (letter == alphabet[i]) 
          {
            char newLetter;
            if (i > alphabet.Length - key) 
            {
              newLetter = alphabet[(i + key) - 26]; 
            } 
            else 
            {
              newLetter = alphabet[i+key];
            }
            newMessageArray[x] = newLetter;
          }
        }
      }

      string encryptedMessage = String.Join("", newMessageArray);

      Console.WriteLine("Your encrpyted message is:");

      Console.WriteLine(encryptedMessage);

      Console.WriteLine("Don't forget to give the recipient the key!");

      return encryptedMessage;
    }

    static string Decrypt(string message, int key)
    {
      char[] messageArray = message.ToCharArray();

      char[] newMessageArray = new char[messageArray.Length];

      char[] alphabet = new char[] {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};

      for (int x = 0; x < messageArray.Length; x++)
      {
        char letter = messageArray[x];

        if (letter == ' ')
        {
          newMessageArray[x] = ' ';
        }

        for (int i = 0; i < alphabet.Length; i++)
        {
          if (letter == alphabet[i])
          {
            char newLetter;
            if (i < key)
            {
              newLetter = alphabet[i + 26 - key];
            } else {
              newLetter = alphabet[i-key];
            }
            newMessageArray[x] = newLetter;
          }
        }

      }
      string decryptedMessage = String.Join("", newMessageArray);

      Console.WriteLine("Your decrpyted message is:");

      Console.WriteLine(decryptedMessage);

      return decryptedMessage;
    }
  }
}
