using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Password Strength Checker ===");

        Console.Write("Enter a password to check: ");
        string password = Console.ReadLine();

        string result = CheckPasswordStrength(password);
        Console.WriteLine(result);
    }

    static string CheckPasswordStrength(string password)
    {
        bool isLongEnough = password.Length >= 8;
        bool hasUpper = Regex.IsMatch(password, "[A-Z]");
        bool hasLower = Regex.IsMatch(password, "[a-z]");
        bool hasDigit = Regex.IsMatch(password, "[0-9]");
        bool hasSpecial = Regex.IsMatch(password, "[!@#$%^&*(),.?\":{}|<>]");

        if (isLongEnough && hasUpper && hasLower && hasDigit && hasSpecial)
        {
            return $"\"{password}\" is a Strong password.";
        }

        string issues = "";
        if (!isLongEnough) issues += " - too short\n";
        if (!hasUpper) issues += " - missing uppercase letter\n";
        if (!hasLower) issues += " - missing lowercase letter\n";
        if (!hasDigit) issues += " - missing digit\n";
        if (!hasSpecial) issues += " - missing special character\n";

        return $"\"{password}\" is Weak:\n{issues}";
    }
}
