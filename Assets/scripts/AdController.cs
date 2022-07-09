using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdController : MonoBehaviour {

	public static AdController instance;
	public static int counter = 0;

	// Use this for initialization
	void Start () {

		Advertisement.Initialize ("1672861");
		if (instance == null) {
			instance = this;
		}
		DontDestroyOnLoad (this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void showAd(){
		if (Advertisement.IsReady ()) {
			Advertisement.Show ();
		}
	}
}
