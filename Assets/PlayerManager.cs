using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour {

	// Use this for initialization
	public GameObject waves;
	public GameObject ExitMenu;
	public GameObject PauseMenu;
	public GameObject mainCamera;
	public GameObject coral;
	public GameObject scoreboard;
	public GameObject scoreboardGold;
	public GameObject scoreboardBlue;
	public GameObject scoreboardGreen;
	public GameObject HealthBoard;
	public Sprite[] heartsImg;
	public GameObject ExitSCreen;
	public GameObject Gameoverascreen;
	public GameObject spawnpointScreen;
	bool damaged =false;
	public GameObject TreasurePref;
	public GameObject KeyPref;
	public Image DamageImage;
	public float flashSpeed = 100f; 
	public Color flashColour = new Color(255f, 0f, 0f, 0.1f); 
	public int time=10;
	public AudioSource BgSOundBubbles;
	public AudioSource warningTimer;
	public AudioClip bgBubbleClip;
	public AudioClip levelCompleteClip;
	public AudioClip starCollectClip;
	public AudioClip timerClip;
	public AudioClip clickSound;
	public AudioClip damgedClip;
	public AudioClip touchfishSound;
	void OnEnable()
	{
		coral.SetActive(false);
		scoreboard.transform.FindChild("Text").GetComponent<Text>().text = "0";
		scoreboardGold.transform.FindChild("Text").GetComponent<Text>().text = "0";	
		scoreboardBlue.transform.FindChild("Text").GetComponent<Text>().text = "0";	
		scoreboardGreen.transform.FindChild("Text").GetComponent<Text>().text = "0";	
		HealthBoard.GetComponent<Image>().sprite = heartsImg[6];
		scoreboard.SetActive(false);
		scoreboardGold.SetActive(false);
		scoreboardGreen.SetActive(false);
		scoreboardBlue.SetActive(false);
		HealthBoard.SetActive(false);
	}



	void Start () {
		
	}
	public void RestartMyGame()
	{
		User.PlayerHealth=6;
		User.PlayerScore=0;
		Application.LoadLevel("Demo");
	}

	public void Exitscreen()
	{
		
		ExitSCreen.SetActive(true);
		spawnpointScreen.SetActive(false);
		mainCamera.GetComponent<RippleEffect>().enabled = false;
		coral.SetActive(false);
		Gameoverascreen.SetActive(false);

		//Time.timeScale=0;
	}

	public void OnExitYes()
	{
		Application.Quit();
	}
	public void onCancelExit()
	{
		ExitSCreen.SetActive(false);
		spawnpointScreen.SetActive(true);
		mainCamera.GetComponent<RippleEffect>().enabled = true;
		coral.SetActive(true);
		//Time.timeScale=1;
	}

	public void PlayGame()
	{
		User.PlayerHealth=6;
		HealthBoard.GetComponent<Image>().sprite=heartsImg[(User.PlayerHealth)];

		coral.SetActive(true);
		scoreboard.SetActive(true);
		scoreboardGold.SetActive(true);
		scoreboardGreen.SetActive(true);
		scoreboardBlue.SetActive(true);
		HealthBoard.SetActive(true);
		BgSOundBubbles.PlayOneShot(clickSound);
		GameObject.Find("Main Camera").GetComponent<RippleEffect>().enabled=true;
		waves.GetComponent<MeshRenderer>().enabled= true;
		spawnpointScreen.SetActive(true);
		BgSOundBubbles.clip = bgBubbleClip;
		BgSOundBubbles.Play();

	}

	public void ScoreUpdater(string startype)
	{
		var temp = User.total_score;

		if(temp==50)
		{
			temp=0;
			spawnpointScreen.GetComponent<spwanFish>().spwanspeed=0.50f;
		}

		BgSOundBubbles.PlayOneShot(starCollectClip);
		if(startype.Equals("Diamond"))
		{
			scoreboard.transform.FindChild("Text").GetComponent<Text>().text = User.PlayerScore.ToString();
		}
		else if(startype.Equals("Gold"))
		{
			scoreboardGold.transform.FindChild("Text").GetComponent<Text>().text = User.PlayerScoreGold.ToString();
		}
		else if(startype.Equals("Green"))
		{
			scoreboardGreen.transform.FindChild("Text").GetComponent<Text>().text = User.PlayerScoreGreen.ToString();
		}
		else if(startype.Equals("Blue"))
		{
			scoreboardBlue.transform.FindChild("Text").GetComponent<Text>().text = User.PlayerScoreBlue.ToString();
		}
		else if(startype.Equals("Treasure"))
		{
			scoreboardBlue.transform.FindChild("Text").GetComponent<Text>().text = User.PlayerScoreBlue.ToString();
			scoreboardGreen.transform.FindChild("Text").GetComponent<Text>().text = User.PlayerScoreGreen.ToString();
			scoreboardGold.transform.FindChild("Text").GetComponent<Text>().text = User.PlayerScoreGold.ToString();
			scoreboard.transform.FindChild("Text").GetComponent<Text>().text = User.PlayerScore.ToString();
		}



		ScoreSum(User.PlayerScoreBlue,User.PlayerScoreGold,User.PlayerScoreGreen,User.PlayerScore);

		if(User.total_score==30)
		{
			CreateTreasure();
			startTimer();
		}
	}

	public void ScoreSum(int blue , int gold , int green , int diamond )
	{
		User.total_score = blue+green+gold+diamond;
	}


	public void startTimer()
	{
		StartCoroutine("Timer");
		warningTimer.clip = timerClip;
		warningTimer.Play();
		warningTimer.loop = true;
	}
	IEnumerator Timer()
	{
		while(true)
		{
			yield return new WaitForSeconds(1);
			time--;
			if(time==0)
			{
				StopCoroutine("Timer");
				GameObject treasure = GameObject.Find("treasure 1(Clone)");
				GameObject key = GameObject.Find("KeyPrefab(Clone)");
				Destroy(treasure);
				Destroy(key);
				warningTimer.clip = timerClip;
				warningTimer.Stop();
			}
		}
	}
	public void LifeManager()
	{
		damaged=true;

		HealthBoard.GetComponent<Image>().sprite = heartsImg[(User.PlayerHealth)];

		warningTimer.PlayOneShot(damgedClip);
	}

	public void playclicksound()
	{
		warningTimer.PlayOneShot(touchfishSound);
	}

	public void Gameover()
	{

		scoreboard.SetActive(false);
		scoreboardBlue.SetActive(false);
		scoreboardGold.SetActive(false);
		scoreboardGreen.SetActive(false);


		coral.SetActive(false);
		GameObject.Find("Main Camera").GetComponent<RippleEffect>().enabled=false;
		spawnpointScreen.SetActive(false);
		waves.GetComponent<MeshRenderer>().enabled= false;


		//GameObject.Find("FishSpawn Point").GetComponent<spwanFish>().StopAllCoroutines();

		Gameoverascreen.SetActive(true);
		BgSOundBubbles.Stop();
	}
	public void CreateTreasure()
	{

		BgSOundBubbles.PlayOneShot(levelCompleteClip);
		Transform parent = GameObject.Find("Canvas").transform.FindChild("FishSpawn Point").transform;
		GameObject treasure = (GameObject)Instantiate(TreasurePref,transform.position,Quaternion.identity,parent);
		treasure.transform.SetAsFirstSibling();
		treasure.GetComponent<RectTransform>().localPosition  = new Vector3 (75,100,0);
		//treasure.GetComponent<RectTransform>().localPosition = new Vector3 (transform.position.x,transform.position.y,0);
		GameObject key = (GameObject)Instantiate(KeyPref,Vector3.zero,Quaternion.identity,parent);
		key.name = "Key";
		key.GetComponent<RectTransform>().localPosition = new Vector3 (-290,249,0);
		key.transform.rotation =   Quaternion.Euler(0,0,0);
	}
	
	// Update is called once per frame
	void Update () {

		if(damaged)
		{
			// ... set the colour of the damageImage to the flash colour.

			DamageImage.color = flashColour;
		}
		// Otherwise...
		else
		{
			// ... transition the colour back to clear.
			DamageImage.color = Color.Lerp (DamageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}

		if(Input.GetKey(KeyCode.Escape))
		{
			Exitscreen();
		}

		damaged = false;
	}



	public void ExitMenuYes()
	{
		PauseMenu.SetActive(false);
		ExitMenu.SetActive(true);
	}

	public void ExitMenuNo()
	{
		PauseMenu.SetActive(true);
		ExitMenu.SetActive(false);
	}
}
