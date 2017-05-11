using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartscreenManager : MonoBehaviour {

	// Use this for initialization

	public GameObject Hard;
	public GameObject Medium;
	public GameObject Easy;
	private bool levelBtnOn;
	public GameObject spawnPointScreen;
	void Start () {
		
	}

	public void OnLevelsClick()
	{
		if(!levelBtnOn)
		{
			levelBtnOn = true;
			Hard.SetActive(true);
			Medium.SetActive(true);
			Easy.SetActive(true);

			this.transform.FindChild("Levels").GetComponent<Animator>().enabled=true;
		}
		else
		{
			levelBtnOn = false;
			Hard.SetActive(false);
			Medium.SetActive(false);
			Easy.SetActive(false);


		}

	}

	public void hardLevel()
	{
		Hard.SetActive(false);
		Medium.SetActive(false);
		Easy.SetActive(false);
		spawnPointScreen.GetComponent<spwanFish>().spwanspeed=0.50f;
	}
	public void MediumLevel()
	{
		Hard.SetActive(false);
		Medium.SetActive(false);
		Easy.SetActive(false);	
		spawnPointScreen.GetComponent<spwanFish>().spwanspeed=1.0f;
	}
	public void EasyLevel()
	{
		Hard.SetActive(false);
		Medium.SetActive(false);
		Easy.SetActive(false);
		spawnPointScreen.GetComponent<spwanFish>().spwanspeed=1.50f;
	}

	// Update is called once per frame
	void Update () {
		
	}
}
