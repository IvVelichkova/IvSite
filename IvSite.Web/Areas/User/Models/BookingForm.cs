namespace IvSite.Web.Areas.Users.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using IvSite.Core.Mapping;
    using IvSite.Data.Models.Rooms;
    using IvSite.Services.Admin.Models.Rooms;
    using IvSite.Services.User.Models;
    using static IvSite.Data.DataConstants;

    public class BookingForm : IMapFrom<Reservation>,IValidatableObject
    {
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public List<RoomsListingServiceModel> Rooms { get; set; } = new List<RoomsListingServiceModel>();

   

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.StartDate < DateTime.UtcNow)
            {
                yield return new ValidationResult("Start Date should be in future.");
            }

            if (this.StartDate >this.EndDate)
            {
                yield return new ValidationResult("Start Date should be before End Date.");
            }
        }
    }
}
