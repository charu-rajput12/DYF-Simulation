public class PlayerData
{
	LoginData loginData = new LoginData();
	public int xp = 0;
	public int currentQuest = 0;
	public ELifePath currentLifePath;

	public LoginData LoginData => loginData;
}