using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player : NetworkBehaviour
{
    [SyncVar]
    public int score = 0;
    public float moveSpeed = 10f;
    public Rigidbody rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isLocalPlayer)
        {
            transform.position += new Vector3(Input.GetAxisRaw("Horizontal") / moveSpeed, 0, Input.GetAxisRaw("Vertical") / moveSpeed);

            // Used for rotating to mouse position 
            Vector3 targetDir = Input.mousePosition - transform.position;
            float step = moveSpeed * Time.deltaTime;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDir);         
        }
    }

    /*
    // Used for purchasing turrets
    private bool CanBuyTurret(int score, int selectedTurret)
    {

    }*/
}
