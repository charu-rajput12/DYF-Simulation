
using System.Collections.Generic;

public class GameData
{
	PlayerData m_playerData = new PlayerData();
	SettingsData m_settingsData = new SettingsData();

	List<QuestLogData> m_questLogData = new List<QuestLogData>();

	AchievementData m_achievementData = new AchievementData();

	public PlayerData PlayerData => m_playerData;
	public SettingsData SettingsData => m_settingsData;

	public List<QuestLogData> QuestLogData => m_questLogData;

	public AchievementData PlayerAchievements => m_achievementData;
}
