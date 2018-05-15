using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.CustomValidation
{
    public class UserNameFreeAttribute : ValidationAttribute
    {
        private DbManager _dbManager;

        public UserNameFreeAttribute(string name)
        {
            _dbManager = new DbManager();
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            User _user =_dbManager.UserRepository.FindUserByName(((User)validationContext.ObjectInstance).UserName);

            if (_user!=null)
            {
                return new ValidationResult(this.FormatErrorMessage(validationContext.DisplayName));
            }

            return ValidationResult.Success;
        }
    }
}
