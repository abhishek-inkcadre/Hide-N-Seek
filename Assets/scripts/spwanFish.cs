	using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spwanFish : MonoBehaviour {

	// Use this for initialization

	public GameObject[] SpwanPoint;
	public GameObject[] FishPref;
	public Transform parent;
	public float spwanspeed =1;

	
	void OnEnable () 
	{

		StartCoroutine(spawnFishRandom());
		//InvokeRepeating("spawFishRandom",0,Random.Range(2,3));

	}
	

	public IEnumerator spawnFishRandom()
	{
		while(true)
		{
			var temp = SpwanPoint[Random.Range(0,6)];
			GameObject fish = (GameObject)Instantiate(FishPref[Random.Range(0,8)],temp.transform.position,Quaternion.identity,temp.transform);
			fish.transform.localPosition = new Vector3 (transform.position.x,transform.position.y,0);
			
			yield return new WaitForSeconds(spwanspeed);
		}



	}
}
