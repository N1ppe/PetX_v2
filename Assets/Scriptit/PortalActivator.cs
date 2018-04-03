using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortalActivator : MonoBehaviour {

    public bool isActive = false;
    public GameObject Active;
    public SpriteRenderer InActive;
    public GameObject mapActive;
    public Image mapInActive;

	void Start () {
        
	}
	
	void Update () {

        if (isActive)
        {
            InActive.enabled = false;
            Active.SetActive(true);

            mapInActive.enabled = false;
            mapActive.SetActive(true);
        }

	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isActive = true;
    }
}
