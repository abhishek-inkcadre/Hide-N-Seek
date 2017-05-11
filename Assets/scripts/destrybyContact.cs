using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destrybyContact : MonoBehaviour {

	// Use this for initialization



			void OnTriggerEnter2D(Collider2D other) 
			{
			if (other.gameObject.tag == "Fish" || other.gameObject.tag == "Enemy" ||other.gameObject.tag == "SeaHorse" || other.gameObject.tag == "StarFish")
				{ 
					Destroy(other.gameObject);
					
					Debug.Log("destroyed");
					
			if(other.gameObject.tag!="Enemy")
			{
				User.FishCount = User.FishCount+1;
				if(User.FishCount==3)
				{
					Debug.Log(" before fish "+ User.FishCount);

					User.FishCount=0;
					Debug.Log("fish "+ User.FishCount);
				
					if(User.PlayerHealth>0)
					{
					//Destroy(this.gameObject); 
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
				
			}	
		
	}
}

