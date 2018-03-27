using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class npcColliderVersion : MonoBehaviour {

    public GameObject screenCanvas;
    public bool seenThisNpc = false;

    public string NPC_name;
    [TextArea(1, 15)]
    public string[] texts;

    void Start ()
    {
		
	}
	void Update ()
    {
        nextTextButton();
	}
    public void nextTextButton()
    {
        if (seenThisNpc == true && Input.GetKeyDown(KeyCode.Space))
        {
            nextText();
        }
    }
    public void nextText()
    {
        for(int y = 0; y < texts.Length; y++)
        {
            if(screenCanvas.GetComponentInChildren<Text>().text == texts[y])
            {
                if (y < texts.Length && y != texts.Length - 1)
                {
                    screenCanvas.GetComponentInChildren<Text>().text = texts[y + 1];
                    return;
                }
                else
                {
                    seenThisNpc = false;
                    screenCanvas.SetActive(false);
                    screenCanvas.GetComponentInChildren<Text>().text = "";
                }
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        seenThisNpc = true;

        screenCanvas.SetActive(true);
        //screenCanvas.GetComponentInChildren<Text>().text = "Sanon jotain, kun tulet lähelleni.";
        screenCanvas.GetComponentInChildren<Text>().text = texts[0];
    }
    void OnTriggerExit2D(Collider2D other)
    {
        seenThisNpc = false;
        screenCanvas.SetActive(false);
        screenCanvas.GetComponentInChildren<Text>().text = "";
    }
}
