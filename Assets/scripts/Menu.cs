using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using System.Text;

public class Menu : MonoBehaviour {

	public static bool sound = true;

	[SerializeField]
	Text highscore;

	[SerializeField]
	GameObject soundobject;

	[SerializeField]
	List<Sprite> soundsprites;          

	Image myimage;

	// Use this for initialization
	void Start () {
		myimage = soundobject.GetComponent<Image> ();
		if (sound == true) {
			myimage.sprite = soundsprites [0];
		} else {
			myimage.sprite = soundsprites [1];
		}

		string st = ScoreManger.Decrypt (PlayerPrefs.GetString ("highscore"));
		int sc = Int32.Parse (st);
		highscore.text = st.ToString();
//		Debug.Log (ScoreManger.Encrypt ("5"));
//		Debug.Log (ScoreManger.Decrypt (PlayerPrefs.GetString ("highscore")));
		Debug.Log ((PlayerPrefs.GetString ("highscore")));
		Debug.Log (ScoreManger.Decrypt (PlayerPrefs.GetString ("highscore")));
		//highscore.text = PlayerPrefs.GetInt ("highscore").ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	public void SoundOff(){
		sound = !sound;
		if (sound) {
			FindObjectOfType<AudioManager> ().Play ("Touch");
			myimage.sprite = soundsprites [0];
			AudioListener.volume = 1f;
		} else {
			myimage.sprite = soundsprites [1];
			AudioListener.volume = 0f;
		}
	}

	public void onPlayClick(){
		FindObjectOfType<AudioManager> ().Play ("Touch");
		SceneManager.LoadScene ("colorrush1");
	}

	public void onQuitClick(){
		FindObjectOfType<AudioManager> ().Play ("Touch");
		Application.Quit ();
	}
}
