using UnityEngine;
using System.Collections;

public class FruitSpawner : MonoBehaviour {

    public float waitTime;
    public GameObject[] fruits;
    private bool flag;
	// Use this for initialization
	void Start () {
         flag = true;
         waitTime = Random.Range(0, 10) / 10.0f;
         waitTime += 0.5f;
	}
	
    IEnumerator wait()
    {
        flag = false;
        yield return new WaitForSeconds(waitTime);
        spawnFruit();
        flag = true;
    }
    void spawnFruit()
    {
        int i = Random.Range(0, fruits.Length);
        GameObject.Instantiate(fruits[i], this.transform.position, this.transform.rotation);
    }

	// Update is called once per frame
	void Update () {

        waitTime = Random.Range(0, 10) / 10.0f;
        waitTime += 0.5f;
        if(flag)
            StartCoroutine(wait());
            
	}
}
