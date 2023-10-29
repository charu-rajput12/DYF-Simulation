
public class LoginData
{
	public string Email;
	public string FirstName;
	public string LastName;
	public string Password;

	public void CopyFrom(LoginData a_loginData)
	{
		Email = a_loginData.Email;
		Password = a_loginData.Password;
		FirstName = a_loginData.FirstName;
		LastName = a_loginData.LastName;
	}
}
