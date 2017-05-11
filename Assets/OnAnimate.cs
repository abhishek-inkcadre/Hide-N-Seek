using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnAnimate : MonoBehaviour {

	// Use this for initialization
	void OnEnable () {

		this.gameObject.GetComponent<Animation>().Play();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
