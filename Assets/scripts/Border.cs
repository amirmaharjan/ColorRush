using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Border : MonoBehaviour {

	[SerializeField]
	public GameObject gameoverui;

	BoxCollider2D myboxcollider;

	[SerializeField]
	GameObject buttongroup;



	bool dropcondition;

	// Use this for initialization
	void Start () {
		myboxcollider = GetComponent<BoxCollider2D> ();
		dropcondition = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(dropcondition == true){
			for(int i = 0;i<CircleMakerGroup.instance.circlemakerslist.Count;i++){
				CircleMakerGroup.instance.circlemakerslist.Last.Value.GetComponent<CircleMaker> ().dropBall ();
				CircleMakerGroup.instance.circlemakerslist.RemoveLast ();
			}
		}
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.GetComponent<CircleThrow> () || coll.GetComponent<SpriteRenderer>().sprite.name == "twe") {
			if(coll.GetComponent<SpriteRenderer>().sprite.name == "twe"){
//				Destroy (coll.gameObject);
				coll.gameObject.GetComponent<Rigidbody2D> ().gravityScale = 2f;
				coll.gameObject.GetComponent<Circle> ().gameovercondition = false;
				StartCoroutine (waitForDestroy(coll.gameObject));
			}
		} else {
			if(coll.GetComponent<Circle>().nocalculationneeded == true){
				Debug.Log (coll.GetComponent<Circle>().nocalculationneeded);
			}else{
				if (ScoreManger.instance.alreadyPlayed == false) {
					FindObjectOfType<AudioManager> ().Play ("GameOver");
				}
				myboxcollider.isTrigger = false;
				dropcondition = true;
				StartCoroutine (waitForGameOver());	
			}
		}
	}

	IEnumerator waitForGameOver(){
		for(int i = 0;i<buttongroup.transform.childCount;i++){
			//Debug.Log ("Bar ma choko wala");
			buttongroup.transform.GetChild (i).GetComponent<Button> ().interactable = false;
		}
		yield return new WaitForSeconds (1.29f);
		gameoverui.SetActive (true);

	}

	IEnumerator waitForDestroy(GameObject coll){
		yield return new WaitForSeconds (4f);
		Destroy (coll);
	}
}
