using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishMovement : MonoBehaviour {

	private const float SPEED = 25f;

	private int[] spawns = new int[2];


	//private const float smooth = 
	private Vector3 direction;
	void Start()



	{
	
		spawns[0]=1;
		spawns[1]=-1;
		//Debug.Log(this.transform.parent.ToString());
		var trf = this.transform.parent.name.	ToString();
		Debug.Log(trf.ToString());
		if(trf.Equals("Spawn1"))
		{
			direction = new Vector3(Random.Range(0.0f, 1.0f),  Random.Range(-0.5f,0),0.0f).normalized;
			//direction = new Vector3(-1f, 1f,0f);
			Debug.Log((direction.x+","+direction.y).ToString());
			Debug.Log("spawan1 got it");



		}
		else if(trf.Equals("Spawn2"))
		{
			direction = new Vector3(Random.Range(-0.50f, 0.0f),  Random.Range(-0.50f, 0.50f),0.0f).normalized;
			//direction = new Vector3(-1f, 1f,0f);
			Debug.Log((direction.x+","+direction.y).ToString());

		}
		else if(trf.Equals("Spawn3"))
		{
			direction = new Vector3(Random.Range(-0.50f, 0.50f),  Random.Range(0.0f, 1.0f),0.0f).normalized;
			//direction = new Vector3(-1f, 1f,0f);
			Debug.Log((direction.x+","+direction.y).ToString());

		}

		else if(trf.Equals("Spawn4"))
		{
			direction = new Vector3(Random.Range(-0.50f, 0.50f),  Random.Range(-1.0f, 0.0f),0.0f).normalized;
			//direction = new Vector3(-1f, 1f,0f);
			Debug.Log((direction.x+","+direction.y).ToString());

		}
		else if(trf.Equals("Spawn5"))
		{
			direction = new Vector3(Random.Range(-0.50f, 0.0f),  Random.Range(0.0f, 0.50f),0.0f).normalized;
			//direction = new Vector3(-1f, 1f,0f);
			Debug.Log((direction.x+","+direction.y).ToString());

		}
		else if(trf.Equals("Spawn6"))
		{
			direction = new Vector3(Random.Range(0.0f, 0.50f),  Random.Range(-0.50f, 0.0f),0.0f).normalized;
			//direction = new Vector3(-1f, 1f,0f);
			Debug.Log((direction.x+","+direction.y).ToString());

		}
		else 
		{
			direction = new Vector3(Random.Range(-1.0f, 1.0f),  Random.Range(-1.0f, 1.0f),0.0f).normalized;
			//direction = new Vector3(-1f, 1f,0f);
			Debug.Log((direction.x+","+direction.y).ToString());

		}





	

		if(direction.x<0 && direction.y<0 )
		{
			this.gameObject.GetComponent<RectTransform>().rotation= Quaternion.Euler (0,180,-45);
		}
		else if(direction.x<0 && direction.y>0)
		{
			this.gameObject.GetComponent<RectTransform>().rotation= Quaternion.Euler (0,180,45);
		}
		else if(direction.x>0 && direction.y>0)
		{
			this.gameObject.GetComponent<RectTransform>().rotation= Quaternion.Euler (0,0,45);
		}
		else if(direction.x>0 && direction.y<0)
		{
			this.gameObject.GetComponent<RectTransform>().rotation= Quaternion.Euler (0,0,320);
		}


	}

	void Update()
	{
		transform.position +=(-direction) * SPEED * Time.deltaTime;
	}
}
