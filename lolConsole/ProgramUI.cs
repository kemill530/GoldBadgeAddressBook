public class ProgramUI
{
    private ContactRepository _contactRepo = new ContactRepository();
    public void Run()
    {
        Seed();
        RunMenu();
    }

    public void RunMenu()
    {
        bool continueToRun = true;
        while (continueToRun)
        {
            Console.Clear();
            System.Console.WriteLine(
                "Welcome to L.O.L's deliver driver address book. Please choose an option from the menu below.\n" +
                "-------------------------------\n" +
                "MENU:\n" +
                "1. View All Contacts\n" +
                "2. View Contact by Name\n" +
                "3. Add New Contact\n" +
                "4. Edit Existing Contact\n" +
                "5. Remove Existing Contact\n" +
                "0. Exit"
            );
            string menuChoice = Console.ReadLine();

            switch (menuChoice)
            {
                case "1": //View All Contacts
                    ViewAllContacts();
                    break;
                case "2": //View Contact by Name
                ViewContactByFirstName();
                    break;
                case "3": //Add New Contact
                AddNewContact();
                    break;
                case "4": //Edit Existing Contact
                    break;
                case "5": //Remove Existing Contact
                    break;
                case "0": //Exit
                    continueToRun = false;
                    System.Console.WriteLine("Goodbye, see you next time!");
                    break;
                default:
                    System.Console.WriteLine("I'm not sure what you need, please choose a valid menu option.");
                    break;
            }
        System.Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        Console.Clear();
        }
    }
    
    //View All Contacts
    private void ViewAllContacts()
    {
        Console.Clear();
        foreach (KeyValuePair<int, Contact> driver in _contactRepo.GetAllContacts())
        {
            System.Console.WriteLine($"ID: {driver.Value.ContactID}\tName: {driver.Value.FullName}");
        }
    }

    //View Contact by Name
    private void ViewContactByFirstName()
    {
        Console.Clear();
        ViewAllContacts();

        System.Console.WriteLine("Enter the First Name of the Contact you'd like to view:");
        string firstName = Console.ReadLine();
        
        Contact driver = _contactRepo.GetContactByName(firstName);

        if (firstName != default)
        {
            Console.Clear();
            System.Console.WriteLine
            (
                $"ID #:\t{driver.ContactID}\n" +
                $"First Name:\t{driver.FirstName}\n" +
                $"Last Name:\t{driver.LastName}\n" +
                $"Address:\t{driver.Address}\n" +
                $"Email:\t{driver.Email}\n" +
                $"Phone:\t {driver.PhoneNumber}"
            );
        }
        else
        {
            System.Console.WriteLine("Sorry, that Contact ID was not found");
        }
    }

    //Add New Contact
    private void AddNewContact()
    {
        Console.Clear();

        Contact newContact = new Contact();
        //ID
        System.Console.WriteLine("Enter new contact's ID:");
        newContact.ContactID = int.Parse(Console.ReadLine());
        //First Name
        System.Console.WriteLine("Enter new contact's First Name:");
        newContact.FirstName = Console.ReadLine();
        //Last Name
        System.Console.WriteLine("Enter new contact's Last Name:");
        newContact.LastName = Console.ReadLine();
        //Address
        System.Console.WriteLine
        ("Enter new contact's Address\n" +
        "(i.e) 1234 Street Name, City,ST:");
        newContact.Address = Console.ReadLine();
        //Email
        System.Console.WriteLine("Enter new contact's Email:");
        newContact.Email = Console.ReadLine();
        //PhoneNumber
        System.Console.WriteLine("Enter new contact's Phone # (i.e. 1234567890):");
        newContact.PhoneNumber = uint.Parse(Console.ReadLine());

        bool WasAdded = _contactRepo.AddNewContact(newContact);
        if (WasAdded)
        {
            System.Console.WriteLine("This Contact has been added. Yay!");
        }
        else
        {
            System.Console.WriteLine("Something went wrong...bummer");
        }
    }

    //Edit Existing Contact
    
    //Remove Existing Contact

    //Seed Method
    private void Seed()
        {
            _contactRepo.AddNewContact(new Contact(1, "Ben", "Qualy", "3578 Main Street,Noblesville,IN", "ben@lowell.com", 3175556823));
            _contactRepo.AddNewContact(new Contact(2, "Evelyn", "Matthews", "878 Queensland Court, Noblesville,IN", "evie@lowell.com", 3174441105));
            _contactRepo.AddNewContact(new Contact(3, "Eleanor", "Mackenzie", "96544 Cricket Drive, Noblesville,IN", "elle@lowell.com", 3172225656));
            _contactRepo.AddNewContact(new Contact(4, "Matt", "Johnson", "1144 Rocky Way, Indianapolis,IN", "matt@lowell.com", 3173332201));
        }



    //Helper Methods
}