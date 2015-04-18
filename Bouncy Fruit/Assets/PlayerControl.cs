using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	public Animator anim;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float axis = Input.GetAxis ("Horizontal");
		if (axis>0) {
			// add left force
			anim.SetInteger("Direction", 1);
			anim.SetBool("moving",false);

		}
		else if(axis<0) {
			// add right force
			anim.SetInteger("Direction", 0);
			anim.SetBool("moving",false);

		}
		else {
			anim.SetBool("moving",false);
		}
	}
}
