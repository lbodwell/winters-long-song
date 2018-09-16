using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Switch_Behavior : MonoBehaviour {

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
    void Start () {
        trigger = GetComponent<Collider2D>();

        spriteR = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        prompt = GetComponentInChildren<Canvas>();
        prompt.gameObject.SetActive(false);
	}

    // Update is called once per frame
    void Update () {

        anim.SetBool("On", state);

        if (playerInRange && Input.GetKeyUp("e"))
        {
            switchN();
        }

	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            prompt.gameObject.SetActive(true);
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            prompt.gameObject.SetActive(false);
            playerInRange = false;
        }
    }

    void switchOn()
    {
        state = true;
        if(target.CompareTag("Moving Wall"))
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
