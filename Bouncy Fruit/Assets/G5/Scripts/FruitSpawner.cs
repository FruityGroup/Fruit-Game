using UnityEngine;
using System.Collections;

public class FruitSpawner : MonoBehaviour {

    public float waitTime;
    public GameObject[] fruits;

	// Use this for initialization
	void Start () {
       // waitTime = 2.0f;
	}
	
    IEnumerator spawnFruit()
    {
        int i = Random.Range(0, 4);

        GameObject.Instantiate(fruits[i],this.transform.position, this.transform.rotation);

        yield return new WaitForSeconds(waitTime);
    }

	// Update is called once per frame
	void Update () {
	  
       spawnFruit();
            
	}
}
