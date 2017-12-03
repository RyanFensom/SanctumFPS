using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Weapon : NetworkBehaviour
{
    public GameObject gun;
    public float damage = 2f;
    public float fireRate = 1f;
    public float fireDelay = 0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isLocalPlayer)
        {
            if (Input.GetButton("Mouse 0") && Time.time >= fireDelay)
            {
                fireDelay = Time.time + fireRate;
                CmdShoot();
            }
        }
    }

    [ClientRpc]
    void RpcShoot()
    {
        Vector3 shotPoint = gun.transform.TransformDirection(Vector3.forward);
        RaycastHit hit;

        if (Physics.Raycast(transform.position, shotPoint, out hit))
        {
            if (hit.transform.tag == "Enemy")
            {
                hit.transform.gameObject.GetComponent<Enemy>().health -= damage;
                GetComponentInParent<Player>().score++;
                Debug.Log("hit.transform.name");
            }
            else if (hit.transform.tag == "turretPlace" && GetComponent<Player>().score >= Get)
            {

            }
            
        }
    }

    [Command]
    void CmdShoot()
    {
        RpcShoot();
    }
}
