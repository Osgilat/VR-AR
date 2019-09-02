using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;
    
    
public class BlendShapeSyncList : NetworkBehaviour
{
    /*
    const short chatMsg = 1000;
    NetworkClient _client;
    
    [SerializeField]
    private SyncListInt chatLog = new SyncListInt();
    
    public override void OnStartClient()
    {
        chatLog.Callback = OnChatUpdated;
    }
    
    

    public SkinnedMeshRenderer skinnedMeshRenderer;
    
    public void Start()
    {
        _client = NetworkManager.singleton.client;
        NetworkServer.RegisterHandler(chatMsg, OnServerPostChatMessage);   
        InvokeRepeating(PostChatMessage());   
    }
    
    [Client]
    public void PostChatMessage(string message)
    {
        if (message.Length == 0) return;
        var msg = new StringMessage(message);
        _client.Send(chatMsg, msg);
            
        input.text = "";
        input.ActivateInputField();
        input.Select();
    }
    
    [Server]
    void OnServerPostChatMessage(NetworkMessage netMsg) 
    {
        string message = netMsg.ReadMessage<StringMessage>().value;
        chatLog.Add(message);
                   
    }
    
    private void OnChatUpdated(SyncListString.Operation op, int index)
    {
        chatline.text += chatLog[chatLog.Count-1] + "\n";
    }
    
   */    
}