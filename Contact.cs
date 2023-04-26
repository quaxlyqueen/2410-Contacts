using System;
using System.Collections.Generic;

namespace Contacts
{
    /// <summary>
    /// Represents a contact inside of the contacts manager console application. Provides methods to update key information as well as methods to add and remove communication information.
    /// </summary>
    public class Contact : IEquatable<Contact>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Birthday? Bday { get; set; }
        public List<Address> Addresses { get; }
        public List<Phone> Numbers { get; }
        public List<string> Emails { get; }
        public ContactCategory Type { get; set; }
        public string PictureUrl { get; set; }
        private List<string> attributes { get; }

        /// <summary>
        /// Loads a saved contact and creates a new Contact object based upon the saved information.
        /// </summary>
        /// <param name="savedContact"></param>
        public Contact(string savedContact)
        {
            string[] contactArr = savedContact.Split("|");
            FirstName = contactArr[0];
            LastName = contactArr[1];
            Addresses = new List<Address>();
            Numbers = new List<Phone>();
            Emails = new List<string>();

            if (contactArr[2].Length > 0)
            {
                string[] addr = contactArr[2].Split(",");
                foreach (string a in addr)
                {
                    if (!a.Equals(""))
                        Addresses.Add(new Address(a, null)); // TODO: Need to find addr type.
                }
            }

            if (contactArr[3].Length > 0)
            {
                string[] phones = contactArr[3].Split(",");
                foreach (string p in phones)
                {
                    if (!p.Equals(""))
                        Numbers.Add(new Phone(p, null)); // TODO: Need to find phone type.
                }
            }

            if (contactArr[4].Length > 0)
            {
                string[] emails = contactArr[4].Split(",");
                foreach (string e in emails)
                {
                    if (!e.Equals(""))
                        Emails.Add(e);
                }
            }

            if (!contactArr[5].Equals(""))
            {
                ContactCategory cat = (ContactCategory)Enum.Parse(typeof(ContactCategory), contactArr[5]);
                Type = cat;
            }
            else
            {
                Type = ContactCategory.Other;
            }

            if (!contactArr[6].Equals(""))
                PictureUrl = contactArr[6];
        }

        /// <summary>
        /// Create a new Contacts object and initialize the data structures responsible for storing multiple addresses, phone numbers, and emails.
        /// </summary>
        /// <param name="firstName">New contact's first name</param>
        /// <param name="lastName">New contact's last name</param>
        /// <param name="type">If null, defaults to "Other"</param>
        public Contact(string firstName, string lastName, ContactCategory? type)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Type = type ?? ContactCategory.Other;

            Addresses = new List<Address>();
            Numbers = new List<Phone>();
            Emails = new List<string>();

            attributes = new List<string>();
        }

        /// <summary>
        /// Create a new Contacts object.
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="bday"></param>
        /// <param name="addresses"></param>
        /// <param name="numbers"></param>
        /// <param name="emails"></param>
        /// <param name="type"></param>
        public Contact(string firstName, string lastName, Birthday bday, List<Address> addresses, List<Phone> numbers,
            List<string> emails, ContactCategory? type)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Bday = bday;
            this.Addresses = addresses;
            this.Numbers = numbers;
            this.Emails = emails;

            this.Type = type ?? ContactCategory.Other;
            attributes = new List<string>();
        }
        public Contact()
        {

        }

        /// <summary>
        /// If first = true, update only the first name, otherwise update the last name.
        /// </summary>
        /// <param name="name">Updated name</param>
        /// <param name="first">First or last name</param>
        public void UpdateName(string name, bool first)
        {
            if (first)
                FirstName = name;
            else
                LastName = name;
        }

        /// <summary>
        /// Update both the first name and the last name.
        /// </summary>
        /// <param name="fName">Updated first name</param>
        /// <param name="lName">Updated last name</param>
        public void UpdateName(string fName, string lName)
        {
            FirstName = fName;
            LastName = lName;
        }

        /// <summary>
        /// Associate a birthday with the contact.
        /// </summary>
        /// <param name="bday">Birthday object to save</param>
        public void UpdateBDay(Birthday bday)
        {
            this.Bday = bday;
        }

        /// <summary>
        /// Associate a new address with the contact.
        /// </summary>
        /// <param name="a">Address object to add</param>
        public void AddAddress(Address a)
        {
            Addresses.Add(a);
        }

        /// <summary>
        /// Disassociate an address from a contact.
        /// </summary>
        /// <param name="addrToRemove">Address object to find and remove.</param>
        /// <exception cref="ArgumentException">Thrown if the address is not associated with the contact.</exception>
        public void RemoveAddress(Address addrToRemove)
        {
            if (!Addresses.Remove(addrToRemove))
                throw new ArgumentException("Address does not exist.");
        }

        /// <summary>
        /// Add a new Phone to the contact, if it does not already exist.
        /// </summary>
        /// <param name="newPhone">Phone object to add.</param>
        public void AddPhone(Phone newPhone)
        {
            bool canAdd = true;
            foreach (Phone p in Numbers)
            {
                if (newPhone.Equals(p))
                    canAdd = false;
            }

            if (canAdd)
                Numbers.Add(newPhone);
        }

        /// <summary>
        /// Disassociate a phone from a contact.
        /// </summary>
        /// <param name="phoneToRemove">Phone object to find and remove.</param>
        /// <exception cref="ArgumentException">Thrown if the phone is not associated with the contact.</exception>
        public void RemovePhone(Phone phoneToRemove)
        {
            if (!Numbers.Remove(phoneToRemove))
                throw new ArgumentException("Phone number does not exist.");
        }

        /// <summary>
        /// Add a new email to the contact.
        /// </summary>
        /// <param name="email">Email to add.</param>
        public void AddEmail(string email)
        {
            Emails.Add(email);
        }

        /// <summary>
        /// Disassociate an email from a contact.
        /// </summary>
        /// <param name="emailToRemove">Email to search and remove.</param>
        /// <exception cref="ArgumentException">Thrown if the email is not associated with this contact.</exception>
        public void RemoveEmail(string emailToRemove)
        {
            if (!Emails.Remove(emailToRemove))
                throw new ArgumentException("Email does not exist.");
        }

        /// <summary>
        /// Updates the contact type, ie. the relationship to the contact.
        /// </summary>
        /// <param name="type">Type to update to</param>
        public void SetContactType(ContactCategory type)
        {
            this.Type = type;
        }

        // TODO: Need overloaded Equals methods for different situations. This is only checking if two Contacts objects are equal, but an imported Contacts may not be detected.
        /// <summary>
        /// Determines if two contacts are equal, to avoid potential duplication.
        /// </summary>
        /// <param name="contactToCompare">Contacts to compare to. If null, returns false.</param>
        /// <returns>Whether or not the two contacts are the same.</returns>
        public bool Equals(Contact? contactToCompare)
        {
            if (contactToCompare == null)
                return false;

            return this.GetHashCode() == contactToCompare.GetHashCode();
        }

        /// <summary>
        /// Calculates the hashcode of a contact by combining the hashcodes of each field of a contact.
        /// </summary>
        /// <returns>The Contacts's hashcode</returns>
        public override int GetHashCode()
        {
            int code = 17;
            code *= FirstName.GetHashCode();
            code *= LastName.GetHashCode();
            code *= Bday.GetHashCode();

            foreach (Address a in Addresses)
            {
                code *= a.GetHashCode();
            }

            foreach (Phone p in Numbers)
            {
                code *= p.GetHashCode();
            }

            foreach (string e in Emails)
            {
                code *= e.GetHashCode();
            }

            code *= Type.GetHashCode();

            return code;
        }

        /// <summary>
        /// Formats the contact in a parsable string, designed to be saved to a file.
        /// </summary>
        /// <returns>Parsable string.</returns>
        public string SaveString()
        {
            attributes.Clear();
            attributes.Add(FirstName);
            attributes.Add(LastName);
            //attributes.Add(Bday.ToString()); // TODO: Need to implement and test birthdates.
            attributes.Add(String.Join(",", Addresses));
            List<string> nums = new List<string>();
            foreach (Phone n in Numbers)
            {
                nums.Add(n.DisplayString());
            }
            attributes.Add(String.Join(",", nums));
            attributes.Add(String.Join(",", Emails));
            attributes.Add("" + Type);
            attributes.Add(String.Join(",", PictureUrl));

            return String.Join("|", attributes);
        }

        // TODO: Implement this method once the GUI is created, formatting contacts to best integrate into the GUI.
        /// <summary>
        /// Standard string representation of a Contact, for use while still using the console with no other GUI elements.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return FirstName + (LastName.Equals("") ? "" : ", " + LastName) + ": " + String.Join(", ", Addresses) + " || " +
                String.Join(", ", Numbers) + " || " + String.Join(", ", Emails) + " || " + Type + " || " + PictureUrl;
        }



        //full name needs to be firstname lastname
        public static void RemoveContact(string fullName)
        {
            fullName = fullName.ToLower();

            string[] arguments = fullName.Split(" ");

            string firstName = arguments[0];
            string lastName = arguments[1];

            string filePath = "yourContacts.save";
            List<string> linesToKeep = new List<string>();

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null) // Read line by line until EOF
                    {
                        if (!(line.ToLower().Contains(firstName) && line.ToLower().Contains(lastName)))
                        {
                            linesToKeep.Add(line);
                        }
                    }
                }

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (string line in linesToKeep)
                    {
                        writer.WriteLine(line);
                    }
                }

                Console.WriteLine("Contact removed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading or writing the file: " + ex.Message);
            }
        }




        public static void AddContact(string firstName, string lastName, string phoneNumber, string ContactCategory)
        {
            string filePath = "yourContacts.save";
            string contactLine = $"{firstName}|{lastName} | {phoneNumber} | {ContactCategory}";

            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, true)) // Append mode is set to true
                {
                    writer.WriteLine(contactLine);
                }

                Console.WriteLine("Contact added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error writing to the file: " + ex.Message);
            }
        }
    }
}


