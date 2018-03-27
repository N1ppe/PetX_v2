using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GymMinigameAndDispencer : MonoBehaviour
{
    public type codeType;
    public statGained StatGained;
    GameObject gm;
    public bool inRange=false;

	void Start ()
    {
        gm = GameObject.FindWithTag("GameManagementTag");
    }
	void Update ()
    {
        if(inRange == true)
        {
            if (codeType == type.minigame)
            {

            }
            if (codeType == type.dispencer)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    rightStat();
                }
            }
        }
    }
    public void rightStat()
    {
        if (StatGained == statGained.strength) { gm.GetComponent<gamemanagement>().Pet.strength ++; }
        else if (StatGained == statGained.agility) { gm.GetComponent<gamemanagement>().Pet.agility ++; }
        else if (StatGained == statGained.wisdom) { gm.GetComponent<gamemanagement>().Pet.wisdom ++; }
        else if (StatGained == statGained.luck) { gm.GetComponent<gamemanagement>().Pet.luck ++; }
    }
    public void sendStats()
    {
        for (int statloopnro = 0; statloopnro < gm.GetComponent<gamemanagement>().AllMonsters.Length; statloopnro++)
        {

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            inRange = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            inRange = false;
        }
    }
}
public enum type
{
minigame,dispencer
}
public enum statGained
{
    strength,agility,wisdom,luck
}
