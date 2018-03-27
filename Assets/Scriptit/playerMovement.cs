using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour {

    public float sprint;
    public GameObject skin;
    public Sprite[] playerSprites;
    private Animator animator;
    [Range(0,100)]
    public float stamina;

    public Vector2 speed = new Vector2(1, 1);

	void Start ()
    {
        animator = GetComponent<Animator>();
    }

	void Update ()
    {
        // Sprinting speed
        if (Input.GetButton("run") && stamina > 0 )
        {
            if(Input.GetButton("up") || Input.GetButton("down") || Input.GetButton("left") || Input.GetButton("right"))
            {
                sprint = 4f;
                stamina = stamina - 0.5f;
            }
        }
        else
        {
            sprint = 2f;
            if (stamina < 100)
            {
                if (!Input.GetButton("run"))
                { stamina += 0.5f; }
            }
        }
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        // Supposed to be more accurate for tracking player facing direction, don't need with 4 directions
        /*
        animator.SetFloat("SpeedX", inputX);
        animator.SetFloat("SpeedY", inputY);
        */
        Vector3 movement = new Vector3(
            speed.x * inputX,
            speed.y * inputY,
            0);

        movement *= Time.deltaTime;

        transform.Translate(movement*sprint);

        attacking(); 
	}
    // Updates animator float that changes player sprite direction
    private void FixedUpdate()
    {
        float lastInputX = Input.GetAxis("Horizontal");
        float lastInputY = Input.GetAxis("Vertical");

        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            animator.SetBool("walking", true);
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
        else
        {
            animator.SetBool("walking", false);
        }
    }
    
    public void attacking()
    {
        if (GetComponent<playerAttacking>().atkAllow == true)
        {
            if (Input.GetButton("up") || Input.GetKey(KeyCode.UpArrow))
            {  
                //skin.GetComponent<SpriteRenderer>().sprite = playerSprites[0];
                GetComponent<playerAttacking>().DirectionFacing = directionFacing.up;
                //transform.Translate(Vector3.up * speed * Time.deltaTime);
            }
            if (Input.GetButton("down") || Input.GetKey(KeyCode.DownArrow))
            {
                //skin.GetComponent<SpriteRenderer>().sprite = playerSprites[1];
                GetComponent<playerAttacking>().DirectionFacing = directionFacing.down;
                //transform.Translate(Vector3.down * speed * Time.deltaTime);
            }
            if (Input.GetButton("left") || Input.GetKey(KeyCode.LeftArrow))
            {
                //skin.GetComponent<SpriteRenderer>().sprite = playerSprites[2];
                GetComponent<playerAttacking>().DirectionFacing = directionFacing.left;
                //transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
            if (Input.GetButton("right") || Input.GetKey(KeyCode.RightArrow))
            {
                //skin.GetComponent<SpriteRenderer>().sprite = playerSprites[3];
                GetComponent<playerAttacking>().DirectionFacing = directionFacing.right;
                //transform.Translate(Vector3.right * speed * Time.deltaTime);
            }    
            /*
            if (Input.GetButton("up") || Input.GetKey(KeyCode.UpArrow)) { animator.SetInteger("dirInt", 1); }
            else if (Input.GetButton("down") || Input.GetKey(KeyCode.DownArrow)) { animator.SetInteger("dirInt", 2); }
            else if (Input.GetButton("left") || Input.GetKey(KeyCode.LeftArrow)) { animator.SetInteger("dirInt", 3); }
            else if (Input.GetButton("right") || Input.GetKey(KeyCode.RightArrow)) { animator.SetInteger("dirInt", 4); }
            else { animator.SetInteger("dirInt", 0); }
            */    
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "wall")
        {
            Debug.Log("hit a wall");
        }
        if (other.gameObject.tag == "Enemy")
        {
           this.gameObject.GetComponent<playerAttacking>().playerHealth--;
        }
    }
    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy"&&GetComponent<playerAttacking>().playerHealth>0)
        {
            this.gameObject.GetComponent<playerAttacking>().playerHealth--;
        }
    }
}
