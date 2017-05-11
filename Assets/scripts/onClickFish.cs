using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onClickFish : MonoBehaviour {

	// Use this for initialization

	public GameObject diamondPref;
	public GameObject BlueStarPref;
	public GameObject GreenStarPref;
	public GameObject GoldStarpref;
	public Transform SpwanPoint;
	public PlayerManager init = new PlayerManager();

	void Start () {

		init = GameObject.Find("Canvas").GetComponent<PlayerManager>();

	}

	void OnMouseDown()
	{
			
		if(this.gameObject.tag.Equals("Fish"))
		{
			init.playclicksound();
			Transform parent = GameObject.Find("Canvas").transform.FindChild("FishSpawn Point").transform;
			Vector3 pos = this.gameObject.transform.position;
			GameObject diamond = (GameObject)Instantiate(GoldStarpref,pos,Quaternion.identity,parent);

			Destroy(this.gameObject); 


			User.PlayerScoreGold = User.PlayerScoreGold+1;
			GameObject.Find("Canvas").GetComponent<PlayerManager>().ScoreUpdater("Gold");
		}
		else if(this.gameObject.tag.Equals("StarFish"))
		{
			init.playclicksound();
			Transform parent = GameObject.Find("Canvas").transform.FindChild("FishSpawn Point").transform;
			Vector3 pos = this.gameObject.transform.position;
			GameObject diamond = (GameObject)Instantiate(GreenStarPref,pos,Quaternion.identity,parent);

			Destroy(this.gameObject); 


			User.PlayerScoreGreen = User.PlayerScoreGreen+1;
			GameObject.Find("Canvas").GetComponent<PlayerManager>().ScoreUpdater("Green");
		}
		else if(this.gameObject.tag.Equals("JellyFish"))
		{
			init.playclicksound();
			Transform parent = GameObject.Find("Canvas").transform.FindChild("FishSpawn Point").transform;
			Vector3 pos = this.gameObject.transform.position;
			GameObject diamond = (GameObject)Instantiate(BlueStarPref,pos,Quaternion.identity,parent);

			Destroy(this.gameObject); 


			User.PlayerScoreBlue = User.PlayerScoreBlue+1;
			GameObject.Find("Canvas").GetComponent<PlayerManager>().ScoreUpdater("Blue");
		}
		else if(this.gameObject.tag.Equals("SeaHorse"))
		{
			init.playclicksound();
			Transform parent = GameObject.Find("Canvas").transform.FindChild("FishSpawn Point").transform;
			Vector3 pos = this.gameObject.transform.position;
			GameObject diamond = (GameObject)Instantiate(diamondPref,pos,Quaternion.identity,parent);

			Destroy(this.gameObject); 


			User.PlayerScore = User.PlayerScore+1;
			GameObject.Find("Canvas").GetComponent<PlayerManager>().ScoreUpdater("Diamond");
		}


		else
		{
			init.playclicksound();
			Debug.Log("else enemy");
			if(User.PlayerHealth>0)
			{
				Destroy(this.gameObject); 
				Debug.Log("before"+User.PlayerHealth);
				User.PlayerHealth= User.PlayerHealth-1;
				if(User.PlayerHealth==0)
				{
					Debug.Log("else="+User.PlayerHealth);
					GameObject.Find("Canvas").GetComponent<PlayerManager>().Gameover();
					GameObject.Find("Canvas").GetComponent<PlayerManager>().LifeManager();
					Debug.Log("after"+User.PlayerHealth);
				}
				else
				{
					GameObject.Find("Canvas").GetComponent<PlayerManager>().LifeManager();
					Debug.Log("after"+User.PlayerHealth);
				}
				Handheld.Vibrate();
			}

		}

	}

	// Update is called once per frame
	void Update () {


	}

}
