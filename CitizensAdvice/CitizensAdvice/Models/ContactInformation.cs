using System;

namespace CitizensAdvice.Models
{
    public class ContactInformation
    {
        public string ContactNumber { get; }
        public string EmailAddress { get; }
        public string Website { get; }
        public string EmailAddressUrl { get; }

        /// <summary>
        /// A simple class containing contact details for an organisation
        /// </summary>
        /// <param name="contactNumber">Telephone number for the organisation</param>
        /// <param name="emailAddress">Email address for the organisation</param>
        /// <param name="website">The website for the organisation. Please include the 'https://' prefix</param>
        /// <param name="emailAddressUrl">If an online email form exists insert the link here</param>
        public ContactInformation(string contactNumber, string emailAddress, string website, string emailAddressUrl = "" )
        {
            ContactNumber = contactNumber;
            EmailAddress = emailAddress;
            Website = website;
            EmailAddressUrl = emailAddressUrl;
        }
    }
}
