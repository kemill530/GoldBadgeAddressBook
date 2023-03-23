namespace lolTests;

[TestClass]
public class UnitTest1
{
    private ContactRepository _repo = new ContactRepository();
    
    [TestInitialize]
    public void InitializeBeforeAllTests()
    {
        _repo.AddNewContact(new Contact(8, "Kali", "Miller", "555 Sunny Circle, Noblesville,IN", "kali@lowell.com", 3175551234));
    }

    [TestMethod]
    public void AddNewContact_ShouldGetNotNull()
    {
        //Arrange (need to create as not pulling from TI)
        Contact newdriver = new Contact();
        newdriver.FirstName = "Kevin";
        //Act
        _repo.AddNewContact(newdriver);
        Contact driverFromDictionary = _repo.GetContactByName("Kevin");
        //Assert
        Assert.IsNotNull(driverFromDictionary);
    }

    [TestMethod]
    public void GetAllContacts_ShouldReturnNotNull()
    {
        //Arrange(doesn't have specific parameters to pull from TI, just ensuring it results in not null response) 
        //Act
        var driverDict = _repo.GetAllContacts();
        //Assert
        Assert.IsNotNull(driverDict);
    }

    [TestMethod]
    public void GetContactById_ShouldReturnNotNull()
    {
        //Arrange(from TestInitialize) 
        //Act
        var kali = _repo.GetContactById(8);
        //Assert
        Assert.IsNotNull(kali);
    }
    
    [TestMethod]
    public void GetContactByName_ShouldReturnNotNull()
    {
        //Arrange (pulling from TI)
        //Act
        var kali = _repo.GetContactByName("Kali");

        //Assert
        Assert.IsNotNull(kali);
    }

    [TestMethod]
    public void UpdateExistingContact_ShouldReturnTrue()
    {
        //Arrange - need to create as not pulling from TI or repo, so seeding inside this TestMethod only
        Contact newDriverInfo = new Contact(8, "Kali", "Miller", "303 This Street, Noblesville,IN", "kali@lowell.com", 3175551234);
        
        //Act
        bool updateResult = _repo.UpdateExistingContact(newDriverInfo);
        
        //Assert
        Assert.IsTrue(updateResult);
    }

    [TestMethod]
    public void DeleteExistingContact_ShouldReturnNull()
    {
        var Kali = _repo.GetContactByName("Kali");
        Assert.IsNotNull(Kali);

        var deleteResult = _repo.DeleteExistingContact(8);
        Assert.IsTrue(deleteResult);

        var removedKali = _repo.GetContactByName("Kali");
        Assert.IsNull(removedKali);
    }
}