using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;
using System.Security.Cryptography;

public class ScoreManger : MonoBehaviour {

	public int score;
	public static ScoreManger instance;
	public int lives;
	public bool alreadyPlayed = false;
//	float delaytimer = 10;
//	float timer;
//	public delegate void IncreaseSpeed();
//	public static event IncreaseSpeed increasespeed;


	[SerializeField]
	Text scoretext;

	[SerializeField]
	public GameObject gameoverui;

//	[SerializeField]
//	Text timetext;
//
//	[SerializeField]
//	float time = 0;

	[SerializeField]
	public GameObject livesgroup;

	bool stoprepeatcondition;
	public string gethighscore;
	public int highscore;

	[SerializeField]
	Text highscoretext;

	[SerializeField]
	GameObject buttongroup;

	void Awake(){
		if (String.IsNullOrEmpty((PlayerPrefs.GetString("highscore")))){
			string initialScore = "0";
			PlayerPrefs.SetString ("highscore", Encrypt(initialScore));
		}
	}


	// Use this for initialization
	void Start () {
		if(instance == null){
			instance = this;
		}
		score = 0;
		lives = 3;
//		timer = delaytimer;
		//highscore = PlayerPrefs.GetInt ("highscore");
		gethighscore = Decrypt(PlayerPrefs.GetString("highscore"));
		highscore = Int32.Parse (gethighscore);
		stoprepeatcondition = false;
	}
	
	// Update is called once per frame
	void Update () {

		if(score > highscore){
			PlayerPrefs.SetString ("highscore",Encrypt(score.ToString()));
//			highscore = PlayerPrefs.GetInt ("highscore");
			gethighscore = Decrypt(PlayerPrefs.GetString("highscore"));
			highscore = Int32.Parse (gethighscore);
		}

		scoretext.text = score.ToString();
//		timetext.text = time.ToString ("f0");
		//highscoretext.text = highscore.ToString();
		highscoretext.text = gethighscore;
//		time += Time.deltaTime;
//		timer -= Time.deltaTime;

//		if (timer <= 0) {
//			stoprepeatcondition = false;
//			if (score < time) {
//				gameoverui.SetActive (enabled);
//			} else {
//				if(stoprepeatcondition == false){
//					if(CircleMakerGroup.instance.circlespeed >= 0.75 && CircleMakerGroup.instance.delaytimer < 2){
//						CircleMakerGroup.instance.circlespeed = CircleMakerGroup.instance.circlespeed + 0.5f;
//						CircleMakerGroup.instance.delaytimer = CircleMakerGroup.instance.delaytimer - 0.5f;
//						Debug.Log (CircleMakerGroup.instance.circlespeed);
//						Debug.Log (CircleMakerGroup.instance.delaytimer);
//					}
//				}
//			}
//			stoprepeatcondition  = true;
////			timer = delaytimer;
//		if (score < time) {
//			gameoverui.SetActive (enabled);
//		} else {
//			if(stoprepeatcondition == false){
//				if(CircleMakerGroup.instance.circlespeed >= 0.75 && CircleMakerGroup.instance.delaytimer < 2){
//					CircleMakerGroup.instance.circlespeed = CircleMakerGroup.instance.circlespeed + 0.5f;
//					CircleMakerGroup.instance.delaytimer = CircleMakerGroup.instance.delaytimer - 0.5f;
//					Debug.Log (CircleMakerGroup.instance.circlespeed);
//					Debug.Log (CircleMakerGroup.instance.delaytimer);
//				}
//			}

//		if ((CircleMakerGroup.instance.circlemakerslist.Count + 1) % 5 == 0) {
//			stoprepeatcondition = false;
//			int counter = 1;
//			//if(stoprepeatcondition == false){
//				if(CircleMakerGroup.instance.circlespeed <= 2 && CircleMakerGroup.instance.delaytimer >= 0.75 && stoprepeatcondition == false){
//					CircleMakerGroup.instance.circlespeed = CircleMakerGroup.instance.circlespeed + 0.2f;
//					Debug.Log (CircleMakerGroup.instance.circlespeed);
//
//					CircleMakerGroup.instance.delaytimer = CircleMakerGroup.instance.delaytimer - 0.2f;
//					Debug.Log (CircleMakerGroup.instance.delaytimer);
//					//Debug.Log (counter = counter + 1);
//				stoprepeatcondition = true;
//					
//				}
//			//stoprepeatcondition = true;
//			//}
//
//		}

//		Debug.Log (CircleMakerGroup.instance.circlemakerslist.Count);
//		stoprepeatcondition = false;
//			if((CircleMakerGroup.instance.circlemakerslist.Count + 1) % 5 == 0 && CircleMakerGroup.instance.circlespeed <= 2 && CircleMakerGroup.instance.delaytimer >= 0.75 && stoprepeatcondition == false){
//				CircleMakerGroup.instance.circlespeed = CircleMakerGroup.instance.circlespeed + 0.2f;
////				Debug.Log (CircleMakerGroup.instance.circlespeed);
//
//				CircleMakerGroup.instance.delaytimer = CircleMakerGroup.instance.delaytimer - 0.2f;
////				Debug.Log (CircleMakerGroup.instance.delaytimer);
//				//Debug.Log (counter = counter + 1);
//				stoprepeatcondition = true;
//
//			}
			//stoprepeatcondition = true;
			//}


//

		if(livesgroup.transform.childCount <= 0){
			if (!alreadyPlayed) {
				FindObjectOfType<AudioManager> ().Play ("GameOver");
				alreadyPlayed = true;
			}
//			gameoverui.SetActive (enabled);
			for(int i = 0;i<buttongroup.transform.childCount;i++){
				//Debug.Log ("Life ghateko wala");
				buttongroup.transform.GetChild (i).GetComponent<Button> ().interactable = false;
			}
			for(int i = 0;i<CircleMakerGroup.instance.circlemakerslist.Count;i++){
				CircleMakerGroup.instance.circlemakerslist.Last.Value.GetComponent<CircleMaker> ().dropBall ();
				CircleMakerGroup.instance.circlemakerslist.RemoveLast ();
			}
		}
	}

	private static string hash = "Kathmandu976";

	// Encrypt
	public static string Encrypt (string input){
		byte[] data = UTF8Encoding.UTF8.GetBytes (input);
		using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider ()) {
			byte[] key = md5.ComputeHash (UTF8Encoding.UTF8.GetBytes (hash));
			using (TripleDESCryptoServiceProvider trip = new TripleDESCryptoServiceProvider () {
				Key = key,
				Mode = CipherMode.ECB,
				Padding = PaddingMode.PKCS7
			}) {
				ICryptoTransform tr = trip.CreateEncryptor ();
				byte[] results = tr.TransformFinalBlock (data, 0, data.Length);
				return Convert.ToBase64String (results, 0, results.Length);
			}
		}
	}

	//Decrypt
	public static string Decrypt (string input){
		byte[] data = Convert.FromBase64String (input);
		using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider ()) {
			byte[] key = md5.ComputeHash (UTF8Encoding.UTF8.GetBytes (hash));
			using (TripleDESCryptoServiceProvider trip = new TripleDESCryptoServiceProvider () {
				Key = key,
				Mode = CipherMode.ECB,
				Padding = PaddingMode.PKCS7
			}) {
				ICryptoTransform tr = trip.CreateDecryptor ();
				byte[] results = tr.TransformFinalBlock (data, 0, data.Length);
				return UTF8Encoding.UTF8.GetString (results);
			}
		}
	}
}
