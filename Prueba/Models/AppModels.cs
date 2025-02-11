public enum UserRole
{
    Cliente,      
    Administrador 
}

public class User
{
    public int Id { get; set; }
    
    public string FirstName { get; set; } 
    public string LastName { get; set; }  
    public string Email { get; set; }    
    public string PhoneNumber { get; set; }  
    
    public UserRole Role { get; set; } 

    public User(string firstName, string lastName, string email, string phoneNumber, UserRole role)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
        Role = role;
    }
}
