using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SyncWithNetwork : NetworkBehaviour
{
    [SyncVar]
    Vector3 localPos = Vector3.zero;
    [SyncVar]
    Quaternion localRot;
    private float syncCycle;

    // Update is called once per frame
    void Update()
    {
        if (isLocalPlayer)
        {
            // Sync position and rotation on server
            syncCycle -= Time.deltaTime;

            if (syncCycle <= 0)
            {
                syncCycle = 0.1f;

                CmdSync(transform.position, transform.rotation);
            }
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, localPos, 0.1f);
            transform.rotation = Quaternion.Lerp(transform.rotation, localRot, 0.1f);
        }
    }


    // Used to sync variables
    [Command]
    void CmdSync(Vector3 position, Quaternion rotation)
    {
        localPos = position;
        localRot = rotation;
    }
}
