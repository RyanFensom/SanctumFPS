using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Turret : MonoBehaviour
{
    [Header("Turret Settings")]
    public GameObject barrelPrefab;
    public GameObject bullet;
    public int currentStage;
    public float[] radius, damage, bulletSpeed, reloadSpeed;
    public int[] upgradeCost;
    public Transform target;
    public Transform shootPos;
    public float turnSpeed;

    protected Player player;
    protected Collider[] enemy;    
    protected bool isShooting;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("PlayerController").GetComponent<Player>();
        currentStage = 0;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        FindEnemy();
        LoadAndShoot();                     
    }    

    // Used to check the turret's radius for enemies
    protected void FindEnemy()
    {
        enemy = Physics.OverlapSphere(transform.position, radius[currentStage], 9);

        for (int i = 0; i < enemy.Length; i++)
        {
            if (enemy[i].tag == "Enemy")
            {
                target = enemy[i].transform;
                TurnToEnemy();                
            }
        }
    }

    // Used to rotate towards an enemy within the turret's radius
    protected void TurnToEnemy()
    {
        Vector3 targetDir = target.position - transform.position;
        float step = turnSpeed * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
        transform.rotation = Quaternion.LookRotation(newDir);
    }
    
    // Used to shoot enemies within the radius of the turret
    protected virtual void Shoot()
    {
        Instantiate(bullet, transform.position, transform.rotation, shootPos);
    }

    // Used to wait until the turret can shoot again
    protected virtual IEnumerator WaitForReload()
    {
        isShooting = true;
        yield return new WaitForSeconds(reloadSpeed[currentStage]);
        Shoot();
        isShooting = false;
    }

    // Used to run WaitForReload() only after shooting
    protected void LoadAndShoot()
    {
        if (!isShooting)
        {
            StartCoroutine("WaitForReload");
        }
    }

    // Used to test if the player has enough money to upgrade
    protected bool CanUpgrade()
    {
        if (player.score >= upgradeCost[currentStage])
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // Used to upgrade turrets
    protected virtual void Upgrade()
    {
        if (CanUpgrade())
        {
            player.score -= upgradeCost[currentStage];
            currentStage++;
        }
        
    }
}
