using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour {
	public Animator anim;
    private Vector3 scale;
    private int[] count;
	private int[] transferredCounts;
	private CycleManager cyclemanager;
	public Text[] countLabels;
	public Text[] TargetLabels;
	public Text TimeCount;
	private AudioSource catchSnd;
	// Use this for initialization
	void Start () {
		cyclemanager = CycleManager.Instance;
        scale = gameObject.transform.localScale;
		count = new int[4];
		for (int i=0; i<4; i++) {
			count[i] = 0;
		}
		transferredCounts = new int[4];
		bool flag = true;
		transferredCounts[0] = cyclemanager.FirstDigit;
		transferredCounts[1] = cyclemanager.SecondDigit;
		transferredCounts[2] = cyclemanager.ThirdDigit;
		transferredCounts[3] = cyclemanager.FourthDigit;

		//If the score is initially 0000, the player has to catch exactly 9 fruits of each type
		foreach (int i in transferredCounts) {
			if(i!=0)
				flag = false;
		}

		if (flag == true) {
			for (int i=0; i<4; i++) {
				transferredCounts[i] = 9;
			}
		}
		cyclemanager.FirstDigit = 9;
		cyclemanager.SecondDigit = 9;
		cyclemanager.ThirdDigit = 9;
		cyclemanager.FourthDigit = 9;
	

		for(int i=0;i<4;i++)
		{
			countLabels [i].text = "0";
			TargetLabels[i].text = transferredCounts[i].ToString();
		}
		GameObject catchSndObj = GameObject.Find("catchsnd");
		catchSnd = catchSndObj.GetComponent<AudioSource>();

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

		//If you catch the exact number of fruits, you can carry over your score ot the next Game
		if (checkWin ()) {
			cyclemanager.AdvanceToNext();
		}

		//If you are unable to catch the exact number of fruits, you proceed to the next level with 0000
		if (cyclemanager.TimeLeft == 0.0f) {
			cyclemanager.FirstDigit = 0;
			cyclemanager.SecondDigit = 0;
			cyclemanager.ThirdDigit = 0;
			cyclemanager.FourthDigit = 0;
		}
		TimeCount.text = cyclemanager.TimeLeft.ToString().Split('.')[0];
	}

	//Funtion to check if the player has reached the target
	bool checkWin()
	{
		if (count [0] != transferredCounts [0]) {
			return false;
		}
		if (count [1] != transferredCounts [1]) {
			return false;
		}
		if (count [2] != transferredCounts [2]) {
			return false;
		}
		if (count [3] != transferredCounts [3]) {
			return false;
		}

		return true;
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "fruit") {
			catchSnd.Play();
            if (col.gameObject.name == "Apple(Clone)")
			{
                count[0]++;
				count[0] = count[0]%10;
				countLabels[0].text = count[0].ToString();
			}
            if (col.gameObject.name == "Banana(Clone)")
			{
				count[1]++;
				count[1] = count[1]%10;
				countLabels[1].text = count[1].ToString();
			}
			if (col.gameObject.name == "Pineapple(Clone)")
			{
				count[2]++;
				count[2] = count[2]%10;
				countLabels[2].text = count[2].ToString();
			}
            if (col.gameObject.name == "Strawberry(Clone)")
			{
				count[3]++;
				count[3] = count[3]%10;
				countLabels[3].text = count[3].ToString();
			}
            DestroyObject(col.gameObject);
        }
    }
}
