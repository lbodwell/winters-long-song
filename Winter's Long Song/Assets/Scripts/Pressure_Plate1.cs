using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pressure_Plate1 : MonoBehaviour {
    public enum actions { openclose }

    public bool state = false;
    public GameObject target;
    //public actions action = actions.openclose;

    bool playerInRange = false;

    Collider2D trigger;

    SpriteRenderer spriteR;
    Animator anim;
    Canvas prompt;

    // Use this for initialization
    void Start()
    {
        trigger = GetComponent<Collider2D>();

        spriteR = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        anim.SetBool("On", state);

        if (playerInRange && Input.GetKeyUp("e"))
        {
            switchN();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Character"))
        {
            state = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Character"))
        {
            state = false;
        }
    }

    void switchOn()
    {
        state = true;
        if (target.CompareTag("Moving Wall"))
        {
            target.GetComponent<Wall_Behavior>().StartCoroutine("move");
        }
    }

    void switchOff()
    {
        state = false;
        if (target.CompareTag("Moving Wall"))
        {
            target.GetComponent<Wall_Behavior>().StartCoroutine("move");
        }
    }

    void switchN()
    {
        if (state) { switchOff(); }
        else { switchOn(); }
    }
}
