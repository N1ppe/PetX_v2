using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerItems : MonoBehaviour
{
    GameObject gm;

	void Start ()
    {
        gm = GameObject.FindWithTag("GameManagementTag");
    }
	void Update ()
    {
		
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "item")
        {
            for (int i = 0; i < gm.GetComponent<gamemanagement>().AllItems.Length; i++)
            {
                if(other.gameObject.name == gm.GetComponent<gamemanagement>().AllItems[i].name)
                {
                    for (int u = 0; u < gm.GetComponent<gamemanagement>().playersBackpack.Length; u++)
                    {
                        if (gm.GetComponent<gamemanagement>().playersBackpack[u].name == "")
                        {
                            gm.GetComponent<gamemanagement>().playersBackpack[u] = gm.GetComponent<gamemanagement>().AllItems[i];
                            Destroy(other.gameObject);
                            return;
                        }
                    }
                }
            }
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {

    }
}
