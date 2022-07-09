using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMakerGroup : MonoBehaviour {

	[SerializeField]
	GameObject circlemakers;
	public LinkedList<GameObject> circlemakerslist;
	float timer;
	private float firsttimer = 0;
	public float delaytimer;
	public float circlespeed;
	public bool makecondition;
	public static CircleMakerGroup instance;
	bool onetimeruncondition;

	// Use this for initialization
	void Start () {
		circlemakerslist = new LinkedList<GameObject> ();
		if(instance == null){
			instance = this;
		}
		makecondition = true;
		timer = firsttimer;
		onetimeruncondition = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (makecondition == true) {
			timer -= Time.deltaTime;
			if (timer <= 0) {
				circlemakerslist.AddFirst (Instantiate (circlemakers, this.transform));
//				Debug.Log (circlemakerslist.Count);
				if((circlemakerslist.Count + 1) % 7 == 0){
//					if(circlespeed < 2.1 && delaytimer > 1){
//						Debug.Log ("kaile huncha biye");
//						circlespeed = circlespeed + 0.2f;
//						delaytimer = delaytimer - 0.5f;	
//					}
					if(circlespeed < 2.3){
						//Debug.Log ("kaile huncha biye");
						circlespeed = circlespeed + 0.3f;
					}
					if(delaytimer > 1.2){
						//Debug.Log ("kaile huncha biye");
						delaytimer = delaytimer - 0.3f;
					}
				}
				timer = delaytimer;
			}
		} else {
			for(int i = 0;i<transform.childCount;i++){
				Destroy (transform.GetChild(i).gameObject);
			}
		}

//		if(onetimeruncondition == false){
//			if((CircleMakerGroup.instance.circlemakerslist.Count + 1) % 5 == 0 && circlespeed <= 2 && delaytimer >= 0.75){
//				Debug.Log ("halluh");
////				Debug.Log (onetimeruncondition);
//				onetimeruncondition = true;
////				Debug.Log (onetimeruncondition);
//			}

//			Debug.Log (onetimeruncondition);
//		}
//		Debug.Log (onetimeruncondition);
		//onetimeruncondition = false;

		//onetimeruncondition = !onetimeruncondition;
	}

	public void makeAllPowerBall(){
		for(int i = 0;i < transform.childCount;i++){
			transform.GetChild (i).GetComponent<CircleMaker> ().makeAllPowerBall ();
		}
	}
}
