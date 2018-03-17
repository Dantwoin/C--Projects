using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

// Written By: Antwoin Davis

namespace Hash_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Program gets Username and Password. Uses Username and Password to create a salt for hashing

            Console.WriteLine("Enter a username to hash...");
            // Get a username from the user and store it in user
            string user = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Enter a password to hash:");
            // Get a password from the user and store it in pw
            string pw = Console.ReadLine();
            Console.WriteLine();
            HashData hd = new HashData();
            Console.WriteLine("The hash value for " + user +"and"+ pw + " is: ");

            // Create a hashvalue from the user's password
            string pwh = hd.GetSaltedPasswordHash(user, pw);

            // Display the hash value of the user's password
            Console.WriteLine(pwh);
            Console.WriteLine();
            Console.WriteLine("Store user's password in database:");
            Console.WriteLine();

            // User attempts to login.  
            Console.WriteLine("Enter a username to hash:");
            // Get a username from the user and store it in user
            string user2 = Console.ReadLine();
            Console.WriteLine();

            // Get the password from the user again
            Console.WriteLine("Enter the password again:");
            string pw2 = Console.ReadLine();
            Console.WriteLine();

            // Hash the second password
            string pwh2 = hd.GetSaltedPasswordHash(user, pw2);
            Console.WriteLine();

            // Now lets compare.  Does the first hash equal the second?
            Console.WriteLine("First hash : " + pwh);
            Console.WriteLine("Second hash: " + pwh2);

            // Compare the two hashes.
            if (pwh == pwh2)
            {
                Console.WriteLine("Hashes match.");
            }
            else
            {
                Console.WriteLine("Hashes do not match.");
            }



        }
    }
}
public class HashData
{
    public string GetSaltedPasswordHash(string username, string password)
    {
        // Convert string password into array of bytes
        byte[] pwdBytes = Encoding.UTF8.GetBytes(password);
        // Convert string username into array of bytes
        byte[] salt = Encoding.UTF8.GetBytes(username);
        // Define the length for the hash
        byte[] saltedPassword = new byte[pwdBytes.Length + salt.Length];

        // Adds the pwdBytes array to saltedPassword
        Buffer.BlockCopy(pwdBytes, 0, saltedPassword, 0, pwdBytes.Length);
        // After pwdBytes array, salt is added to saltedPassword
        // Essentially, saltedPassword = pwdBytes + salt
        // Example: salt= user ; pwdBytes = pass ; saltPassword = passuser 
        Buffer.BlockCopy(salt, 0, saltedPassword, pwdBytes.Length, salt.Length);

        // Create a Secure Hash Algorithm (SHA) to compute hash
        SHA1 sha = SHA1.Create();
        byte[] hash = sha.ComputeHash(saltedPassword);
        
        // return string of hash
        return  Convert.ToBase64String(hash);
    }

}