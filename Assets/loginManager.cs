using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loginManager : MonoBehaviour {

	public InputField username;
	public InputField password;
	public GameObject startScreen;
	public GameObject ExitScreen;

	// Use this for initialization
	void Start () {
		
	}


	public void Onloginbtn()
	{
		if(username.text.Equals("User1") && password.text.Equals("123"))
		{
			username.text="";
			password.text="";
			startScreen.SetActive(true);
			this.gameObject.SetActive(false);
		}
		else
		{
			startScreen.SetActive(true);
			this.gameObject.SetActive(false);
		}
	}

	public void OnlogoutBtn()
	{
		startScreen.SetActive(false);
		this.gameObject.SetActive(true);
	}

	public void onMainMenu()
	{
		ExitScreen.SetActive(false);
		startScreen.SetActive(true);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
