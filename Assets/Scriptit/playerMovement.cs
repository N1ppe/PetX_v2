using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour {

    public float sprint;
    private Animator animator;
    [Range(0,100)]
    public float stamina;
    public Vector2 speed;

    void Start ()
    {
        animator = GetComponent<Animator>();
    }

	public void Update ()
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

        Vector3 movement = new Vector3(
            speed.x * inputX,
            speed.y * inputY,
            0);

        movement *= Time.deltaTime;

        transform.Translate(movement*sprint);
 
	}
    // Updates animator float that changes player sprite direction
    public void FixedUpdate()
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

        if (((lastInputX == 0)) && ((lastInputY == -1)))
        {
            Facing.dirFacing = Facing.directionFacing.down;
        }
        if (((lastInputX == -1)) && ((lastInputY == -1)))
        {
            Facing.dirFacing = Facing.directionFacing.downleft;
        }
        if (((lastInputX == -1)) && ((lastInputY == 0)))
        {
            Facing.dirFacing = Facing.directionFacing.left;
        }
        if (((lastInputX == -1)) && ((lastInputY == 1)))
        {
            Facing.dirFacing = Facing.directionFacing.upleft;
        }
        if (((lastInputX == 0)) && ((lastInputY == 1)))
        {
            Facing.dirFacing = Facing.directionFacing.up;
        }
        if (((lastInputX == 1)) && ((lastInputY == 1)))
        {
            Facing.dirFacing = Facing.directionFacing.upright;
        }
        if (((lastInputX == 1)) && ((lastInputY == 0)))
        {
            Facing.dirFacing = Facing.directionFacing.right;
        }
        if (((lastInputX == 1)) && ((lastInputY == -1)))
        {
            Facing.dirFacing = Facing.directionFacing.downright;
        }
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
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


public class Facing : MonoBehaviour
{

    public enum directionFacing { down, downleft, left, upleft, up, upright, right, downright };
    public static directionFacing dirFacing;

}