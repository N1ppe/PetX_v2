using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GymMinigameAndDispencer : MonoBehaviour
{
    public type codeType;
    public statGained StatGained;
    GameObject gm;
    public bool inRange=false;
    public Text npcText;
    [Range(5,50)]
    public int TrainingCost;

	void Start ()
    {
        gm = GameObject.FindWithTag("GameManagementTag");
    }
	void Update ()
    {
        if(inRange == true)
        {
            if (codeType == type.TALKtOnPC)
            {
                if (gm.GetComponent<gamemanagement>().timeOfDay < 22)
                {
                    npcText.text = "Train a little !";

                    if(Input.GetButtonDown("interract") && gm.GetComponent<gamemanagement>().money>=5)
                    {
                        if (StatGained == statGained.strength) { gm.GetComponent<gamemanagement>().Pet.strength = gm.GetComponent<gamemanagement>().Pet.strength + 20; }
                        else if (StatGained == statGained.agility) { gm.GetComponent<gamemanagement>().Pet.agility = gm.GetComponent<gamemanagement>().Pet.agility + 20; }
                        else if (StatGained == statGained.wisdom) { gm.GetComponent<gamemanagement>().Pet.wisdom = gm.GetComponent<gamemanagement>().Pet.wisdom + 20; }
                        else if (StatGained == statGained.luck) { gm.GetComponent<gamemanagement>().Pet.luck = gm.GetComponent<gamemanagement>().Pet.luck + 20; }

                        gm.GetComponent<gamemanagement>().timeOfDay = gm.GetComponent<gamemanagement>().timeOfDay + 1;
                        gm.GetComponent<gamemanagement>().money = gm.GetComponent<gamemanagement>().money - TrainingCost;
                        return;
                    }
                }
                else
                {
                    npcText.text = "Can't train at this hour!, come back tomorrow !";//cant train anymore
                    return;
                }


            }
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
TALKtOnPC,minigame,dispencer
}
public enum statGained
{
    strength,agility,wisdom,luck
}
