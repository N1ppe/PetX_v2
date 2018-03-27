using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class npc : MonoBehaviour {

    public bool useAltTextBox;
    [TextArea(1, 15)]
    public string shortDialog;
    public GameObject player;
    public float distToPlayer;
    public GameObject npcTextBox,screenCanvas;
    public bool seenThisNpc=false;
    public GameObject skinHolder;
    public Image[] npcprites;
    
    protected float angle;

    void Start ()
    {	
	}
	void Update ()
    {
        distToPlayer = Vector3.Distance(this.transform.position, player.transform.position);
        if (distToPlayer<4) { lookToPlayerSide(); }

        if (useAltTextBox == false)
        {
            if (distToPlayer < 3)
            {
                npcTextBox.SetActive(true);
                npcTextBox.GetComponentInChildren<Text>().text = shortDialog;
                seenThisNpc = true;
            }
            else if (seenThisNpc == true && distToPlayer > 3)
            {
                npcTextBox.SetActive(false);
                npcTextBox.GetComponentInChildren<Text>().text = "";
            }
        }
        else if(useAltTextBox == true)
        {
            if (distToPlayer < 3 && Input.GetKeyDown(KeyCode.Space))
            {
                screenCanvas.SetActive(true);
                screenCanvas.GetComponentInChildren<Text>().text = "Tässä on dialogi.";
                seenThisNpc = true;
            }
            else if (seenThisNpc == true && distToPlayer > 3)
            {
                screenCanvas.SetActive(false);
                screenCanvas.GetComponentInChildren<Text>().text = "";
            }
        }
    }
    public void lookToPlayerSide()
    {
        Vector2 player_relative_to_enemy = this.gameObject.transform.position - player.transform.position;
        player_relative_to_enemy.Normalize();
        angle = Mathf.Atan2(player_relative_to_enemy.x, player_relative_to_enemy.y);
        /*
        if(angle>2f && angle > -2.2f) { Debug.Log("up"); }
        else if (angle < 1f && angle > -1f) { Debug.Log("down"); }
        else if (angle > 1f && angle < 3f) { Debug.Log("left"); }
        else if (angle > -2.25f && angle < -0.75f) { Debug.Log("right"); }
        */
        /*
        if ((angle < (-Mathf.PI/4)*3 && angle > -Mathf.PI)||(angle > (Mathf.PI / 4) * 3 && angle < Mathf.PI))
        { Debug.Log("up"); skinHolder.GetComponent<SpriteRenderer>().sprite = npcprites[0].sprite; }
        if (angle > (-Mathf.PI / 4) && angle < (Mathf.PI / 4))
        { Debug.Log("down"); skinHolder.GetComponent<SpriteRenderer>().sprite = npcprites[1].sprite; }
        if (angle > (Mathf.PI / 4) && angle < (Mathf.PI / 4) * 3)
        { Debug.Log("left"); skinHolder.GetComponent<SpriteRenderer>().sprite = npcprites[2].sprite; }
        if ((angle > (-Mathf.PI / 4) * 3 && angle < (-Mathf.PI / 4)))
        { Debug.Log("right"); skinHolder.GetComponent<SpriteRenderer>().sprite = npcprites[3].sprite; }
        */
    }
}