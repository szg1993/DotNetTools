using Demo.Exceptions;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using ExGuard;
using System.Collections.Generic;
//using Throw;
//using Throw;
try
{
    var mylist = new List<string>();
    mylist = null;

    //mylist
    //    .Throw()
    //    .IfNull<ArgumentException>("Hello");

    mylist.ThrowIfNullOrEmpty();

    mylist
        .ThrowIfNull()
        .ThrowIfNull(typeof(DataValidationException))
        .ThrowIfNull("Sziamia!", typeof(DataValidationException))
        .ThrowIfNullOrEmpty("")
        ;
    
    //mylist
    //    .ThrowIfNull(() => new DataValidationException("csá"))
    //    .ThrowIfNull(message: "pot");
    //.ThrowIfEmpty("");

    //int age = 32;

    //age.Throw().IfNegative();


}
catch (DataValidationException dve)
{

}
catch (ArgumentException e)
{

}
catch (Exception e)
{

}