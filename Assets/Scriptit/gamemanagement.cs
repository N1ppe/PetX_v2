using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gamemanagement : MonoBehaviour {

    GameObject player;
    [Header("World")]
    public int day;
    [Range(0,1000)]
    public int money;
    [Range(0, 100)]
    public float mana;
    public Image uIStamina, uIMana,petUIimage;
    public Sprite lukkoImg;
    float manaCalculated,staminaCalculated;
    public Text cashText;
    [Range(0,24)]
    public int timeOfDay;
    public Sprite[] timeVisuals;
    public Image kello;
    public Text dayText;
    [Header("__________________________")]
    public Monsters Pet;
    public Items chosenItem;
    public ItemsInBackpackClass[] playersBackpack;
    [Header("__________________________")]
    //lists / arrays I dont fucking know
    [Range(1,20)]
    public int CurrentPetInt;
    public Monsters[] AllMonsters;
    public Buffs[] buffs;
    public Items[] AllItems;
    public houses[] enterableBuildings;
    public GameObject evolvingCanvas;
    public Image petImg, petNextEvolveImg,animation;
    public Text[] reppuText;
    public Image reppuItemImg;

	void Start () {
        player = GameObject.FindWithTag("Player");
        Pet = AllMonsters[0];
        //Cursor.visible = false;
        //StartCoroutine(evolutionUI());
        reppuVisuals();
	}
	void Update ()
    {
        petChangingInRuntime();
        statPetEvolutions();//----------------------------------hard code pakko---------------------------------

        clockChanger();
        moneyCounter();
        staminaBar();
        manaBar();
	}
    public void clockChanger()
    {
        dayText.text = day.ToString();
        if (timeOfDay < 12)
        {
            for (int t = 0; t < timeVisuals.Length; t++)
            {
                if (t == timeOfDay) { kello.sprite = timeVisuals[t]; }
            }
        }
        else if(timeOfDay >= 12)
        {
            if (timeOfDay == 12) { kello.sprite = timeVisuals[0]; }
            if (timeOfDay == 13) { kello.sprite = timeVisuals[1]; }
            if (timeOfDay == 14) { kello.sprite = timeVisuals[2]; }
            if (timeOfDay == 15) { kello.sprite = timeVisuals[3]; }
            if (timeOfDay == 16) { kello.sprite = timeVisuals[4]; }
            if (timeOfDay == 17) { kello.sprite = timeVisuals[5]; }
            if (timeOfDay == 18) { kello.sprite = timeVisuals[6]; }
            if (timeOfDay == 19) { kello.sprite = timeVisuals[7]; }
            if (timeOfDay == 20) { kello.sprite = timeVisuals[8]; }
            if (timeOfDay == 21) { kello.sprite = timeVisuals[9]; }
            if (timeOfDay == 22) { kello.sprite = timeVisuals[10]; }
            if (timeOfDay == 23) { kello.sprite = timeVisuals[11]; }
            if (timeOfDay == 24) { kello.sprite = timeVisuals[0]; }
        }
    }
    public void moneyCounter()
    {
        cashText.text = "Money: " + money;
    }
    public void manaBar()
    {
        manaCalculated = mana / 100f;
        uIMana.fillAmount = manaCalculated;
    }
    public void staminaBar()
    {
        staminaCalculated = player.GetComponent<playerMovement>().stamina / 100f;
        uIStamina.fillAmount =staminaCalculated;
    }
    public void currentPetAttackGain()
    {
        for (int i = 0; i < AllMonsters.Length; i++)
        {
            if (i == CurrentPetInt)
            {
               AllMonsters[i - 1].strength += 1;
            }
        }
    }
    public void sleepBehavior()
    {
        //do pet evolution scene
    }
    public void reppuVisuals()
    {
        for(int e = 0; e < AllItems.Length; e++)
        {
            for (int t = 0; t < playersBackpack.Length; t++)
            {
                if (playersBackpack[t].name == AllItems[e].name)
                {
                    // playersBackpack[t] = AllItems[e];
                    playersBackpack[t].name = AllItems[e].name;
                    playersBackpack[t].description = AllItems[e].description;
                    playersBackpack[t].amount = AllItems[e].amount;
                    playersBackpack[t].itemPropertyInt = AllItems[e].itemPropertyInt;
                    playersBackpack[t].sellCost = AllItems[e].sellCost;
                    playersBackpack[t].itemImage = AllItems[e].itemImage;
                }
            }
        }
        for(int r = 0; r < 10; r++)
        {
            reppuText[r].text = playersBackpack[r].name;
            reppuItemImg.sprite = playersBackpack[0].itemImage;
        }
    }
    public void petChangingInRuntime()
    {
        for (int r = 0; r < AllMonsters.Length; r++)
        {
            if (r == CurrentPetInt-1)
            {
                Pet = AllMonsters[r];
            }
        }
    }
    public void statPetEvolutions()//----------------------------------hard code what pet stat allows what next evolution----------------------------------
    {

        for (int r = 0; r < AllMonsters.Length; r++)
        {
            if (AllMonsters[r].allowEvolution == true)
            {
                AllMonsters[r].inMonsterCatalog.sprite = AllMonsters[r].petVisual;
            }
            else if (AllMonsters[r].allowEvolution == false) { AllMonsters[r].inMonsterCatalog.sprite = lukkoImg; }
        }


        if (CurrentPetInt == 1)
        {
            if (Pet.strength == 100) { AllMonsters[2].allowEvolution = true; }
            if (Pet.agility == 100) { }
            if (Pet.wisdom == 100) { }
            if (Pet.luck == 1000) { }
        }
    }
    IEnumerator evolutionUI()
    {
        petImg.sprite = Pet.petVisual;
        //petNextEvolveImg = 
        petImg.GetComponent<Image>().enabled = true;

        evolvingCanvas.SetActive(true);
        animation.GetComponent<Image>().enabled = true;
        //play animation on top
        yield return new WaitForSeconds(1f);
        petImg.GetComponent<Image>().enabled = false;
        petNextEvolveImg.GetComponent<Image>().enabled = true;
        animation.GetComponent<Image>().enabled = false;
        yield return new WaitForSeconds(1.5f);
        evolvingCanvas.SetActive(false);
    }
}
[System.Serializable]
public class Monsters
{
    public string name, description;
    public int strength, agility, wisdom , luck;    //upgradable stats
    public int health, hunger, happyness, cleaniness;    //beauty
    public bool allowEvolution = false;
    public Sprite petVisual;
    public Image inMonsterCatalog;
    public GameObject petInWorldPrefab;
}
[System.Serializable]
public class Buffs
{
    public string name, description;
    public int buffPropertyInt;
    public bool buffBool;
}
[System.Serializable]
public class ItemsInBackpackClass
{
    public string name, description;
    public int amount, itemPropertyInt, sellCost;
    public Sprite itemImage;
}
[System.Serializable]
public class Items
{
    public string name, description;
    public int amount,itemPropertyInt,sellCost;
    public Sprite itemImage;
}
[System.Serializable]
public class houses
{
    public string name;
    public int sceneIndex;
    public Vector3 locationOnMap;
}