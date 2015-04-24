using UnityEngine;
using System.Collections;

public class Fruit : MonoBehaviour {
	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
	    if(this.transform.position.y < -8.0f)
        {
            Destroy(this.gameObject);
        }
	}
}
