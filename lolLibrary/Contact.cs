
    public class Contact
    {
        public int ContactID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
        public string Address { get; set; }
        public string Email { get; set; }
        public uint PhoneNumber { get; set; }

        public Contact() { }

        public Contact(int contactID, string firstName, string lastName, string address, string email, uint phoneNumber)
        {
            ContactID = contactID;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            Email = email;
            PhoneNumber = phoneNumber;
        }
    }
