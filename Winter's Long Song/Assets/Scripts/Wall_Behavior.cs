using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_Behavior : MonoBehaviour {

    public Vector3 offset = new Vector3(0, 2, 0);
    public float speed = 1;

    bool activated = false;

    Vector3 startPos;
    Vector3 endPos;

	// Use this for initialization
	void Start () {
        startPos = transform.position;
        endPos = transform.position + offset;
	}
    
    IEnumerator move()
    {
        float startTime = Time.time;
        Vector3 start = transform.position;
        Vector3 target;

        if (activated) { target = startPos; }
        else { target = endPos; }

        //Debug.Log("target: " + target);

        activated = !activated;

        float totalDistance = Vector3.Distance(start, target);

        while (transform.position != target)
        {
            float currentDuration = (Time.time - startTime) * speed;
            float journeyFraction = currentDuration / totalDistance;

            transform.position = Vector3.Lerp(start, target, journeyFraction);
            yield return new WaitForSeconds(Time.fixedDeltaTime);
        }

        //Debug.Log("Reached destination");

        yield return null;
    }
}
