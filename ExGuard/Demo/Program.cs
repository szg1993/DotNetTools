using Demo.Exceptions;
using ExGuard;
using ExGuard.Helpers;
//using Throw;
//using Throw;
try
{
    var mylist = new List<string>();
    mylist = null;

    //mylist
    //    .ThrowIfNull()
    //    .ThrowIfNull(typeof(DataValidationException))
    //    .ThrowIfNull("Hello!", typeof(DataValidationException))
    //    .ThrowIfNullOrEmpty()
    //    ;

    int age = 32;

    age
        .Throw()
        .IfNull()
        .IfGreater(10)
        .IfNull("Csá");

    //double weight = 40;

    //string name = "";
    //name.ThrowIfNullOrEmpty();

    var person = new Person("Gábor", 29);
    //var vmi = person.Throw()
    //    .ThrowIfNull();

    person
        .Throw()
        .IfTrue(x => x.Value.Name == "Gábor");


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

//public class CustomerValidator : AbstractValidator<Customer>
//{
//    public CustomerValidator()
//    {
//        RuleFor(x => x.Surname).NotEmpty();
//        RuleFor(x => x.Forename).NotEmpty().WithMessage("Please specify a first name");
//        RuleFor(x => x.Discount).NotEqual(0).When(x => x.HasDiscount);
//        RuleFor(x => x.Address).Length(20, 250);
//        RuleFor(x => x.Postcode).Must(BeAValidPostcode).WithMessage("Please specify a valid postcode");
//    }
//}