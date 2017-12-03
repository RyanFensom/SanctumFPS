using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SingleplayerManager : NetworkManager
{
    // Use this for initialization
    void Awake()
    {
        maxConnections = -1;
        // Ensure any matchmaking has stopped
        if (matchMaker != null)
        {
            StopMatchMaker();
        }
            
        if (!IsClientConnected() && !NetworkServer.active && matchMaker == null)
            StartHost();  
    }
}
