using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class petBehaviour : MonoBehaviour {

    public GameObject player;
    //public float distToPlayer;
    public float speed;
    
    public GameObject petPosition;

    GameObject petSprite;
    public GameObject petDark;
    public GameObject petLight;

    Animator animator;
    public Animator petDarkAnimator;
    public Animator petLightAnimator;

    void Start ()
    {
        petSprite = petDark;
        animator = petDarkAnimator;
        petDark.SetActive(true);
    }

    void Update ()
    {
        //distToPlayer = Vector3.Distance(this.transform.position, player.transform.position);
        //moveToPlayer();
        //hideWhenInAttack();
        if (Input.GetKeyDown(KeyCode.E))
        {
            petSprite = petDark;
            animator = petDarkAnimator;
            petDark.SetActive(true);
            petLight.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            petSprite = petLight;
            animator = petLightAnimator;
            petDark.SetActive(false);
            petLight.SetActive(true);
        }

        spritePos();
    }

    /*
    void moveToPlayer()
    {
        if (distToPlayer > 3.5f)
        {
            this.gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, player.transform.position, Time.deltaTime * speed);
        }
    }
    */

    void hideWhenInAttack()
    {
        //if (player.GetComponent<playerAttacking>().atkAllow == true) { this.gameObject.GetComponentInChildren<SpriteRenderer>().enabled = true; }
        //else { this.gameObject.GetComponentInChildren<SpriteRenderer>().enabled = false; }
    }

    public void spritePos()
    {
        if (Facing.dirFacing == Facing.directionFacing.down)
        {
            petPosition.transform.localPosition = new Vector3(0, 8, 0);
            this.gameObject.transform.position = Vector2.MoveTowards(petSprite.transform.position, petPosition.transform.position, Time.deltaTime * speed);
        }        
        if (Facing.dirFacing == Facing.directionFacing.left)
        {
            petPosition.transform.localPosition = new Vector3(8, -2, 0);
            this.gameObject.transform.position = Vector2.MoveTowards(petSprite.transform.position, petPosition.transform.position, Time.deltaTime * speed);
        }
        if (Facing.dirFacing == Facing.directionFacing.up)
        {
            petPosition.transform.localPosition = new Vector3(0, -8, 0);
            this.gameObject.transform.position = Vector2.MoveTowards(petSprite.transform.position, petPosition.transform.position, Time.deltaTime * speed);
        }
        if (Facing.dirFacing == Facing.directionFacing.right)
        {
            petPosition.transform.localPosition = new Vector3(-8, -2, 0);
            this.gameObject.transform.position = Vector2.MoveTowards(petSprite.transform.position, petPosition.transform.position, Time.deltaTime * speed);
        }
    }

    public void FixedUpdate()
    {
        float lastInputX = Input.GetAxis("Horizontal");
        float lastInputY = Input.GetAxis("Vertical");

        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            if (lastInputX > 0)
            {
                animator.SetFloat("LastMoveX", 1f);
            }
            else if (lastInputX < 0)
            {
                animator.SetFloat("LastMoveX", -1f);
            }
            else
            {
                animator.SetFloat("LastMoveX", 0f);
            }

            if (lastInputY > 0)
            {
                animator.SetFloat("LastMoveY", 1f);
            }
            else if (lastInputY < 0)
            {
                animator.SetFloat("LastMoveY", -1f);
            }
            else
            {
                animator.SetFloat("LastMoveY", 0f);
            }
        }

        if (Input.GetButton("attack"))
        {
            animator.SetBool("attack", true);
        }
        else
        {
            animator.SetBool("attack", false);
        }
    }
}
