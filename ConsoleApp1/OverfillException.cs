namespace ConsoleApp1;

[Serializable]
public class OverfillException : Exception
{
    public OverfillException()
    {
    }

    public OverfillException(string message) : base(message)
    {
    }
}