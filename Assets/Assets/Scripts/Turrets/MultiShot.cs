using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiShot : Turret {

    [Header("Multi-Shot Settings")]
    public float[] shots;
    public float[] microReload;

	// Use this for initialization
	void Start () {
		
	}

    // Used to wait until the turret can shoot again
    protected override IEnumerator WaitForReload()
    {
        isShooting = true;
        yield return new WaitForSeconds(reloadSpeed[currentStage]);
        for (int i = 0; i < shots[currentStage]; i++)
        {
            Shoot();
            yield return new WaitForSeconds(microReload[currentStage]);
        }
        isShooting = false;
    }
}
