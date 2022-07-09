using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleThrower : MonoBehaviour {

	[SerializeField]
	GameObject circle;

	[SerializeField]
	float speed;

	[SerializeField]
	GameObject ballholder;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void onClick(){
		FindObjectOfType<AudioManager> ().Play ("Touch");
		Instantiate (circle,ballholder.transform);
	}
}
