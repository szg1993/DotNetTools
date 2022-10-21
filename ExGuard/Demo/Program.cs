using Demo.Exceptions;
using ExGuard;
using ExGuard.Helpers;

try
{
    //int age = 20;

    //age.Throw()
    //    .IfGreaterThan(50)
    //    .IfTrue(x => x == 50)
    //    .IfLesserThan(40);

    var gabor = new Person("Gábor", 29);
    var sandor = new Person("Sándor", 24);
    var persons = new List<Person> { gabor, sandor };

    persons
        .Throw()
        .IfTrue(x => x.Any(y => y.Name == "Gábor"), message: "Hellóka", exceptionType: typeof(DataValidationException));
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