using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class playerButtonControl : MonoBehaviour {

    public gamemanagement gm;
    public GameObject evolves,reppu,map,sleep;
    public Vector3 bedPosition;
    public openCanvas openWindow;
    public GameObject pet;
    [Range(0,11)]
    public int waypointIntToMoveTo;
    public mapWaypoints[] waypoints;

	void Start ()
    {
        pet = GameObject.FindWithTag("Pet");
    }
	void Update ()
    {
        playerOtherButtons();
        bb();
    }
    public void playerOtherButtons()
    {
        if(Input.GetButtonDown("evolutions"))
        {
            if (openWindow==openCanvas.evolutions)//is activated
            {
                evolves.SetActive(false);
                Time.timeScale = 1;
                Cursor.visible = false;
                openWindow = openCanvas.NONE;
            }
            else if(openWindow == openCanvas.NONE)
            {
                evolves.SetActive(true);
                Time.timeScale = 0;
                Cursor.visible = true;
                openWindow = openCanvas.evolutions;
            }
        }
        if (Input.GetButtonDown("reppu"))
        {
            if (openWindow == openCanvas.reppu)//is activated
            {
                reppu.SetActive(false);
                Time.timeScale = 1;
                Cursor.visible = false;
                openWindow = openCanvas.NONE;
            }
            else if (openWindow == openCanvas.NONE)
            {
                gm.GetComponent<gamemanagement>().reppuVisuals();
                reppu.SetActive(true);
                Time.timeScale = 0;
                Cursor.visible = true;
                openWindow = openCanvas.reppu;
            }
        }
        if (Input.GetButtonDown("map"))
        {
            if (openWindow == openCanvas.map)//is activated
            {
                map.SetActive(false);
                Time.timeScale = 1;
                Cursor.visible = false;
                openWindow = openCanvas.NONE;
            }
            else if (openWindow == openCanvas.NONE)
            {
                map.SetActive(true);
                Time.timeScale = 0;
                Cursor.visible = true;
                openWindow = openCanvas.map;
            }
        }
    }
    public void bb()
    {
        if(EventSystem.current.currentSelectedGameObject != null)
        {
            for (int g = 0; g < 10; g++)
            {
                if (EventSystem.current.currentSelectedGameObject.name == "b"+g.ToString())
                {
                    gm.chosenItem = gm.playersBackpack[g-1];
                    gm.GetComponent<gamemanagement>().reppuItemImg.sprite = gm.playersBackpack[g - 1].itemImage;
                }
            }
        }
    }
    public void MonsterCatalog()
    {
        if (EventSystem.current.currentSelectedGameObject != null)
        {
            for (int u = 0; u < gm.GetComponent<gamemanagement>().AllMonsters.Length; u++)
            {
                if(gm.GetComponent<gamemanagement>().AllMonsters[u].petInWorldPrefab != null)
                {
                    gm.GetComponent<gamemanagement>().AllMonsters[u].petInWorldPrefab.SetActive(false);
                }
            }
            for (int g = 0; g < gm.GetComponent<gamemanagement>().AllMonsters.Length; g++)
            {
                if (EventSystem.current.currentSelectedGameObject.name == gm.GetComponent<gamemanagement>().AllMonsters[g].name)
                {
                    Debug.Log(EventSystem.current.currentSelectedGameObject.name);
                    gm.GetComponent<gamemanagement>().Pet = gm.GetComponent<gamemanagement>().AllMonsters[g];
                    gm.GetComponent<gamemanagement>().AllMonsters[g].petInWorldPrefab.SetActive(true);
                }
            }
        }
    }
    #region mapButtons
    public void mapW1() { waypointIntToMoveTo = 1; waypointTp(); }
    public void mapW2() { waypointIntToMoveTo = 2; waypointTp(); }
    public void mapW3() { waypointIntToMoveTo = 3; waypointTp(); }
    public void mapW4() { waypointIntToMoveTo = 4; waypointTp(); }
    public void mapW5() { waypointIntToMoveTo = 5; waypointTp(); }
    public void mapW6() { waypointIntToMoveTo = 6; waypointTp(); }
    public void mapW7() { waypointIntToMoveTo = 7; waypointTp(); }
    public void mapW8() { waypointIntToMoveTo = 8; waypointTp(); }
    public void mapW9() { waypointIntToMoveTo = 9; waypointTp(); }
    public void mapW10() { waypointIntToMoveTo = 10; waypointTp(); }
#endregion
    public void waypointTp()
    {
        for(int p = 1; p < 11; p++)
        {
            if (p == waypointIntToMoveTo)
            {
                if(waypoints[p - 1].unlocked == true)
                {
                    this.gameObject.transform.position = waypoints[p - 1].loc;
                    pet.gameObject.transform.position = waypoints[p - 1].loc;
                }
            }
        }
        waypointIntToMoveTo = 0;
    }

    public void sleepButton()
    {
        this.gameObject.transform.position = bedPosition;
        pet.gameObject.transform.position = bedPosition;
        sleep.gameObject.SetActive(false);
        gm.GetComponent<gamemanagement>().day++;
        Cursor.visible = false; Time.timeScale = 1;
    }
    public void exitSleepWindow() { sleep.gameObject.SetActive(false); Cursor.visible = false; Time.timeScale = 1; }
#region selectPetButtons
    public void m1() { gm.GetComponent<gamemanagement>().CurrentPetInt = 1; }
    public void m2() { gm.GetComponent<gamemanagement>().CurrentPetInt = 2; }
    public void m3() { gm.GetComponent<gamemanagement>().CurrentPetInt = 3; }
    public void m4() { gm.GetComponent<gamemanagement>().CurrentPetInt = 4; }
    public void m5() { gm.GetComponent<gamemanagement>().CurrentPetInt = 5; }

    public void m6() { gm.GetComponent<gamemanagement>().CurrentPetInt = 6; }
    public void m7() { gm.GetComponent<gamemanagement>().CurrentPetInt = 7; }
    public void m8() { gm.GetComponent<gamemanagement>().CurrentPetInt = 8; }
    public void m9() { gm.GetComponent<gamemanagement>().CurrentPetInt = 9; }
    public void m10() { gm.GetComponent<gamemanagement>().CurrentPetInt = 10; }

    public void m11() { gm.GetComponent<gamemanagement>().CurrentPetInt = 11; }
    public void m12() { gm.GetComponent<gamemanagement>().CurrentPetInt = 12; }
    public void m13() { gm.GetComponent<gamemanagement>().CurrentPetInt = 13; }
    public void m14() { gm.GetComponent<gamemanagement>().CurrentPetInt = 14; }
    public void m15() { gm.GetComponent<gamemanagement>().CurrentPetInt = 15; }

    public void m16() { gm.GetComponent<gamemanagement>().CurrentPetInt = 16; }
    public void m17() { gm.GetComponent<gamemanagement>().CurrentPetInt = 17; }
    public void m18() { gm.GetComponent<gamemanagement>().CurrentPetInt = 18; }
    public void m19() { gm.GetComponent<gamemanagement>().CurrentPetInt = 19; }
    public void m20() { gm.GetComponent<gamemanagement>().CurrentPetInt = 20; }
    #endregion
}
[System.Serializable]
public class mapWaypoints
    {
    public string locationName;
    public bool unlocked = false;
    public Vector3 loc;
    }
public enum openCanvas
{
NONE,evolutions,reppu,map
}