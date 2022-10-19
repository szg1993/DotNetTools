using Demo.Exceptions;
using ExGuard;

try
{
    Console.WriteLine("Hello, World!");

    var list = new List<string>();
    list = null;

    list.ThrowIfNull("Sziamia!", typeof(DataValidationException));

}
catch (DataValidationException dve)
{

}
catch (Exception e)
{

}