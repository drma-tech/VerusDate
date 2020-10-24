using Dapper.Contrib.Extensions;
using System.ComponentModel.DataAnnotations;
using VerusDate.Shared.Core;

namespace VerusDate.Shared.ViewModel
{
    [Table("ProfileValidation")]
    public class ProfileValidationVM : ViewModelType
    {
        [ExplicitKey]
        public string Id { get; set; }

        [Display(Name = "Validate your photo")]
        public bool? PhotoFace { get; set; }

        [Display(Name = "Complete your profile registration")]
        public bool? ProfileData { get; set; }

        [Display(Name = "Complete your profile criteria")]
        public bool? ProfileCriteria { get; set; }

        [Display(Name = "Check your email")]
        public bool? Email { get; set; }

        [Display(Name = "Check your phone")]
        public bool? Phone { get; set; }

        [Display(Name = "Check your facebook")]
        public bool? Facebook { get; set; }

        [Display(Name = "Check your instagram")]
        public bool? Instagram { get; set; }

        /// <summary>
        /// Use for API
        /// </summary>
        public ProfileValidationVM()
        {
        }

        /// <summary>
        /// Use for insert
        /// </summary>
        public ProfileValidationVM(string Id)
        {
            this.Id = Id;
        }
    }
}