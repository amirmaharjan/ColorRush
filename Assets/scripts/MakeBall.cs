using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeBall : MonoBehaviour {

	// Use this for initialization
	[SerializeField]
	List<GameObject> circles;

	float timer;

	[SerializeField]
	public float delaytimer;

	[SerializeField]
	public float circlespeed;

	public static MakeBall instance;

	public bool makecondition;

	// Use this for initialization
	void Start () {
		if(instance == null){
			instance = this;
		}
		makecondition = true;
		timer = delaytimer;
	}

	// Update is called once per frame
	void Update () {
		if(makecondition == true){
			timer -= Time.deltaTime;
			if(timer <= 0){
				int randomcircle = Random.Range (0,4);
				//				Instantiate (circles[randomcircle].gameObject,this.transform);
				Instantiate(circles[randomcircle].gameObject,new Vector3(0,-1,0), new Quaternion());
				timer = delaytimer;
			}
			//		if(makecondition == true){
			//			timer -= Time.deltaTime;
			//			if(timer <= 0){
			//				int randomcircle = 0;
			//				Instantiate (circles[randomcircle].gameObject,this.transform);
			//				timer = delaytimer;
			//			}
		}
	}
}
