using UnityEngine;
public class Bouncer : MonoBehaviour {
	
	public Vector3 scale;
	public float scaleMult = 1;
	public float multTarget = 1;
	public float LERPAMT = 0.1f;
	private AudioSource sfx;
	// Use this for initialization
	void Start () {
		scale = gameObject.transform.localScale;
		
		sfx = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (scaleMult != multTarget) {
			scaleMult = FLerp(scaleMult,multTarget, LERPAMT);
			gameObject.transform.localScale = scale * scaleMult;
		}
	}
	
	void OnCollisionEnter2D(Collision2D col)
	{
		Vector2 direction = col.transform.position - this.transform.position;
		scaleMult = 1.25f;
		gameObject.transform.localScale = scale * scaleMult;
		sfx.Play();		
		col.gameObject.rigidbody2D.AddForce(direction * 500.0f);
	}
	
	float FLerp(float a, float b, float _amt){
		if (Mathf.Abs (a - b)<_amt) {
			return b;
		}
		
		if(a<b){
			return a+_amt;
		}
		else if(a>b){
			return a-_amt;
		}
		return b;
	}
}