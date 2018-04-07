using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerAttacking : MonoBehaviour {

    //[Range(0,3)]
    public int playerHealth;
    public bool attackingOn,atkAllow=true;
    public Collider2D attackCollider;

    public Image UIhealth;
    float hpMax = 1200;
    float healthCalculated;
    public Vector2 bedLocation;
    public gamemanagement gm;

    public GameObject attackSprt;
    public GameObject attackSpriteDark;
    public GameObject attackSpriteLight;

    void Start ()
    {
        attackCollider = attackSprt.GetComponent<Collider2D>();
    }
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            attackSprt = attackSpriteDark;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            attackSprt = attackSpriteLight;
        }

        calcHealth();
        attackControls();
        spriteRot();
        spritePos();
        attacking();

        if (playerHealth <= 0) { PlayerIsDead(); }
	}
    public void calcHealth()
    {
        healthCalculated = playerHealth / hpMax;
        UIhealth.fillAmount = healthCalculated;
    }
    public void PlayerIsDead()
    {
        //fade screen out
        Time.timeScale = 0;
        gm.GetComponent<gamemanagement>().day += 1;
        gm.GetComponent<gamemanagement>().timeOfDay = 6;
        this.gameObject.transform.position = bedLocation;
        playerHealth = Mathf.RoundToInt(hpMax);
        // fade screen in

    }
    public void attackControls()
    {
        if (attackingOn == true)
        {
            if (Input.GetButtonDown("attack")&&atkAllow==true)
            {
                StartCoroutine(atkdelay());
            }
        }
    }

    /*
     *         if (skin.GetComponent<SpriteRenderer>().sprite = playerSprites[0])
        {
            attackSprt.transform.rotation = Quaternion.Euler(0, 0, 180);
        }
    */

    public void attacking()
    {
        if (atkAllow == true)
        {

        }
    }

    public void spriteRot()
    {
        if (Facing.dirFacing == Facing.directionFacing.down) { attackSprt.transform.rotation = Quaternion.Euler(0, 0, 180); }
        if (Facing.dirFacing == Facing.directionFacing.downleft) { attackSprt.transform.rotation = Quaternion.Euler(0, 0, 135); }
        if (Facing.dirFacing == Facing.directionFacing.left) { attackSprt.transform.rotation = Quaternion.Euler(0, 0, 90); }
        if (Facing.dirFacing == Facing.directionFacing.upleft) { attackSprt.transform.rotation = Quaternion.Euler(0, 0, 45); }
        if (Facing.dirFacing == Facing.directionFacing.up) { attackSprt.transform.rotation = Quaternion.Euler(0, 0, 0); }
        if (Facing.dirFacing == Facing.directionFacing.upright) { attackSprt.transform.rotation = Quaternion.Euler(0, 0, 315); }
        if (Facing.dirFacing == Facing.directionFacing.right) { attackSprt.transform.rotation = Quaternion.Euler(0, 0, 270); }
        if (Facing.dirFacing == Facing.directionFacing.downright) { attackSprt.transform.rotation = Quaternion.Euler(0, 0, 225); }
    }
    public void spritePos()
    {
        if (Facing.dirFacing == Facing.directionFacing.down) { attackSprt.transform.localPosition = new Vector3(0, -3, 0); }
        if (Facing.dirFacing == Facing.directionFacing.downleft) { attackSprt.transform.localPosition = new Vector3(-1.5f, -1.5f, 0); }
        if (Facing.dirFacing == Facing.directionFacing.left) { attackSprt.transform.localPosition = new Vector3(-3, 0, 0); }
        if (Facing.dirFacing == Facing.directionFacing.upleft) { attackSprt.transform.localPosition = new Vector3(-1.5f, 1.5f, 0); }
        if (Facing.dirFacing == Facing.directionFacing.up) { attackSprt.transform.localPosition = new Vector3(0, 3, 0); }
        if (Facing.dirFacing == Facing.directionFacing.upright) { attackSprt.transform.localPosition = new Vector3(1.5f, 1.5f, 0); }
        if (Facing.dirFacing == Facing.directionFacing.right) { attackSprt.transform.localPosition = new Vector3(3, 0, 0); }
        if (Facing.dirFacing == Facing.directionFacing.downright) { attackSprt.transform.localPosition = new Vector3(1.5f, -1.5f, 0); }
    }

    /*
public void attacking()
{
    if (atkAllow == true)
    {
        if (Input.GetButton("up") || Input.GetKey(KeyCode.UpArrow))
        {
            DirectionFacing = directionFacing.up;
        }
        if (Input.GetButton("down") || Input.GetKey(KeyCode.DownArrow))
        {
            DirectionFacing = directionFacing.down;
        }
        if (Input.GetButton("left") || Input.GetKey(KeyCode.LeftArrow))
        {
            DirectionFacing = directionFacing.left;
        }
        if (Input.GetButton("right") || Input.GetKey(KeyCode.RightArrow))
        {
            DirectionFacing = directionFacing.right;
        }
    }
}

public void spriteRot()
{
    if (DirectionFacing == directionFacing.up) { attackSprt.transform.rotation = Quaternion.Euler(0, 0, 0); }
    if (DirectionFacing == directionFacing.down) { attackSprt.transform.rotation = Quaternion.Euler(0, 0, 180); }
    if (DirectionFacing == directionFacing.left) { attackSprt.transform.rotation = Quaternion.Euler(0, 0, 90); }
    if (DirectionFacing == directionFacing.right) { attackSprt.transform.rotation = Quaternion.Euler(0, 0, 270); }
}
public void spritePos()
{
    if (DirectionFacing == directionFacing.up) { attackSprt.transform.localPosition = new Vector3(0, 3, 0); }
    if (DirectionFacing == directionFacing.down) { attackSprt.transform.localPosition = new Vector3(0, -3, 0); }
    if (DirectionFacing == directionFacing.left) { attackSprt.transform.localPosition = new Vector3(-3, 0, 0); }
    if (DirectionFacing == directionFacing.right) { attackSprt.transform.localPosition = new Vector3(3, 0, 0); }
}

*/

    //skin.GetComponent<SpriteRenderer>().sprite = playerSprites[3];

    IEnumerator atkdelay()
    {
        atkAllow = false;
        attackSprt.SetActive(true);
        yield return new WaitForSeconds(1f);
        attackSprt.SetActive(false);
        atkAllow = true;
    }
}
