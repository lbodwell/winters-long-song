using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot_behavior_base : MonoBehaviour {

    Rigidbody2D physics;
    Transform transform;
    SpriteRenderer sprite;

    public float moveSpeed = 1;

    float moveDiv = 10;

	// Use this for initialization
	void Start () {
        physics = GetComponent<Rigidbody2D>();
        transform = GetComponent<Transform>();
        sprite = GetComponent<SpriteRenderer>();

        physics.freezeRotation = true;
        StartCoroutine(patrol(1, 1));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator patrol (float time, float waitTime)
    {
        while (true)
        {
            yield return StartCoroutine("moveRight", time);
            yield return new WaitForSeconds(waitTime);
            yield return StartCoroutine("moveLeft", time);
            yield return new WaitForSeconds(waitTime);
        }
    }

    public IEnumerator moveRight(float time)
    {
        float startTime = Time.time;
        sprite.flipX = false;
        while (Time.time <= startTime + time)
        {
            transform.Translate(new Vector2(moveSpeed/moveDiv, 0));
            yield return new WaitForSeconds(Time.fixedDeltaTime);
        }
        yield return null;
    }

    public IEnumerator moveLeft (float time)
    {
        float startTime = Time.time;
        sprite.flipX = true;
        while (Time.time <= startTime + time)
        {
            transform.Translate(new Vector2(-moveSpeed/moveDiv, 0));
            yield return new WaitForSeconds(Time.fixedDeltaTime);
        }
        yield return null;
    }
}
