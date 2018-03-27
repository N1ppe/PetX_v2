using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour {

    Animator enemysAnimator;
    public GameObject player;
    public float distToPlayer;
    public state EnemyState=state.idle;
    [Range(0,1)]
    public int health;
    //public gamemanagement gm;
    public GameObject gm;

    void Start ()
    {
        enemysAnimator = GetComponentInChildren<Animator>();
        player = GameObject.FindWithTag("Player");
        gm = GameObject.FindWithTag("GameManagementTag");
    }
	void Update ()
    {
        if (distToPlayer < 10) { animationChanger(); }
        if(EnemyState != state.dead && health>0)
        {
            distToPlayer = Vector3.Distance(this.transform.position, player.transform.position);
            if (distToPlayer < 8 && distToPlayer > 2.55f) { EnemyState = state.following; }
            else if (distToPlayer <= 2.5f) { EnemyState = state.attack; }
            else if(distToPlayer >= 10f) { EnemyState = state.idle; }
            if (health <= 0) { EnemyState = state.dead; }

            if (EnemyState == state.following && player.GetComponent<playerAttacking>().playerHealth > 0)
            {
                this.gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, player.transform.position, Time.deltaTime * 2.5f);
                StartCoroutine(randDelay());
            }
            if (health <= 0) { EnemyState = state.dead; }
        }
        else
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gm.GetComponent<gamemanagement>().currentPetAttackGain();
            StartCoroutine(deathStateOperation());
        }
    }
    public void animationChanger()
    {
        if (EnemyState == state.idle) { enemysAnimator.SetInteger("enemyStateInt", 0); }
        if (EnemyState == state.following) { enemysAnimator.SetInteger("enemyStateInt", 1); }
        if (EnemyState == state.attack) { enemysAnimator.SetInteger("enemyStateInt", 2); }
        if (EnemyState == state.dead) { enemysAnimator.SetInteger("enemyStateInt", 3); }
    }
    IEnumerator randDelay()
    {
        if (health < 0)
        { EnemyState = state.following; }
        yield return new WaitForSeconds(Random.Range(1,4));
        if (health < 0)
        { EnemyState = state.idle; }
    }
    IEnumerator deathStateOperation()
    {
        yield return new WaitForSeconds(2f);
        this.gameObject.GetComponent<lootDrop>().itemAssigningAndSpawn();
        Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" )
        {
           health =-1;
        }
    }
}
public enum state
{
idle,following,attack,dead
}
