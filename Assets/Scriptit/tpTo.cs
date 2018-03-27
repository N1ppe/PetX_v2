using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tpTo : MonoBehaviour {

    public Vector2 tpToThisVectorPos;

	void Start ()
    {
		
	}
	void Update ()
    {
		
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.transform.position = tpToThisVectorPos;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
    }
}