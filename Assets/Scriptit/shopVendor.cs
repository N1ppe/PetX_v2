using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class shopVendor : MonoBehaviour
{
    public GameObject shopCanvas,sellCanvas;
    public Image shopItemImg,sellItemImg;
    GameObject gm;
    string shopitemnametemp;
    bool allowBuy = false;
    public itemsInShop[] buyButtons,sellButtons;
    public int itemToBuyINT=10,itemToSellINT=10;

	void Start ()
    {
        gm = GameObject.FindWithTag("GameManagementTag");
    }
	void Update ()
    {
        if (EventSystem.current.currentSelectedGameObject != null)
        {
            if (EventSystem.current.currentSelectedGameObject.name == "sell1") { itemToSellINT = 0; }
            if (EventSystem.current.currentSelectedGameObject.name == "sell2") { itemToSellINT = 1; }
            if (EventSystem.current.currentSelectedGameObject.name == "sell3") { itemToSellINT = 2; }
            if (EventSystem.current.currentSelectedGameObject.name == "sell4") { itemToSellINT = 3; }
            if (EventSystem.current.currentSelectedGameObject.name == "sell5") { itemToSellINT = 4; }
            if (EventSystem.current.currentSelectedGameObject.name == "sell6") { itemToSellINT = 5; }
            if (EventSystem.current.currentSelectedGameObject.name == "sell7") { itemToSellINT = 6; }
            if (EventSystem.current.currentSelectedGameObject.name == "sell8") { itemToSellINT = 7; }
            if (EventSystem.current.currentSelectedGameObject.name == "sell9") { itemToSellINT = 8; }
            if (EventSystem.current.currentSelectedGameObject.name == "sell10") { itemToSellINT = 9; }
        }
    }
    #region vendorButtons
    public void v1() { itemToBuyINT = 0; itemPictures(); }
    public void v2() { itemToBuyINT = 1; itemPictures(); }
    public void v3() { itemToBuyINT = 2; itemPictures(); }
    public void v4() { itemToBuyINT = 3; itemPictures(); }
    public void v5() { itemToBuyINT = 4; itemPictures(); }
    public void v6() { itemToBuyINT = 5; itemPictures(); }
    public void v7() { itemToBuyINT = 6; itemPictures(); }
    public void v8() { itemToBuyINT = 7; itemPictures(); }
    public void v9() { itemToBuyINT = 8; itemPictures(); }
    public void v10() { itemToBuyINT = 9; itemPictures(); }
    public void Buy()
    {
        allowBuy = true;
        wendorItemBuying();
    }
    public void exit()
    {
        shopCanvas.SetActive(false);
        sellCanvas.SetActive(false);
        Cursor.visible = false;
        Time.timeScale = 1;
    }
    //sell screen
    public void sell()//    THIS THING HERE IS SO FUCKED UP, GOD DAIAMN , DELETES ALL IF MANY SAME ITEMS , update: if you remove 1 item all duplicated are deleted too
    {
        sellSCreenImages();

            //itemToSellINT = 10;
            Debug.Log("SOLD A THING");

        for (int y = 0; y < gm.GetComponent<gamemanagement>().AllItems.Length; y++)
        {
            //saman niminen item allitems listalta
            if (gm.GetComponent<gamemanagement>().AllItems[y].name == sellButtons[itemToSellINT].itemNameHolder.text)
            {
                gm.GetComponent<gamemanagement>().money = gm.GetComponent<gamemanagement>().money + sellButtons[itemToSellINT].cost;
                sellButtons[itemToSellINT].itemNameHolder.text = "";
                gm.GetComponent<gamemanagement>().playersBackpack[itemToSellINT].name = "";
                gm.GetComponent<gamemanagement>().playersBackpack[itemToSellINT].description = "";
                gm.GetComponent<gamemanagement>().playersBackpack[itemToSellINT].itemPropertyInt = 0;
                gm.GetComponent<gamemanagement>().playersBackpack[itemToSellINT].sellCost = 0;
                gm.GetComponent<gamemanagement>().playersBackpack[itemToSellINT].itemImage = null;
                sellSCreenImages();
                
                for (int intti = 0; intti < 10; intti++)
                {
                    sellButtons[intti].itemNameHolder.text = gm.GetComponent<gamemanagement>().playersBackpack[intti].name;
                    if (gm.GetComponent<gamemanagement>().playersBackpack[intti].name == sellButtons[intti].itemNameHolder.text)
                    { sellButtons[intti].cost = gm.GetComponent<gamemanagement>().playersBackpack[intti].sellCost; }
                }
                
                y = gm.GetComponent<gamemanagement>().AllItems.Length;
                itemToSellINT = 10;
                Debug.Log("SOLD A THING");
            }
            //Debug.Log("loop times "+y);
        }


        sellSCreenImages();
    }
    public void toSellScreen()
    {
        shopCanvas.SetActive(false);
        sellCanvas.SetActive(true);
        for (int intti = 0; intti < 10; intti++)
        {
            sellButtons[intti].itemNameHolder.text = gm.GetComponent<gamemanagement>().playersBackpack[intti].name;
            if(gm.GetComponent<gamemanagement>().playersBackpack[intti].name == sellButtons[intti].itemNameHolder.text)
            { sellButtons[intti].cost = gm.GetComponent<gamemanagement>().playersBackpack[intti].sellCost; }
        }
        sellSCreenImages();
    }
    public void backToBuyScreen()
    {
        sellCanvas.SetActive(false);
        shopCanvas.SetActive(true);
    }
    #endregion
    public void wendorItemBuying()
    {
        for (int p = 0; p < 10; p++)
        {//valittu tuote listalta
            if (p == itemToBuyINT)
            {
                for (int y=0;y< gm.GetComponent<gamemanagement>().AllItems.Length; y++)
                {
                    //saman niminen item allitems listalta
                    if (gm.GetComponent<gamemanagement>().AllItems[y].name == buyButtons[p].itemNameHolder.text)
                    {
                        for (int u = 0; u < gm.GetComponent<gamemanagement>().playersBackpack.Length; u++)
                        {//space in backpack
                            if(gm.GetComponent<gamemanagement>().playersBackpack[u] != null)
                            {
                                if (gm.GetComponent<gamemanagement>().playersBackpack[u].name == "" && gm.GetComponent<gamemanagement>().money >= buyButtons[p].cost && allowBuy == true)
                                {
                                    Debug.Log("BOUGHT A THING");
                                    gm.GetComponent<gamemanagement>().reppuVisuals();
                                    //gm.GetComponent<gamemanagement>().playersBackpack[u] = gm.GetComponent<gamemanagement>().AllItems[y];
                                    gm.GetComponent<gamemanagement>().playersBackpack[u].name = gm.GetComponent<gamemanagement>().AllItems[y].name;
                                    gm.GetComponent<gamemanagement>().playersBackpack[u].description = gm.GetComponent<gamemanagement>().AllItems[y].description;
                                    gm.GetComponent<gamemanagement>().playersBackpack[u].amount = gm.GetComponent<gamemanagement>().AllItems[y].amount;
                                    gm.GetComponent<gamemanagement>().playersBackpack[u].itemPropertyInt = gm.GetComponent<gamemanagement>().AllItems[y].itemPropertyInt;
                                    gm.GetComponent<gamemanagement>().playersBackpack[u].sellCost = gm.GetComponent<gamemanagement>().AllItems[y].sellCost;
                                    gm.GetComponent<gamemanagement>().playersBackpack[u].itemImage = gm.GetComponent<gamemanagement>().AllItems[y].itemImage;


                                    gm.GetComponent<gamemanagement>().money = gm.GetComponent<gamemanagement>().money - buyButtons[p].cost;
                                    allowBuy = false;
                                    return;
                                }
                                else if (allowBuy == true && gm.GetComponent<gamemanagement>().money < buyButtons[p].cost)
                                {
                                    Debug.Log("NOT ENOUGH MONEY");
                                    shopCanvas.SetActive(false);
                                    Cursor.visible = false;
                                    Time.timeScale = 1;
                                    return;
                                }
                            }
                        }
                    }
                }
            }
        }
        itemToBuyINT = 10;
    }
    public void itemPictures()
    {
        if (EventSystem.current.currentSelectedGameObject != null)
        {
            if (EventSystem.current.currentSelectedGameObject.name == "s1") { shopitemnametemp = buyButtons[0].itemNameHolder.text; }
            if (EventSystem.current.currentSelectedGameObject.name == "s2") { shopitemnametemp = buyButtons[1].itemNameHolder.text; }
            if (EventSystem.current.currentSelectedGameObject.name == "s3") { shopitemnametemp = buyButtons[2].itemNameHolder.text; }
            if (EventSystem.current.currentSelectedGameObject.name == "s4") { shopitemnametemp = buyButtons[3].itemNameHolder.text; }
            if (EventSystem.current.currentSelectedGameObject.name == "s5") { shopitemnametemp = buyButtons[4].itemNameHolder.text; }
            if (EventSystem.current.currentSelectedGameObject.name == "s6") { shopitemnametemp = buyButtons[5].itemNameHolder.text; }
            if (EventSystem.current.currentSelectedGameObject.name == "s7") { shopitemnametemp = buyButtons[6].itemNameHolder.text; }
            if (EventSystem.current.currentSelectedGameObject.name == "s8") { shopitemnametemp = buyButtons[7].itemNameHolder.text; }
            if (EventSystem.current.currentSelectedGameObject.name == "s9") { shopitemnametemp = buyButtons[8].itemNameHolder.text; }
            if (EventSystem.current.currentSelectedGameObject.name == "s10") { shopitemnametemp = buyButtons[9].itemNameHolder.text; }

            for (int g = 0; g < 10; g++)
            {
                for (int r = 0; r < gm.GetComponent<gamemanagement>().AllItems.Length; r++)
                {
                    if (gm.GetComponent<gamemanagement>().AllItems[r].name != "")
                    {
                        if (gm.GetComponent<gamemanagement>().AllItems[r].name == shopitemnametemp)
                        {
                            shopItemImg.sprite = gm.GetComponent<gamemanagement>().AllItems[r].itemImage;
                        }
                    }
                }
            }
        }
    }
    public void sellSCreenImages()
    {
        if (EventSystem.current.currentSelectedGameObject != null)
        {
            if (EventSystem.current.currentSelectedGameObject.name == "s1") { itemToSellINT = 0; shopitemnametemp = sellButtons[0].itemNameHolder.text; }
            if (EventSystem.current.currentSelectedGameObject.name == "s2") { itemToSellINT = 1; shopitemnametemp = sellButtons[1].itemNameHolder.text; }
            if (EventSystem.current.currentSelectedGameObject.name == "s3") { itemToSellINT = 2; shopitemnametemp = sellButtons[2].itemNameHolder.text; }
            if (EventSystem.current.currentSelectedGameObject.name == "s4") { itemToSellINT = 3; shopitemnametemp = sellButtons[3].itemNameHolder.text; }
            if (EventSystem.current.currentSelectedGameObject.name == "s5") { itemToSellINT = 4; shopitemnametemp = sellButtons[4].itemNameHolder.text; }
            if (EventSystem.current.currentSelectedGameObject.name == "s6") { itemToSellINT = 5; shopitemnametemp = sellButtons[5].itemNameHolder.text; }
            if (EventSystem.current.currentSelectedGameObject.name == "s7") { itemToSellINT = 6; shopitemnametemp = sellButtons[6].itemNameHolder.text; }
            if (EventSystem.current.currentSelectedGameObject.name == "s8") { itemToSellINT = 7; shopitemnametemp = sellButtons[7].itemNameHolder.text; }
            if (EventSystem.current.currentSelectedGameObject.name == "s9") { itemToSellINT = 8; shopitemnametemp = sellButtons[8].itemNameHolder.text; }
            if (EventSystem.current.currentSelectedGameObject.name == "s10") { itemToSellINT = 9; shopitemnametemp = sellButtons[9].itemNameHolder.text; }

            for (int g = 0; g < 10; g++)
            {
                for (int r = 0; r < gm.GetComponent<gamemanagement>().AllItems.Length; r++)
                {
                    if (gm.GetComponent<gamemanagement>().AllItems[g].name == shopitemnametemp)
                    {
                        sellItemImg.sprite = gm.GetComponent<gamemanagement>().AllItems[g].itemImage;
                    }
                    else { return; }
                }
            }
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetButtonDown("interract"))
            {
                shopCanvas.SetActive(true);
                Cursor.visible = true;
                Time.timeScale = 0;
            }
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
    }
}
[System.Serializable]
public class itemsInShop
{
    public Text itemNameHolder;
    public int cost;
}
