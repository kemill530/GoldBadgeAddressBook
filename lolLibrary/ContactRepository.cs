using System.Collections.Generic;

public class ContactRepository
{
    private Dictionary<int, Contact> _driversDictionary = new Dictionary<int, Contact>();

    //CREATE
    public bool AddNewContact(Contact driver)
    {
        int startingCount = _driversDictionary.Count;

        _driversDictionary.Add(driver.ContactID, driver);

        return (startingCount <= _driversDictionary.Count);
    }

    //READ
    public Dictionary<int, Contact> GetAllContacts()
    {
        return _driversDictionary;
    }

        public Contact GetContactById(int contactID)
    {
        foreach (KeyValuePair<int, Contact> driver in GetAllContacts())
        {
            if (driver.Value.ContactID == contactID)
            {
                return driver.Value;
            }
        }
        return default;
    }

    public Contact GetContactByName(string firstName)
    {
        foreach (KeyValuePair<int, Contact> driver in GetAllContacts())
        {
            if (driver.Value.FirstName.ToLower() == firstName.ToLower())
            {
                return driver.Value;
            }
        }
        return default;
    }


    //UPDATE

    public bool UpdateExistingContact(Contact newInfo)
    {
        Console.Clear();
        Contact oldInfo = GetContactById(newInfo.ContactID);
        {
            if (oldInfo != default)
            {
                oldInfo.FirstName = newInfo.FirstName;
                oldInfo.LastName = newInfo.LastName;
                oldInfo.Address = newInfo.Address;
                oldInfo.Email = newInfo.Email;
                oldInfo.PhoneNumber = newInfo.PhoneNumber;
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    //DELETE
    public bool DeleteExistingContact(int contactID)
    {
        Console.Clear();
        Contact contactToDelete = GetContactById(contactID);
        {
            if (contactToDelete != default)
            {
                bool deleteResult = _driversDictionary.Remove(contactToDelete.ContactID);
                return deleteResult;
            }
            else
            {
                return false;
            }
        }
    }


}
