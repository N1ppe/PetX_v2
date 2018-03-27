using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectDisabler : MonoBehaviour {

    public GameObject objectToDisable;
    public bool setToDestroy;

	void Start ()
    {
        if (setToDestroy == true)
        {
            StartCoroutine(timer());
        }
	}
	void Update ()
    {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && setToDestroy ==false)
        {
            objectToDisable.SetActive(false);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && setToDestroy == false)
        {
            objectToDisable.SetActive(true);
        }
    }
    IEnumerator timer()
    {
        yield return new WaitForSeconds(30);
        Destroy(this.gameObject);
    }
}
