using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMaker : MonoBehaviour {

	[SerializeField]
	List<GameObject> circles;

	[SerializeField]
	List<GameObject> specialcircles;

	public List<GameObject> circlescollector;

	public int currentpossiblematches = 0;

	public int hitcounter = 0;

	bool destroyallchildren;

//	float timer;
//
//	[SerializeField]
//	public float delaytimer;
//
//	[SerializeField]
//	public float circlespeed;
//
//	public static CircleMaker instance;
//
//	public bool makecondition;

//	[SerializeField]
//	GameObject circleholder;

//	[SerializeField]
//	List<GameObject> circleholderchildren;

	// Use this for initialization
	void Start () {
		destroyallchildren = true;
		circlescollector = new List<GameObject> ();
//		if(instance == null){
//			instance = this;
//		}
//		makecondition = true;
//		timer = delaytimer;
//		for(int i = 0;i<4;i++){
//			circleholderchildren.Add (this.transform.GetChild(i).gameObject);
//		}

//		for(int i = 0;i<4;i++){
//			if(i==0){
//				int randomcircle = Random.Range (0,4);
//				circlescollector.Add (Instantiate (circles[randomcircle].gameObject,this.transform));
//				circlescollector[i].transform.localPosition = new Vector3 (-1.65f,0,0);
//			}
//			if(i==1){
//				int randomcircle = Random.Range (0,4);
//				circlescollector.Add (Instantiate (circles[randomcircle].gameObject,this.transform));
//				circlescollector[i].transform.localPosition = new Vector3 (-0.54f,0,0);
//			}
//			if(i==2){
//				int randomcircle = Random.Range (0,4);
//				circlescollector.Add (Instantiate (circles[randomcircle].gameObject,this.transform));
//				circlescollector[i].transform.localPosition = new Vector3 (0.54f,0,0);
//			}
//			if(i==3){
//				int randomcircle = Random.Range (0,4);
//				circlescollector.Add (Instantiate (circles[randomcircle].gameObject,this.transform));
//				circlescollector[i].transform.localPosition = new Vector3 (1.65f,0,0);
//			}
//		}

		MakeCircle ();
		while(currentpossiblematches == 0){
			for(int i = 0;i<4;i++){
//				Debug.Log ("Aakash mero chew ma basira cha!!! bichara coutihno barca gaye cha!!!");
				int randomnumber1 = Random.Range (0,4);
				int randomnumber2 = Random.Range (0,4);
				float swapnumber1 = circlescollector [randomnumber1].transform.localPosition.x;
				float swapnumber2 = circlescollector [randomnumber2].transform.localPosition.x;
				circlescollector [randomnumber1].transform.localPosition = new Vector3 (swapnumber2,0,0);
				circlescollector [randomnumber2].transform.localPosition = new Vector3 (swapnumber1,0,0);
				GameObject temp = circlescollector [randomnumber1];
				circlescollector [randomnumber1] = circlescollector [randomnumber2];
				circlescollector [randomnumber2] = temp;
			}
			calculateCurrentPossibleMatches();
		}
//		calculateCurrentPossibleMatches ();
//		if (currentpossiblematches == 0) {
//			for(int i = 0;i<this.transform.childCount;i++){
//				Destroy (this.transform.GetChild(i).gameObject);
//			}
//			MakeCircle ();
//			calculateCurrentPossibleMatches ();
//		}
	}
	
	// Update is called once per frame
	void Update () {

//		if(currentpossiblematches == 0){
//			for(int i = 0;i<this.transform.childCount;i++){
//				this.transform.GetChild (i).GetComponent<Circle> ().movesidecondition = true;
//			}
//		}

		if(hitcounter > 0){
			if(currentpossiblematches == hitcounter){
//				Debug.Log ("finally");
				for(int i = 0;i<this.transform.childCount;i++){
					this.transform.GetChild (i).GetComponent<Circle> ().movesidecondition = true;
					this.transform.GetChild (i).GetComponent<Circle> ().nocalculationneeded = true;
				}
			}	
		}

//		if (currentpossiblematches == 0) {
//			
//		}
//		if (currentpossiblematches == 0) {
//			Debug.Log ("Current Possibilites 0 bhako thyo so yo code run bhayo");
//			for(int i = 0;i<this.transform.childCount;i++){
//				Destroy (this.transform.GetChild(i).gameObject);
//			}
//			MakeCircle ();
//			calculateCurrentPossibleMatches ();
//		}
//		if (currentpossiblematches > 0){
//			if(currentpossiblematches == hitcounter){
//				Debug.Log ("finally");
//				Destroy (this.gameObject);
//			}
//		}
//		if(makecondition == true){
//			timer -= Time.deltaTime;
//			if(timer <= 0){
//				int randomcircle = Random.Range (0,4);
//				GameObject instantiatedcircle =  Instantiate (circles[randomcircle].gameObject,this.transform);
//				if(instantiatedcircle.tag == circleholder.tag){
//					GameController.instance.currentpossiblematches++;
//				}
//				timer = delaytimer;
//			}
//		if(makecondition == true){
//			timer -= Time.deltaTime;
//			if(timer <= 0){
//				int randomcircle = 0;
//				Instantiate (circles[randomcircle].gameObject,this.transform);
//				timer = delaytimer;
//			}
//		}
	}

	public void MakeCircle(){
		if (CircleMakerGroup.instance.circlemakerslist.Count % 10 == 0) {
			int randomselector2 = Random.Range (0,4);
			for(int i = 0;i<4;i++){
				if(i==0){
					if(randomselector2 == 0){
						int randomcircle = Random.Range (0,2);
						circlescollector.Add (Instantiate (specialcircles[randomcircle].gameObject,this.transform));
						circlescollector[i].transform.localPosition = new Vector3 (-1.46f,0,0);
					}else{
						int randomcircle = Random.Range (0,4);
						circlescollector.Add (Instantiate (circles[randomcircle].gameObject,this.transform));
						circlescollector[i].transform.localPosition = new Vector3 (-1.46f,0,0);	
					}
				}
				if(i==1){
					if(randomselector2 == 1){
						int randomcircle = Random.Range (0,2);
						circlescollector.Add (Instantiate (specialcircles[randomcircle].gameObject,this.transform));
						circlescollector[i].transform.localPosition = new Vector3 (-0.46f,0,0);
					}else{
						int randomcircle = Random.Range (0,4);
						circlescollector.Add (Instantiate (circles[randomcircle].gameObject,this.transform));
						circlescollector[i].transform.localPosition = new Vector3 (-0.46f,0,0);	
					}
				}
				if(i==2){
					if(randomselector2 == 2){
						int randomcircle = Random.Range (0,2);
						circlescollector.Add (Instantiate (specialcircles[randomcircle].gameObject,this.transform));
						circlescollector[i].transform.localPosition = new Vector3 (0.46f,0,0);
					}else{
						int randomcircle = Random.Range (0,4);
						circlescollector.Add (Instantiate (circles[randomcircle].gameObject,this.transform));
						circlescollector[i].transform.localPosition = new Vector3 (0.46f,0,0);	
					}
				}
				if(i==3){
					if(randomselector2 == 3){
						int randomcircle = Random.Range (0,2);
						circlescollector.Add (Instantiate (specialcircles[randomcircle].gameObject,this.transform));
						circlescollector[i].transform.localPosition = new Vector3 (1.46f,0,0);
					}else{
						int randomcircle = Random.Range (0,4);
						circlescollector.Add (Instantiate (circles[randomcircle].gameObject,this.transform));
						circlescollector[i].transform.localPosition = new Vector3 (1.46f,0,0);	
					}
				}
			}
		} else {
			for(int i = 0;i<4;i++){
				if(i==0){
					int randomcircle = Random.Range (0,4);
					circlescollector.Add (Instantiate (circles[randomcircle].gameObject,this.transform));
					circlescollector[i].transform.localPosition = new Vector3 (-1.46f,0,0);
				}
				if(i==1){
					int randomcircle = Random.Range (0,4);
					circlescollector.Add (Instantiate (circles[randomcircle].gameObject,this.transform));
					circlescollector[i].transform.localPosition = new Vector3 (-0.49f,0,0);
				}
				if(i==2){
					int randomcircle = Random.Range (0,4);
					circlescollector.Add (Instantiate (circles[randomcircle].gameObject,this.transform));
					circlescollector[i].transform.localPosition = new Vector3 (0.49f,0,0);
				}
				if(i==3){
					int randomcircle = Random.Range (0,4);
					circlescollector.Add (Instantiate (circles[randomcircle].gameObject,this.transform));
					circlescollector[i].transform.localPosition = new Vector3 (1.46f,0,0);
				}
			}	
		}
	}

	public void calculateCurrentPossibleMatches(){
//		for(int i = 0;i<4;i++){
//			if(i == 0){
//				if(circlemakergroupreference.GetComponent<CircleMakerGroup>().circlemakerslist.Last.Value.gameObject.GetComponent<CircleMaker>().circlescollector[i].tag == "blue"){
//					currentpossiblematches++;
//				}
//			}
//			if(i == 1){
//				if(circlemakergroupreference.GetComponent<CircleMakerGroup>().circlemakerslist.Last.Value.gameObject.GetComponent<CircleMaker>().circlescollector[i].tag == "orange"){
//					currentpossiblematches++;
//				}
//			}
//			if(i == 2){
//				if(circlemakergroupreference.GetComponent<CircleMakerGroup>().circlemakerslist.Last.Value.gameObject.GetComponent<CircleMaker>().circlescollector[i].tag == "purple"){
//					currentpossiblematches++;
//				}
//			}
//			if(i == 3){
//				if(circlemakergroupreference.GetComponent<CircleMakerGroup>().circlemakerslist.Last.Value.gameObject.GetComponent<CircleMaker>().circlescollector[i].tag == "white"){
//					currentpossiblematches++;
//				}
//			}
//		}
		if(circlescollector[0].tag == "blue"){
			currentpossiblematches++;
		}
		if(circlescollector[1].tag == "orange"){
			currentpossiblematches++;
		}
		if(circlescollector[2].tag == "purple"){
			currentpossiblematches++;
		}
		if(circlescollector[3].tag == "white"){
			currentpossiblematches++;
		}

//		while (currentpossiblematches <= 0 ){
//			for(int i = 0;i<this.transform.childCount;i++){
//				Destroy (this.transform.GetChild(i));
//			}
//			MakeCircle ();
//			calculateCurrentPossibleMatches ();
//		}
//
//		Debug.Log (currentpossiblematches);
	}

	public void dropBall(){
//		for(int i = 0;i<circlescollector.Count;i++){
//			circlescollector [i].GetComponent<Rigidbody2D> ().gravityScale = 2f;
//			circlescollector [i].GetComponent<Circle> ().gameovercondition = false;
//		}
		for(int  i = 0;i<transform.childCount;i++){
//			Debug.Log (transform.childCount);
			this.transform.GetChild (i).GetComponent<Rigidbody2D> ().gravityScale = 2f;
			this.transform.GetChild (i).GetComponent<Circle> ().gameovercondition = false;
		}
	}

	public void makeAllPowerBall(){
		for(int i = 0;i < transform.childCount;i++){
			transform.GetChild (i).GetComponent<Circle> ().makePowerBall ();
		}
//		StartCoroutine (makeBallsNormal());
	}

	IEnumerator makeBallsNormal(){
		yield return new WaitForSeconds (5f);
		for(int i = 0;i < transform.childCount;i++){
			transform.GetChild (i).GetComponent<Circle> ().makeNormalBall ();
		}
	}
}
