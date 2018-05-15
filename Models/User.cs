using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace Models
{
    public class User
    {
        [Key]
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Length must be greater than 3 and lass than 50 characters")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Length must be greater than 3 and lass than 50 characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirm New Password")]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }

        [StringLength(50, MinimumLength = 3, ErrorMessage = "Length must be greater than 3 and lass than 50 characters")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [StringLength(50, MinimumLength = 3, ErrorMessage = "Length must be greater than 3 and lass than 50 characters")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public List<Item> ItemsList { get; set; }

        [Display(Name = "Phone")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        [Display(Name = "Image")]
        public byte[] Image { get; set; }

        //public string Roles { get; set; }

        public string ReturnDateForDisplay
        {
            get
            {
                return DOB.ToString("d");
            }
        }

        public User()
        {
            ItemsList = new List<Item>();
        }
    }
    //public enum Role
    //{
    //    Admin,
    //    User,
    //    Guest
    //}

}
