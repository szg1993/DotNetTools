using Demo.Exceptions;
using ExGuard;

try
{
    var mylist = new List<string>();
    mylist = null;

    //list.ThrowIfNull("Sziamia!", typeof(DataValidationException));
    mylist
        .ThrowIfNull(() => new DataValidationException("csá"))
        .ThrowIfNull(message: "pot");
    //.ThrowIfEmpty("");

    //int age = 32;

    //age.Throw().IfNegative();
}
catch (DataValidationException dve)
{

}
catch (Exception e)
{

}