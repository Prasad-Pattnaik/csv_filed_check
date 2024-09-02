using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csv_required_check
{
    public class csv_model
    {
        [Required(ErrorMessage =" Profile is required.")]
        public string Profile { get; set; }
        [Required(ErrorMessage ="MRN is required.")]
        public string MRN { get; set; }
        public string MRNSystem { get; set; }
        public string QID { get; set; }
        public string PPN { get; set; }
        public string VISAID { get; set; }
        public string FirstNameEn { get; set; }
        public string MiddleNameEn { get; set; }
        public string LastNameEn { get; set; }
        public string FirstNameAr { get; set; }
        public string MiddleNameAr { get; set; }
        public string LastNameAr { get; set; }
        public string Birthdate { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public string NationalityDisplay { get; set; }
        public string MaritalStatus { get; set; }
        public string MaritalStatusDisplay { get; set; }
        public string MaritalStatusSystem { get; set; }
        public string MobilePhone { get; set; }
        public string HomePhone { get; set; }
        public string WorkMail { get; set; }
        public string HomeAddressCountry { get; set; }
        public string HomeAddressCity { get; set; }
        public string HomeAddress { get; set; }
        public string AddressUnit { get; set; }
        public string AddressBuildingNumber { get; set; }
        public string AddressStreetNumber { get; set; }
        public string AddressZone { get; set; }
        public string AddressLanguage { get; set; }
        public string BirthPlace { get; set; }
        public string MultipleBirth { get; set; }
        public string DeceasedDate { get; set; }
        public string CommunicationLanguage { get; set; }
        public string CommunicationLanguageDisplay { get; set; }
        public string CommunicationLanguageSystem { get; set; }
        public string Active { get; set; }
    }
}
