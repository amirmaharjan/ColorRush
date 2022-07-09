using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

//	List<GameObject> currentcirclecollector;

//	[SerializeField]
//	GameObject circlemakergroupreference;

//	float timer;

	public static GameController instance;
	public int counter;

	// Use this for initialization
	void Start () {
		counter = 0;
//		currentcirclecollector = new List<GameObject> ();
		if(instance == null){
			instance = this;
			DontDestroyOnLoad (this.gameObject);
		}
//		CircleMakerGroup.instance.makecondition = false;
//		timer = 2.2f;
//		StartCoroutine(waitForInstaiate());
	}
	
	// Update is called once per frame
	void Update () {
//		timer -= Time.deltaTime;
////		Debug.Log (timer);
//		if(timer <= 0){			
//			currentpossiblematches = 0;
//			timer = 2.2f;
//		}
	}

//	IEnumerator waitForInstaiate(){
//		yield return new WaitForSeconds (3f);
//		calculateCurrentPossibleMatches ();
//		Debug.Log(currentpossiblematches);
//	}
}
