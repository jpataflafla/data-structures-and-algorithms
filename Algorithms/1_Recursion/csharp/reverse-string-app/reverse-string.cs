using System;

class Program
{
  static string ReverseStringIterative(string str)
  {
    char[] reversed = new char[str.Length];
    char[] input = str.ToCharArray();

    for (int i = 0; i < str.Length; i++)
    {
      reversed[i] = input[^(i + 1)]; // ^ is the index from the end
    }

    return new string(reversed);
  }

  static string ReverseStringIterative2(string str)
  {
    char[] reversed = new char[str.Length];

    for (int i = str.Length - 1, j = 0; i >= 0; i--, j++)
    {
      reversed[j] = str[i];
    }

    return new string(reversed);
  }

  static string ReverseStringIterative3(string str)
  {
    char[] strArray = str.ToCharArray(); // O(n) space complexity due to the creation of char array -  O(1) space complexity if the input is char[] (in-place swapping)
    int start = 0;
    int end = strArray.Length - 1;

    while (start < end)
    {
      // Swap characters at start/end indices in place
      // char temp = strArray[start];
      // strArray[start] = strArray[end];
      // strArray[end] = temp;
      (strArray[start], strArray[end]) = (strArray[end], strArray[start]);

      // Move pointers towards each other
      end--;
      start++;
    }

    return new string(strArray);
  }

  static string ReverseStringIterative4(string str)
  {
    char[] stringArray = str.ToCharArray();
    Array.Reverse(stringArray);
    return new string(stringArray);
  }

  public static string ReverseStringRecursive(string str)
  {
    if (str.Length <= 1)
    {
      return str;
    }

    return ReverseStringRecursive(str[1..]) + str[0];
  }

  static void Main()
  {
    Console.WriteLine(ReverseStringIterative("doog si azzip"));
    Console.WriteLine(ReverseStringIterative2("doog si azzip"));
    Console.WriteLine(ReverseStringIterative3("doog si azzip"));
    Console.WriteLine(ReverseStringIterative4("doog si azzip"));
    Console.WriteLine(ReverseStringRecursive("doog si azzip"));
  }
}
