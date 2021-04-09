using System;
using System.ComponentModel.DataAnnotations;

namespace ModelTalk.Models
{
    public class Octopus
    {
        //name, age, type of hat
        [Required(ErrorMessage="you have to put a name, yo!")]
        public string Name {get;set;}
        
        [Required]
        [DataType(DataType.Date)]
        [NoTimeTravel]
        public DateTime Birthday{get;set;}
        [Required]
        public string Hat{get;set;}
        [Required]
        [MinLength(3)]
        public string Color{get;set;}
        [Required]
        [Range(1,50, ErrorMessage="that's a wild number of tentacles, dude!")]
        [Display(Name="Number of Tentacles")]
        public int NumTentacles{get;set;}
    }

    public class NoTimeTravel : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime checkMe;
            if(value is DateTime)
            {
                checkMe = (DateTime)value;

                if(checkMe > DateTime.Now)
                {
                    return new ValidationResult("no time travel allowed!!");
                }
                else
                {
                    return ValidationResult.Success;
                }
            }
            else
            {
                return new ValidationResult("not a date time");
            }
        }
    }
}