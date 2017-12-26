namespace IvSite.Services.User.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static IvSite.Data.DataConstants;
    

    public class ReservationsServiceModel : IValidatableObject
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int RoomId { get; set; }

        [MaxLength(MaxLenNote)]
        public string Note { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.StartDate < DateTime.UtcNow)
            {
                yield return new ValidationResult(StartDateShouldBeInFuture);
            }

            if (this.StartDate > this.EndDate)
            {
                yield return new ValidationResult(StartDateShouldBeBeforeEndDate);
            }
        }
    }
}
