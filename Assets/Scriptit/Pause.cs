using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

    public bool paused;
    public Animator animator;
    // Use this for initialization
    void Start()
    {
        paused = false;
        animator.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //PauseAnim();
    }
    public void PauseAnim()
    {
        paused = !paused;
        if (paused)
        {
            Time.timeScale = 0;
        }
        else if (!paused)
        {
            Time.timeScale = 1;
        }
    }
}