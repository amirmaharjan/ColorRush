using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour {

	[SerializeField]
	float speed;
	bool speedcondition;
	public bool movesidecondition;
	public bool gameovercondition;
	public bool nocalculationneeded;

	Sprite originalsprite;

	[SerializeField]
	Sprite powerball;

	SpriteRenderer ballsprite;

//	Vector3 targetpos;

	// Use this for initialization
	void Start () {
		speedcondition = false;
		movesidecondition = false;
		gameovercondition = true;
		nocalculationneeded = false;
//		targetpos = new Vector3 (4,0,0);
//		StartCoroutine (starmovement());
		ballsprite = this.transform.GetComponent<SpriteRenderer>();
		originalsprite = this.transform.GetComponent<SpriteRenderer>().sprite;
	}
	
	// Update is called once per frame
	void Update () {

//		//transform.position = Vector2.MoveTowards (new Vector2(transform.position.x,transform.position.y),targetpos,speed * Time.deltaTime);
//		if (value == false){
//		transform.Translate (new Vector3 (CircleMaker.instance.circlespeed, 0, 0) * speed * Time.deltaTime);
//			if (transform.localPosition.x > 2.69) {
//				transform.localPosition = new Vector3 (0, 2, 0) * speed * Time.deltaTime;
//
//				value = true;
//				Debug.Log (value);
//			}
//			if (transform.localPosition.x > 7) {
//				Destroy (this.gameObject);
//			}
////			ScoreManger.instance.lives--;
//		}
//
//		if (value == true) {
//			Debug.Log ("Next Line");
//			//transform.localPosition = new Vector3 (CircleMaker.instance.circlespeed, 0, 0) * speed * Time.deltaTime;
//			transform.Translate (new Vector3 (CircleMaker.instance.circlespeed, 0, 0) * speed * Time.deltaTime);
//		}

		if(speedcondition == false){
			transform.Translate (new Vector3 (0, -CircleMakerGroup.instance.circlespeed, 0) * speed * Time.deltaTime);
		}

		if(movesidecondition == true){
			if (this.transform.localPosition.x < 0.49f) {
				transform.Translate (new Vector3 (-3, 0, 0) * speed * Time.deltaTime);
			} else {
				transform.Translate (new Vector3 (3, 0, 0) * speed * Time.deltaTime);
			}
		}

		if(this.transform.localPosition.x < -10 || this.transform.localPosition.x > 10){
			Destroy (this.transform.gameObject);
		}

		if(gameovercondition == false){
//			if (this.transform.localPosition.x < 0.49f) {
//				transform.Translate (new Vector3 (-0.3f, 0, 0) * speed * Time.deltaTime);
//			} else {
//				transform.Translate (new Vector3 (0.3f, 0, 0) * speed * Time.deltaTime);
//			}
			float randomnumber = Random.Range(-0.2f,0.4f);
			transform.Translate (new Vector3 (randomnumber, 0, 0) * speed * Time.deltaTime);
		}

//		if(transform.position.y < -1){
//			speedcondition = true;
//			transform.Translate (new Vector3 (0, -CircleMaker.instance.circlespeed * 3, 0) * 10 * Time.deltaTime);
//		}

//		if(transform.localPosition.y < -8){
//			Destroy (this.gameObject);
//		}
	}	

//	void OnEnable(){
//		ScoreManger.increasespeed += increaseSpeed;
//	}
//
//	void OnDisable(){
//		ScoreManger.increasespeed -= increaseSpeed;
//	}
//
//	void increaseSpeed(){
//		if (circlespeed <= 4.5f && CircleMaker.instance.delaytimer >= 0.2f) {
//			circlespeed = circlespeed + 0.5f;
////			Debug.Log (circlespeed);
//			CircleMaker.instance.delaytimer = CircleMaker.instance.delaytimer - 0.1f;
////			Debug.Log (CircleMaker.instance.delaytimer);
//		}
//	}

//	IEnumerator starmovement(){
//		if(Vector3.Distance(transform.position,targetpos)>0.05f){
//			transform.position = Vector3.Lerp (transform.position,targetpos,speed * Time.deltaTime);
//			yield return null;
//		}

//		if(Vector2.Distance(transform.position,targetpos)>0.05f){
//			transform.position = Vector2.Lerp (transform.position,targetpos,speed * Time.deltaTime);
//			yield return null;
//		}
//	}

	public void makePowerBall(){
		ballsprite.sprite = powerball;
	}

	public void makeNormalBall(){
		ballsprite.sprite = originalsprite;
	}
}
