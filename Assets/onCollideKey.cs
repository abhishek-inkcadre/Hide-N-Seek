using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onCollideKey : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) 
	{
		Debug.Log("collided");
		if (other.gameObject.tag == "Key" )
		{
			
			Debug.Log("got keys");
			Destroy(other.gameObject);
			this.gameObject.GetComponent<Animator>().SetBool("onCollide",true);


			GameObject sound = GameObject.Find("SoundManager");
			var audioSrc = sound.GetComponent<AudioSource>();
			audioSrc.Stop();

			User.PlayerScoreBlue = User.PlayerScoreBlue+5;
			User.PlayerScoreGold = 	User.PlayerScoreGold+5;
			User.PlayerScoreGold = User.PlayerScoreGold+5;
			User.PlayerScore = User.PlayerScore+5;

			GameObject.Find("Canvas").GetComponent<PlayerManager>().ScoreUpdater("Treasure");

			StartCoroutine(deleteIt());
		}


	}

	void OnMouseDown()
	{
		GameObject key = GameObject.Find("Key");

		key.GetComponent<Animator>().SetBool("OnTreasure",true);
	}


	IEnumerator deleteIt()
	{

		yield return new WaitForSeconds(3);
		GameObject del = GameObject.Find("New Treausre(Clone)");

		Destroy(del);
	}
}
