using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IvSite.Services.User.Models
{
   public class ReservationsServiceModel:IValidatableObject
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int RoomId { get; set; }

        public string Note { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.StartDate < DateTime.UtcNow)
            {
                yield return new ValidationResult("Start Date should be in future.");
            }

            if (this.StartDate > this.EndDate)
            {
                yield return new ValidationResult("Start Date should be before End Date.");
            }
        }
    }
}
