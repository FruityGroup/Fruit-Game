using UnityEngine;
using System.Collections;

public class Bouncer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        Vector2 direction = col.transform.position - this.transform.position;

        col.gameObject.rigidbody2D.AddForce(direction * 500.0f);
    }
}
