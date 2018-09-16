using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spells : MonoBehaviour {

    public enum spells { Shoot, MoveLeft, MoveRight, Freeze, max};

    public spells spell = spells.MoveRight;
    public bool debug = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonUp(0) && mouseHit() != null)
        {
            GameObject other = mouseHit();

            if (other.CompareTag("Character"))
            {
                cast(spell, other);
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            scrollSpell(1);
        }
        else if(Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            scrollSpell(-1);
        }
    }

    void cast(spells sp, GameObject target)
    {
        Robot_behavior_base commands = target.GetComponent<Robot_behavior_base>();
        switch (sp)
        {
            case spells.Freeze:
                break;
            case spells.MoveLeft:
                commands.StopAllCoroutines();
                commands.StartCoroutine("moveLeft", 5);
                break;
            case spells.MoveRight:
                commands.StopAllCoroutines();
                commands.StartCoroutine("moveRight", 5);
                break;
        }
        if (debug) { Debug.Log("Cast " + sp + " on " + target); }
    }

    void scrollSpell(int amount)
    {
        int final = (int)spell + amount;
        
        if(final >= (int)spells.max - 1) { final = 0; }
        else if(final < 0) { final = (int)spells.max - 1; }

        spell = (spells)final;

        if (debug)
        {
            Debug.Log("Changed to spell " + spell);
        }
    }

    GameObject mouseHit()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);

        //Physics.Raycast(ray, out hit);
        return hit.collider.gameObject;
    }
}
