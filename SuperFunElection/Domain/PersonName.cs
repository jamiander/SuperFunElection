using Microsoft.EntityFrameworkCore;
using System;

namespace SuperFunElection.Domain
{
    [Owned]
    public class PersonName
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public PersonName() { }

        public PersonName(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public static PersonName Create(string firstName, string lastName)
        {
            // Validations/operations go here
            if(string.IsNullOrEmpty(firstName))
                throw new ArgumentNullException(nameof(firstName));

            if (string.IsNullOrEmpty(lastName))
                throw new ArgumentNullException(nameof(lastName));

            firstName.Trim();
            lastName.Trim();

            // Create the object
            return new PersonName(firstName, lastName);
        }
    }
}
