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
                    UpdateExistingContact();
                    break;
                case "5": //Remove Existing Contact
                    DeleteExistingContact();
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
    private void UpdateExistingContact()
    {
        Console.Clear();
        ViewAllContacts();

        System.Console.WriteLine("Enter the ID# of the contact you'd like to update");
        int contactIDToEdit = int.Parse(Console.ReadLine());
        Contact contactToEdit = _contactRepo.GetContactById(contactIDToEdit);

        if (contactToEdit != default)
        {
            Console.Clear();
            System.Console.WriteLine(
                "Enter the updated information for each field.\n" +
                "---------------------------------------------\n");
            System.Console.WriteLine(
                $"Contact's First Name: {contactToEdit.FirstName}\n" +
                "Enter the updated first name (press Enter to skip):");
                 //Calling the helper method below to allow "enter to skip"
                contactToEdit.FirstName = UpdatedInfo(contactToEdit.FirstName, Console.ReadLine());
            System.Console.WriteLine(
                $"Contact's Last Name: {contactToEdit.LastName}\n" +
                "Enter the updated last name (press Enter to skip):");
                contactToEdit.LastName = UpdatedInfo(contactToEdit.LastName, Console.ReadLine());
            System.Console.WriteLine(
                $"Contact's Address: {contactToEdit.Address}\n" +
                "Enter the updated address (press Enter to skip):");
                contactToEdit.Address = UpdatedInfo(contactToEdit.Address, Console.ReadLine());
            System.Console.WriteLine(
                $"Contact's Email: {contactToEdit.Email}\n" +
                "Enter the updated email (press Enter to skip):");
                contactToEdit.Email = UpdatedInfo(contactToEdit.Email, Console.ReadLine());
            System.Console.WriteLine(
                $"Contact's Phone: {contactToEdit.PhoneNumber}\n" +
                "Enter the updated phone number (press Enter to skip):");
                // string phoneInput = Console.ReadLine();
                string phoneInput = UpdatedInfo("no change", Console.ReadLine());
                if(phoneInput != "no change")
                {
                    contactToEdit.PhoneNumber = uint.Parse(phoneInput);
                }
                else {};

            //     contactToEdit.PhoneNumber = uint.Parse(UpdatedInfo(contactToEdit.PhoneNumber, Console.ReadLine()));
            // // System.Console.WriteLine(
            // //     $"Contact's Phone: {contatToEdit.PhoneNumber}\n" +
            // //     "Enter the updated phone number (press Enter to skip):");
            // //     contactToEdit.PhoneNumber = uint.Parse(Console.ReadLine());
            // //     if()
            // uint.Parse()
        }
        else
        {
            System.Console.WriteLine("Sorry, that Contact ID was not found");
        }
    }

    //Remove Existing Contact
    private void DeleteExistingContact()
    {
        Console.Clear();
        ViewAllContacts();
        System.Console.WriteLine("Enter the ID# of the contact you'd like to remove");
        int enteredIDToRemove = int.Parse(Console.ReadLine());

        System.Console.WriteLine($"Are you sure you want to delete {enteredIDToRemove}? (y/n):");
        string confirmDelete = Console.ReadLine().ToLower();
        if (confirmDelete == "y")
        {
            bool WasDeleted = _contactRepo.DeleteExistingContact(enteredIDToRemove);
            if (WasDeleted)
            {
                System.Console.WriteLine("That contact had successfully been removed");
            }
            else
            {
                System.Console.WriteLine("Something went wrong...bummer");
            }
        }
        else {};
    }

    //Seed Method
    private void Seed()
    {
        _contactRepo.AddNewContact(new Contact(1, "Ben", "Qualy", "3578 Main Street,Noblesville,IN", "ben@lowell.com", 3175556823));
        _contactRepo.AddNewContact(new Contact(2, "Evelyn", "Matthews", "878 Queensland Court, Noblesville,IN", "evie@lowell.com", 3174441105));
        _contactRepo.AddNewContact(new Contact(3, "Eleanor", "Mackenzie", "96544 Cricket Drive, Noblesville,IN", "elle@lowell.com", 3172225656));
        _contactRepo.AddNewContact(new Contact(4, "Matt", "Johnson", "1144 Rocky Way, Indianapolis,IN", "matt@lowell.com", 3173332201));
    }



    //Helper Methods
       //"Enter to skip" - this does not replace the update fields if user presses enter.
    private string UpdatedInfo(string existingInfo, string inputUpdateInfo)
    {
        if(string.IsNullOrWhiteSpace(inputUpdateInfo))
        {
            return existingInfo;
        }
        return inputUpdateInfo;
    }
}