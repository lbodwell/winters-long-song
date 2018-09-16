using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;

public class Switch_Behavior : MonoBehaviour {

    public enum actions { openclose }

    public bool state = false;
    public GameObject target;
    public actions action = actions.openclose;


    Collider2D trigger;

    SpriteRenderer spriteR;
    Sprite onSprite;
    Sprite offSprite;

    // Use this for initialization
    void Start () {
        trigger = GetComponent<Collider2D>();

        spriteR = GetComponent<SpriteRenderer>();

        onSprite = Resources.Load<Sprite>("Assets/Art/Sprites/Objects/Resources/oza_SwitchUp01_v01.png");
        offSprite = Resources.Load<Sprite>("Assets/Art/Sprites/Objects/Resources/oza_SwitchDown01_v01.png");
	}
	
	// Update is called once per frame
	void Update () {
        changeSprite(state);


	}

    void changeSprite(bool s)
    {
        if(s)
        {
            spriteR.sprite = onSprite;
        }
        else { spriteR.sprite = offSprite; }
    }
}
