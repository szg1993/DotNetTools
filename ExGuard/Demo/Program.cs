using Demo.Exceptions;
using Demo.Models;
using ExGuard.Helpers;

try
{  
    int age = 32;

    //1. Throw default exception on error:
    age
        .Throw()
        .IfGreaterThan(20);

    //2. Throw custom exception type with default message:
    //age
    //    .Throw()
    //    .IfLesserThan(40, typeof(DataValidationException));

    //3. Throw custom exception type with custom message:
    //age
    //    .Throw()
    //    .IfLesserThan(40, "This is an exception message.", typeof(DataValidationException));

    //Bonus: Validation expression on list:
    //var joe = new Person("Joe", 29);
    //var john = new Person("John", 24);
    //var persons = new List<Person> { joe, john };

    //persons
    //    .Throw()
    //    .IfTrue(x => x.Any(y => y.Name == "Joe"), "Joe is present in the list.", typeof(DataValidationException))
    //    .IfFalse(x => x.Any(y => y.ChildNames.Any(z => z == "Jessica")), "Jessica is someone's child.", typeof(DataValidationException));
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