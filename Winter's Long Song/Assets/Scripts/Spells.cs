using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spells : MonoBehaviour {

    public int spell = 3;

    int maxSpells = 4;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonUp(0) && mouseHit() != null)
        {
            GameObject other = mouseHit();

            Debug.Log("Has tag character: " + other.CompareTag("Character"));
            if (other.CompareTag("Character"))
            {
                cast(spell, other);
            }
        }

        //Debug.Log(Input.GetAxis("Mouse ScrollWheel"));

        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            scrollSpell((int)Input.GetAxisRaw("Mouse ScrollWheel"));

            Debug.Log("Changed to spell " + spell);
        }
    }

    void cast(int spell, GameObject target)
    {
        Robot_behavior_base commands = target.GetComponent<Robot_behavior_base>();
        switch (spell)
        {
            case 1:
                break;
            case 2:
                commands.StopAllCoroutines();
                commands.StartCoroutine("moveLeft", 5);
                break;
            case 3:
                commands.StopAllCoroutines();
                commands.StartCoroutine("moveRight", 5);
                break;
        }
    }

    void scrollSpell(int amount)
    {
        spell += amount;
        if(spell > maxSpells) { spell = 1; }
        else if(spell < 1) { spell = maxSpells; }
    }

    GameObject mouseHit()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);

        //Physics.Raycast(ray, out hit);
        return hit.collider.gameObject;
    }
}
