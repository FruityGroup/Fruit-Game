using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	public Animator anim;
    private Vector3 scale;
    private int[] count;

	// Use this for initialization
	void Start () {
        scale = gameObject.transform.localScale;
        count = new int[4];
	}
	
	// Update is called once per frame
	void Update () {
		float axis = Input.GetAxis ("Horizontal");
		if (axis>0) {
			// add left force
            Vector2 newTransform = new Vector2(this.transform.position.x + 0.1f, this.transform.position.y);
            this.transform.position = newTransform;
			anim.SetInteger("Direction", 1);
			anim.SetBool("Moving",true);
            gameObject.transform.localScale = new Vector3(scale.x, scale.y,scale.z);
		}
		else if(axis<0) {
			// add right force
            Vector2 newTransform = new Vector2(this.transform.position.x - 0.1f, this.transform.position.y);
            this.transform.position = newTransform;
			anim.SetInteger("Direction", 0);
			anim.SetBool("Moving",true);
            gameObject.transform.localScale = new Vector3(-scale.x, scale.y, scale.z);
		}
		else {
			anim.SetBool("Moving",false);
		}
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "fruit") {
            if (col.gameObject.name == "Apple(Clone)")
                count[0]++;
            if (col.gameObject.name == "Banana(Clone)")
                count[1]++;
            if (col.gameObject.name == "Pineapple(Clone)")
                count[2]++;
            if (col.gameObject.name == "Strawberry(Clone)")
                count[3]++;

            DestroyObject(col.gameObject);
        }
    }
}
