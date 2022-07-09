using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleThrow : MonoBehaviour {

	[SerializeField]
	float speed;

	[SerializeField]
	bool returncondition;

	bool dropcondition;

	// Use this for initialization
	void Start () {
		returncondition = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(returncondition == false){
			transform.Translate (new Vector3 (0, 10, 0) * speed * Time.deltaTime);

			if(transform.localPosition.y > 10){
				Destroy (this.gameObject);
			}
		}

		if(returncondition == true){
			transform.Translate (new Vector3 (0, -10, 0) * speed * Time.deltaTime);

			if(transform.localPosition.y < 0){
				Destroy (this.gameObject);
			}
		}

		if(dropcondition == true){
			for(int i = 0;i<CircleMakerGroup.instance.circlemakerslist.Count;i++){
				CircleMakerGroup.instance.circlemakerslist.Last.Value.GetComponent<CircleMaker> ().dropBall ();
				CircleMakerGroup.instance.circlemakerslist.RemoveLast ();
			}
		}
	}

	void OnCollisionEnter2D (Collision2D coll){
//		if (this.transform.tag == coll.gameObject.tag) {
//			coll.gameObject.GetComponentInParent<CircleMaker> ().hitcounter++;
//			ScoreManger.instance.score++;
//			Destroy (coll.gameObject);
//			returncondition = true;
//		} else {
//			Destroy (ScoreManger.instance.livesgroup.transform.GetChild(0).gameObject);
//			Destroy (this.gameObject);
//		}

		if(coll.gameObject.GetComponent<SpriteRenderer>().sprite.name == "twe" && coll.gameObject.tag != "powerball"){
			//coll.gameObject.GetComponentInParent<CircleMaker> ().hitcounter++;
			ScoreManger.instance.score++;
			returncondition = true;
			Destroy (coll.gameObject);
		}else if (this.transform.tag == coll.gameObject.tag) {
			coll.gameObject.GetComponentInParent<CircleMaker> ().hitcounter++;
			ScoreManger.instance.score++;
			returncondition = true;
			Destroy (coll.gameObject);
		}else if(coll.gameObject.tag == "deathball"){
			if (coll.gameObject.GetComponent<SpriteRenderer> ().sprite.name == "twe") {
				Debug.Log ("fuck this should have been destroyed");
				ScoreManger.instance.score++;
				returncondition = true;
				Destroy (coll.gameObject);
			} else {
				dropcondition = true;
			}
		}else if(coll.gameObject.tag == "powerball"){
			ScoreManger.instance.score++;
			CircleMakerGroup.instance.makeAllPowerBall ();
			returncondition = true;
			Destroy (coll.gameObject);
		} else {
			Destroy (ScoreManger.instance.livesgroup.transform.GetChild(0).gameObject);
			Destroy (this.gameObject);
		}
//		if(coll.gameObject.GetComponent<SpriteRenderer>().sprite.name == "twe" && coll.gameObject.tag != "powerball"){
//			//coll.gameObject.GetComponentInParent<CircleMaker> ().hitcounter++;
//			if (coll.gameObject.tag == "deathball") {
//				if (coll.gameObject.GetComponent<SpriteRenderer> ().sprite.name == "twe") {
//					ScoreManger.instance.score++;
//					CircleMakerGroup.instance.makeAllPowerBall ();
//					Destroy (coll.gameObject);
//					returncondition = true;
//				} else {
//					dropcondition = true;	
//				}
//			}else{
//					ScoreManger.instance.score++;
//					Destroy (coll.gameObject);
//					returncondition = true;
//				}
//
//		}else if (this.transform.tag == coll.gameObject.tag) {
//			coll.gameObject.GetComponentInParent<CircleMaker> ().hitcounter++;
//			ScoreManger.instance.score++;
//			Destroy (coll.gameObject);
//			returncondition = true;
//		}else if(coll.gameObject.tag == "powerball"){
//			ScoreManger.instance.score++;
//			CircleMakerGroup.instance.makeAllPowerBall ();
//			Destroy (coll.gameObject);
//			returncondition = true;
//		} else {
//			Destroy (ScoreManger.instance.livesgroup.transform.GetChild(0).gameObject);
//			Destroy (this.gameObject);
//		}
	}
}
