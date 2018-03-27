using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class petBehaviour : MonoBehaviour {

    public GameObject player;
    public float distToPlayer;
    public float speed;

    void Start () {}
	void Update ()
    {
        distToPlayer = Vector3.Distance(this.transform.position, player.transform.position);
        moveToPlayer();
        hideWhenInAttack();
    }
    void moveToPlayer()
    {
        if (distToPlayer > 3.5f)
        {
            this.gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, player.transform.position, Time.deltaTime * speed);
        }
    }
    void hideWhenInAttack()
    {
        if (player.GetComponent<playerAttacking>().atkAllow == true) { this.gameObject.GetComponentInChildren<SpriteRenderer>().enabled = true; }
        else { this.gameObject.GetComponentInChildren<SpriteRenderer>().enabled = false; }
    }
}
