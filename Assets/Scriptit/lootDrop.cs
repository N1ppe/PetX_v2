using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lootDrop : MonoBehaviour
{
    
    public GameObject gm;
    public string lootName;
    public GameObject lootPrefab;

	void Start ()
    {
        gm = GameObject.FindWithTag("GameManagementTag");
	}
	void Update ()
    {
	}
    public void itemAssigningAndSpawn()
    {
        GameObject spawnedLoot = Instantiate(lootPrefab, this.gameObject.transform.position, Quaternion.identity);

        for (int u = 0; u < gm.GetComponent<gamemanagement>().AllItems.Length; u++)
        {
            if(lootName == gm.GetComponent<gamemanagement>().AllItems[u].name)
            {
                spawnedLoot.name = gm.GetComponent<gamemanagement>().AllItems[u].name;
                spawnedLoot.GetComponentInChildren<SpriteRenderer>().sprite = gm.GetComponent<gamemanagement>().AllItems[u].itemImage;
                
            }
        }   
    }
}