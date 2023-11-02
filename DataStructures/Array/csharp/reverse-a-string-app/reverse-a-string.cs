using System;

class Program
{
  static string ReverseString(string str)
  {
    //1. Check if the input is valid for string reversal.
    if (string.IsNullOrEmpty(str) || str.Length < 2)
    {
      return "Input is not correct"; // Provide a message for invalid inputs.
    }

    //2. Convert the string into an array.
    char[] reversed = new char[str.Length];
    for (int i = 0; i < str.Length; i++)
    {
      reversed[i] = str[str.Length - 1 - i];
    }

    /* yes it could be done with i defined in this way: i = str.Length
    char[] reversed = new char[str.Length];
    for (int i = str.Length - 1; i >= 0; i--)
    {
      //Problematic: Requires using opposite indices
      //reversed[i] = str[i]; 
      reversed[str.Length - 1 - i] = str[i];
    }*/

    //3. Return the reversed string.
    return new string(reversed);
  }


  static string ReverseString2(string str)
  {
    // A simplified version using built-in C# functions.

    // Check if the input is valid for string reversal.
    if (string.IsNullOrEmpty(str) || str.Length < 2)
    {
      return "Input is not correct"; // Provide a message for invalid inputs.
    }

    // Convert the string into an array and return the reversed string.
    char[] charArray = str.ToCharArray();
    Array.Reverse(charArray);
    return new string(charArray);
  }

  static void Main()
  {
    Console.WriteLine(ReverseString("nhoJ iH")); // Output: "nhoJ iH"
    Console.WriteLine(ReverseString2("nhoJ iH")); // Output: "nhoJ iH"
  }
}