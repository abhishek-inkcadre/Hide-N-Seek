using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnPlayClick : MonoBehaviour {

	public GameObject backgrndImg;
	// Use this for initialization
	void Start () {

		this.gameObject.GetComponent<Button>().onClick.AddListener( delegate() {
		

			backgrndImg.SetActive(false);
			//this.gameObject.SetActive(false);
			GameObject.Find("Canvas").GetComponent<PlayerManager>().PlayGame();

			User.PlayerScoreGold=0;
			User.PlayerScoreGreen=0;
			User.PlayerScoreBlue=0;
			User.PlayerScore=0;
			User.PlayerHealth=6;
		
		});
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
