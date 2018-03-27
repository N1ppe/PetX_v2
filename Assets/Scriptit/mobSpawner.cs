using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mobSpawner : MonoBehaviour {

    public enemiesToSpawn[] EnemiesToSpawn;

	void Start ()
    {
        InvokeRepeating("deadMobTestingLoop", 1, 2);
	}
	void Update ()
    {	
	}
    public void deadMobTestingLoop()
    {
        for(int u = 0; u < EnemiesToSpawn.Length; u++)
        {
            if(EnemiesToSpawn[u].enemyInWorld == null)
            {
                EnemiesToSpawn[u].enemyInWorld = Instantiate(EnemiesToSpawn[u].enemyToSpawn, EnemiesToSpawn[u].posToSpawnAt,Quaternion.identity);
                //EnemiesToSpawn[u].mobAlive = true;
            }
        }
    }
}
[System.Serializable]
public class enemiesToSpawn
{
    public GameObject enemyToSpawn,enemyInWorld;
    public Vector3 posToSpawnAt;
}
