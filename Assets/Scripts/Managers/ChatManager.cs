using ExitGames.Client.Photon;
using Photon.Chat;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatManager : MonoBehaviour, IChatClientListener
{
    static ChatManager s_instance;

    [SerializeField] string m_username;

    ChatClient m_chatClient;
    [SerializeField] protected internal ChatAppSettings m_chatAppSettings;


    [SerializeField] List<string> m_lstChannelsToJoinOnConnect;
    [SerializeField] List<string> m_lstFriendsList;
    [SerializeField] int HistoryLengthToFetch;


    public int TestLength = 2048;
    private byte[] testBytes = new byte[2048];
    [SerializeField] string m_selectedChannelName = "Global";


    #region Unity Methods

    private void Awake()
    {
        s_instance = this;
    }
    private void OnDestroy()
    {
        if (m_chatClient != null)
        {
            m_chatClient.Disconnect();
        }
        s_instance = null;
    }
    public void OnApplicationQuit()
    {
        if (m_chatClient != null)
        {
            m_chatClient.Disconnect();
        }
    }
    private void Update()
    {
        m_chatClient?.Service();
    }

    #endregion


    #region MyRegion
    public static void Connect()
    {
        s_instance.Internal_Connect();
    }
    public static void Disconnect()
    {
        s_instance.m_chatClient?.Disconnect();
        s_instance.m_chatClient = null;
    }
    public static void SendChatMessage(string a_message)
    {
        s_instance.Internal_SendChatMessage(a_message);
    }
    #endregion


    void Internal_Connect()
    {
        bool appIdPresent = !string.IsNullOrEmpty(m_chatAppSettings.AppIdChat);
        if (!appIdPresent)
        {
            Debug.LogError("ChatAppId Not Present");
        }


        m_chatClient = new ChatClient(this);
#if !UNITY_WEBGL
        m_chatClient.UseBackgroundWorkerForSending = true;
#endif
        m_chatClient.AuthValues = new AuthenticationValues(m_username);
        m_chatClient.ConnectUsingSettings(m_chatAppSettings);
        m_chatClient.ChatRegion = "ASIA";

        Debug.Log("Connecting as: " + m_username);
    }
    void HandleBackSlash(bool a_doingPrivateChat, string a_message)
    {
        string[] tokens = a_message.Split(new char[] { ' ' }, 2);
        if (tokens[0].Equals("\\help"))
        {
            // PostHelpToCurrentChannel();
        }
        if (tokens[0].Equals("\\state"))
        {
            int newState = 0;


            List<string> messages = new List<string>();
            messages.Add("i am state " + newState);
            string[] subtokens = tokens[1].Split(new char[] { ' ', ',' });

            if (subtokens.Length > 0)
            {
                newState = int.Parse(subtokens[0]);
            }

            if (subtokens.Length > 1)
            {
                messages.Add(subtokens[1]);
            }

            m_chatClient.SetOnlineStatus(newState, messages.ToArray()); // this is how you set your own state and (any) message
        }
        else if ((tokens[0].Equals("\\subscribe") || tokens[0].Equals("\\s")) && !string.IsNullOrEmpty(tokens[1]))
        {
            m_chatClient.Subscribe(tokens[1].Split(new char[] { ' ', ',' }));
        }
        else if ((tokens[0].Equals("\\unsubscribe") || tokens[0].Equals("\\u")) && !string.IsNullOrEmpty(tokens[1]))
        {
            m_chatClient.Unsubscribe(tokens[1].Split(new char[] { ' ', ',' }));
        }
        else if (tokens[0].Equals("\\clear"))
        {
            if (a_doingPrivateChat)
            {
                m_chatClient.PrivateChannels.Remove(m_selectedChannelName);
            }
            else
            {
                ChatChannel channel;
                if (m_chatClient.TryGetChannel(m_selectedChannelName, a_doingPrivateChat, out channel))
                {
                    channel.ClearMessages();
                }
            }
        }
        else if (tokens[0].Equals("\\msg") && !string.IsNullOrEmpty(tokens[1]))
        {
            string[] subtokens = tokens[1].Split(new char[] { ' ', ',' }, 2);
            if (subtokens.Length < 2) return;

            string targetUser = subtokens[0];
            string message = subtokens[1];
            m_chatClient.SendPrivateMessage(targetUser, message);
        }
        else if ((tokens[0].Equals("\\join") || tokens[0].Equals("\\j")) && !string.IsNullOrEmpty(tokens[1]))
        {
            string[] subtokens = tokens[1].Split(new char[] { ' ', ',' }, 2);

            //If we are already subscribed to the channel we directly switch to it, otherwise we subscribe to it first and then switch to it implicitly

            //..
        }
#if CHAT_EXTENDED
                else if ((tokens[0].Equals("\\nickname") || tokens[0].Equals("\\nick") ||tokens[0].Equals("\\n")) && !string.IsNullOrEmpty(tokens[1]))
                {
                    if (!doingPrivateChat)
                    {
                        m_chatClient.SetCustomUserProperties(selectedChannelName, m_chatClient.UserId, new Dictionary<string, object> {{"Nickname", tokens[1]}});
                    }

                }
#endif
        else
        {
            Debug.Log("The command '" + tokens[0] + "' is invalid.");
        }
    }
    public void Internal_SendChatMessage(string a_message)
    {
        if (string.IsNullOrEmpty(a_message))
        {
            return;
        }

        bool doingPrivateChat = m_chatClient.PrivateChannels.ContainsKey(m_selectedChannelName);
        string privateChatTarget = string.Empty;
        if (doingPrivateChat)
        {
            // the channel name for a private conversation is (on the client!!) always composed of both user's IDs: "this:remote"
            // so the remote ID is simple to figure out

            string[] splitNames = m_selectedChannelName.Split(new char[] { ':' });
            privateChatTarget = splitNames[1];
        }
        //UnityEngine.Debug.Log("selectedChannelName: " + selectedChannelName + " doingPrivateChat: " + doingPrivateChat + " privateChatTarget: " + privateChatTarget);


        if (a_message[0].Equals('\\'))
        {
            HandleBackSlash(doingPrivateChat, a_message);
        }
        else
        {
            if (doingPrivateChat)
            {
                m_chatClient.SendPrivateMessage(privateChatTarget, a_message);
            }
            else
            {
                m_chatClient.PublishMessage(m_selectedChannelName, a_message);
            }
        }
        Debug.Log("Message Sent!");
    }





    #region IChatClientListener IMPL

    public void DebugReturn(ExitGames.Client.Photon.DebugLevel level, string message)
    {
        if (level == ExitGames.Client.Photon.DebugLevel.ERROR)
        {
            Debug.LogError(message);
        }
        else if (level == ExitGames.Client.Photon.DebugLevel.WARNING)
        {
            Debug.LogWarning(message);
        }
        else
        {
            Debug.Log(message);
        }
    }
    public void OnConnected()
    {
        Debug.Log("OnConnected()");
        if (m_lstChannelsToJoinOnConnect != null && m_lstChannelsToJoinOnConnect.Count > 0)
        {
            m_chatClient.Subscribe(m_lstChannelsToJoinOnConnect.ToArray(), HistoryLengthToFetch);
        }


        if (m_lstFriendsList != null && m_lstFriendsList.Count > 0)
        {
            m_chatClient.AddFriends(m_lstFriendsList.ToArray()); // Add some users to the server-list to get their status updates



        }



        m_chatClient.SetOnlineStatus(ChatUserStatus.Online); // You can set your online state (without a mesage).
    }

    public void OnDisconnected()
    {
        Debug.Log("OnDisconnected()");
    }

    public void OnChatStateChange(ChatState state)
    {
        // use OnConnected() and OnDisconnected()
        // this method might become more useful in the future, when more complex states are being used.

        //StateText.text = state.ToString();
    }

    public void OnSubscribed(string[] channels, bool[] results)
    {
        // in this demo, we simply send a message into each channel. This is NOT a must have!
        foreach (string channel in channels)
        {
            // m_chatClient.PublishMessage(channel, "says 'hi'."); // you don't HAVE to send a msg on join but you could.


        }

        Debug.Log("OnSubscribed: " + string.Join(", ", channels));



        // Switch to the first newly created channel
        ShowChannel(channels[0]);
    }

    /// <inheritdoc />
    public void OnSubscribed(string channel, string[] users, Dictionary<object, object> properties)
    {
        //  Debug.LogFormat("OnSubscribed: {0}, users.Count: {1} Channel-props: {2}.", channel, users.Length, properties.ToStringFull());
    }




    public void OnUnsubscribed(string[] channels)
    {

    }
    public void OnGetMessages(string channelName, string[] senders, object[] messages)
    {
        if (channelName.Equals(m_selectedChannelName))
        {
            // update text
            ShowChannel(m_selectedChannelName);
        }
    }

    public void OnPrivateMessage(string sender, object message, string channelName)
    {
        // as the m_chatClient is buffering the messages for you, this GUI doesn't need to do anything here
        // you also get messages that you sent yourself. in that case, the channelName is determinded by the target of your msg
        InstantiateChannelButton(channelName);

        byte[] msgBytes = message as byte[];
        if (msgBytes != null)
        {
            Debug.Log("Message with byte[].Length: " + msgBytes.Length);
        }
        if (m_selectedChannelName.Equals(channelName))
        {
            ShowChannel(channelName);
        }
    }

    /// <summary>
    /// New status of another user (you get updates for users set in your friends list).
    /// </summary>
    /// <param name="user">Name of the user.</param>
    /// <param name="status">New status of that user.</param>
    /// <param name="gotMessage">True if the status contains a message you should cache locally. False: This status update does not include a
    /// message (keep any you have).</param>
    /// <param name="message">Message that user set.</param>
    public void OnStatusUpdate(string user, int status, bool gotMessage, object message)
    {

        Debug.LogWarning("status: " + string.Format("{0} is {1}. Msg:{2}", user, status, message));


    }

    public void OnUserSubscribed(string channel, string user)
    {
        Debug.LogFormat("OnUserSubscribed: channel=\"{0}\" userId=\"{1}\"", channel, user);
    }

    public void OnUserUnsubscribed(string channel, string user)
    {
        Debug.LogFormat("OnUserUnsubscribed: channel=\"{0}\" userId=\"{1}\"", channel, user);
    }

    /// <inheritdoc />
    public void OnChannelPropertiesChanged(string channel, string userId, Dictionary<object, object> properties)
    {
        //  Debug.LogFormat("OnChannelPropertiesChanged: {0} by {1}. Props: {2}.", channel, userId, Extensions.ToStringFull(properties));
    }

    public void OnUserPropertiesChanged(string channel, string targetUserId, string senderUserId, Dictionary<object, object> properties)
    {
        // Debug.LogFormat("OnUserPropertiesChanged: (channel:{0} user:{1}) by {2}. Props: {3}.", channel, targetUserId, senderUserId, Extensions.ToStringFull(properties));
    }

    /// <inheritdoc />
    public void OnErrorInfo(string channel, string error, object data)
    {
        Debug.LogFormat("OnErrorInfo for channel {0}. Error: {1} Data: {2}", channel, error, data);
    }

    public void AddMessageToSelectedChannel(string msg)
    {
        ChatChannel channel = null;
        bool found = m_chatClient.TryGetChannel(m_selectedChannelName, out channel);
        if (!found)
        {
            Debug.Log("AddMessageToSelectedChannel failed to find channel: " + m_selectedChannelName);
            return;
        }

        if (channel != null)
        {
            channel.Add("Bot", msg, 0); //TODO: how to use msgID?
        }
    }



    public static Action<string> OnGetChannelData;
    public void ShowChannel(string channelName)
    {
        if (string.IsNullOrEmpty(channelName))
        {
            return;
        }

        ChatChannel channel = null;
        bool found = m_chatClient.TryGetChannel(channelName, out channel);
        if (!found)
        {
            Debug.Log("ShowChannel failed to find channel: " + channelName);
            return;
        }

        m_selectedChannelName = channelName;
        string l_currentChannelData = channel.ToStringMessages();

        Debug.Log("ShowChannel: " + m_selectedChannelName);
        Debug.Log(l_currentChannelData);
        OnGetChannelData?.Invoke(l_currentChannelData);

    }

    #endregion

    private void InstantiateChannelButton(string channelName)
    {

    }

    private void InstantiateFriendButton(string friendId)
    {

    }
}
