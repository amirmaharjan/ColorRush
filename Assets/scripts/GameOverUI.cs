using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames;

public class GameOverUI : MonoBehaviour {

//	int backid = 0;
	public static GameOverUI instance;


	[SerializeField]
	Text score;

	[SerializeField]
	Text highscore;

	[SerializeField]
	List<GameObject> circlemakers;

	private Text appreciate;

	// Use this for initialization
	void Start () {
//		CircleMaker.instance.makecondition = false;
//		for(int i = 0;i<circlemakers.Count;i++){
//			circlemakers [i].gameObject.transform.GetComponent<CircleMaker> ().makecondition = false;
//		}

		CircleMakerGroup.instance.makecondition = false;
		score.text = ScoreManger.instance.score.ToString();
		highscore.text = ScoreManger.instance.highscore.ToString();
//		highscore.text = ScoreManger.instance.gethighscore;
		AdController.counter++;
		Debug.Log ("Counter Value is : " + AdController.counter);
		if (AdController.counter % 2 == 0) {
			AdController.instance.showAd ();
			Debug.Log ("asd");
		}


		if (PlayGamesPlatform.Instance.localUser.authenticated) {
			PlayGamesPlatform.Instance.ReportScore (ScoreManger.instance.score, CRGPGSIds.leaderboard_color_rush,(bool success) => {
			});
		}
		if(ScoreManger.instance.score > ScoreManger.instance.highscore){
//			PlayerPrefs.SetInt ("highscore",ScoreManger.instance.score);
			PlayerPrefs.SetString ("highscore", ScoreManger.Encrypt(ScoreManger.instance.score.ToString()));
			ScoreManger.instance.gethighscore = ScoreManger.Decrypt(PlayerPrefs.GetString ("highscore"));
			if (PlayGamesPlatform.Instance.localUser.authenticated) {
				GoogleService.instance.OpenSave (true);
			}
		}
			

		appreciate = GameObject.Find ("Appreciate").GetComponent<Text> ();

		if (ScoreManger.instance.score > 0 && ScoreManger.instance.score < 50) {
			appreciate.text = "Beginner";
		}else if (ScoreManger.instance.score > 50 && ScoreManger.instance.score < 90){
			appreciate.text = "Semi-Pro";
		}else if (ScoreManger.instance.score > 90 && ScoreManger.instance.score < 110){
			appreciate.text = "Professional";
		}else if (ScoreManger.instance.score > 110 && ScoreManger.instance.score < 140){
			appreciate.text = "World Class";
		}else if (ScoreManger.instance.score > 140 && ScoreManger.instance.score < 170){
			appreciate.text = "Legendary";
		}else if (ScoreManger.instance.score > 170){
			appreciate.text = "God Level";
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void onClick(){
		FindObjectOfType<AudioManager> ().Play ("Touch");
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);

		GameController.instance.counter ++;
		if(GameController.instance.counter == 4){
			GameController.instance.counter = 0;	
		}
//		backid = backid + 1;
	}

	public void onHomeClick(){
		FindObjectOfType<AudioManager> ().Play ("Touch");
		SceneManager.LoadScene ("menu");
	}
}
