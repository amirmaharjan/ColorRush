using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using UnityEngine.UI;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using GooglePlayGames.BasicApi.SavedGame;

public class GoogleService : MonoBehaviour {

	public static GoogleService instance;
	private Text signInButtonText;
	private Text authStatus;
	// Use this for initialization
	void Start () {
		// create client configuration
		// PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder ().Build ();
		PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().EnableSavedGames().Build();

		PlayGamesPlatform.DebugLogEnabled = true;

		PlayGamesPlatform.InitializeInstance (config);
		PlayGamesPlatform.Activate ();
		
		// trying silent sign-in
		PlayGamesPlatform.Instance.Authenticate (SignInCallback, true);
		
		signInButtonText = GameObject.Find ("SignIn").GetComponentInChildren<Text> ();
		authStatus = GameObject.Find ("Auth").GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private string GetSaveString(){
		string r = "";
		r += PlayerPrefs.GetInt("highscore").ToString();

		return r;
	}

	private void LoadSaveString (string save){
		//string data = save;
		PlayerPrefs.SetInt ("highscore", int.Parse(save));
	}

	// cloud saving
	private bool isSaving = false;
	public void OpenSave(bool saving){
		if (Social.localUser.authenticated) {
			isSaving = saving;
			((PlayGamesPlatform)Social.Active).SavedGame.OpenWithAutomaticConflictResolution ("Color Rush", 
				GooglePlayGames.BasicApi.DataSource.ReadCacheOrNetwork, ConflictResolutionStrategy.UseLongestPlaytime, SavedGameOpened);
		}
	}

	private void SavedGameOpened(SavedGameRequestStatus status, ISavedGameMetadata meta){
		if (status == SavedGameRequestStatus.Success) {
			if (isSaving) { // saving
				byte[] data = System.Text.ASCIIEncoding.ASCII.GetBytes(GetSaveString());
				SavedGameMetadataUpdate update = new SavedGameMetadataUpdate.Builder ().WithUpdatedDescription ("Saved at " + DateTime.Now.ToString()).Build();

				((PlayGamesPlatform)Social.Active).SavedGame.CommitUpdate(meta,update, data, SaveUpdate); 
			} else { // reading
				((PlayGamesPlatform)Social.Active).SavedGame.ReadBinaryData(meta, SaveRead);
			}
		}
	}

	// load
	private void SaveRead (SavedGameRequestStatus status, byte[] data){
		if (status == SavedGameRequestStatus.Success) {
			string saveData = System.Text.ASCIIEncoding.ASCII.GetString (data);
			LoadSaveString (saveData);
		}
	}

	// success save
	private void SaveUpdate(SavedGameRequestStatus status, ISavedGameMetadata meta){

	}

	public void SignIn(){
		FindObjectOfType<AudioManager> ().Play ("Touch");
		if (!PlayGamesPlatform.Instance.localUser.authenticated) {
			PlayGamesPlatform.Instance.Authenticate (SignInCallback, false);
		} else {
			PlayGamesPlatform.Instance.SignOut ();
			signInButtonText.text = "Sign In";
			authStatus.text = "";
		}
	}

	public void SignInCallback(bool success){
		if (success) {
			signInButtonText.text = "Sign Out";
			authStatus.text = "User: " + Social.localUser.userName;
		} else {
			signInButtonText.text = "Sign In";
			authStatus.text = "";
		}
	}

	public void SignInCallLeaderboard(bool success){
		if (success) {
			AdController.instance.showAd ();
			postingScore ();
			signInButtonText.text = "Sign Out";
			authStatus.text = "User: " + Social.localUser.userName;
			PlayGamesPlatform.Instance.ShowLeaderboardUI ();
		}
	}

	public void ShowLeaderboard(){
		FindObjectOfType<AudioManager> ().Play ("Touch");
		if (!PlayGamesPlatform.Instance.localUser.authenticated) {
			PlayGamesPlatform.Instance.Authenticate (SignInCallLeaderboard, false);
		} else if (PlayGamesPlatform.Instance.localUser.authenticated) {
			AdController.instance.showAd ();
			postingScore ();
			PlayGamesPlatform.Instance.ShowLeaderboardUI ();
		}
	}


	public void postingScore(){
		string storedScore = ScoreManger.Decrypt(PlayerPrefs.GetString("highscore"));
		int convertedScore = Int32.Parse(storedScore);

		PlayGamesPlatform.Instance.ReportScore (convertedScore, CRGPGSIds.leaderboard_color_rush,(bool success) => {
		});
	}
}
