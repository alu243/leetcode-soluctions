using System;

namespace LeetcodeSoluctions;

public class LeetCodeException : Exception
{
    public LeetCodeException() { }
    public LeetCodeException(string message) : base(message) { }
    public LeetCodeException(string message, Exception inner) : base(message, inner) { }
}