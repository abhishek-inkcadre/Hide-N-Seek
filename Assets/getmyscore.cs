using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class getmyscore : MonoBehaviour {


	public Text blue;
	public Text Green;
	public Text Gold;
	public Text Diamond;

	// Use this for initialization
	void Start () {

		Diamond.text = User.PlayerScore.ToString();
		blue.text = User.PlayerScoreBlue.ToString();
		Green.text = User.PlayerScoreGreen.ToString();
		Gold.text = User.PlayerScoreGold.ToString();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
