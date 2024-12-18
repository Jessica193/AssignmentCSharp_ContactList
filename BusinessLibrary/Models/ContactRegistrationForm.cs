using System.ComponentModel.DataAnnotations;

namespace BusinessLibrary.Models;

public class ContactRegistrationForm
{
    [MinLength(2, ErrorMessage = "First name must contain at least 2 characters")]
    [Required (ErrorMessage = "First name is required")]
    public string FirstName { get; set; } = null!;

    [MinLength(2, ErrorMessage = "Last name must contain at least 2 characters")]
    [Required(ErrorMessage = "Last name is required")]
    public string LastName { get; set; } = null!;

    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Please enter a valid email address")]
    [Required(ErrorMessage = "Email address is required")]
    public string Email { get; set; } = null!;

    [MinLength(2, ErrorMessage = "Phone number must contain at least 2 characters")]
    [Required(ErrorMessage = "Phone number is required")]
    public string PhoneNumber { get; set; } = null!;

    [MinLength(2, ErrorMessage = "Address must contain at least 2 characters")]
    [Required(ErrorMessage = "Address is required")]
    public string Address { get; set; } = null!;

    [MinLength(2, ErrorMessage = "Postal code must contain at least 2 characters")]
    [Required(ErrorMessage = "Postal code is required")]
    public string PostalCode { get; set; } = null!;

    [MinLength(2, ErrorMessage = "City must contain at least 2 characters")]
    [Required(ErrorMessage = "City is required")]
    public string City { get; set; } = null!; 


    //Jag gör även fälten som innehåller siffror till string-värden. Detta för att jag inte ska hantera dem som siffror, samt att det 
    //kan finnas bokstäver/specialtecken osv 
}
