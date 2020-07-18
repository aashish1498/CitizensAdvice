using System;
using System.Collections.Generic;
using System.Text;

namespace CitizensAdvice.Models
{
    public class ContactInformation
    {
        public string ContactNumber { get; }
        public string EmailAddress { get; }
        public string Website { get; }

        public ContactInformation(string contactNumber, string emailAddress, string website)
        {
            ContactNumber = contactNumber;
            EmailAddress = emailAddress;
            Website = website;
        }
    }
}
