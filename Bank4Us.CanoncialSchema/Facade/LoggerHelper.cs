//Also borrowed from textbook
using System;
using System.Text;
/// <summary>
///   Course Name: COSC 6360 Enterprise Architecture
///   Year: Fall 2023
///   Name: Matthew Valentino
///   Description: Example implementation of the Domain Driven Design Pattern.
///                https://en.wikipedia.org/wiki/Domain-driven_design                 
/// </summary>
public static class LoggerHelper
{
    public static string GetExceptionDetails(Exception ex)
    {
        StringBuilder errorString = new StringBuilder();
        errorString.AppendLine("An error occurred. ");
        Exception inner = ex;
        while (inner != null)
        {
            errorString.Append("Error Message: ");
            errorString.AppendLine(inner.Message);
            errorString.Append("Stack Trace: ");
            errorString.AppendLine(inner.StackTrace);
            inner = inner.InnerException;
        }

        return errorString.ToString();
    }
}
