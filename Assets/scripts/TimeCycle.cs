using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCycle : MonoBehaviour {

	[SerializeField]
	List<Sprite> timesofday;

	Image myimage;

	// Use this for initialization
	void Start () {
		myimage = GetComponent<Image> ();
		myimage.sprite = timesofday [GameController.instance.counter];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
