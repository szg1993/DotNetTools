using Demo.Exceptions;

try
{
    Console.WriteLine("Hello, World!");
    var vmi = new DataValidationException("Szia");
}
catch (DataValidationException dve)
{

}
catch (Exception e)
{

}