using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onclickKey : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
		void OnMouseDown()
		{
		this.gameObject.GetComponent<Animator>().enabled=true;
		}
		

	
	// Update is called once per frame
	void Update () {
		
	}
}
