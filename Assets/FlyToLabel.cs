using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyToLabel : MonoBehaviour {


	public GameObject meterDiamond;
	public GameObject bluestarBoard;
	public GameObject GreenStarBoard;
	public GameObject GoldStarBoard;
	public Vector3 mypos;
	public Vector3 dest;
	public float speed=2.5f;

	void Awake()
	{

		meterDiamond = GameObject.Find("ScoreBoard").gameObject;
		bluestarBoard = GameObject.Find("ScoreBoardBlue").gameObject;
		GoldStarBoard = GameObject.Find("ScoreBoardGold").gameObject;
		GreenStarBoard = GameObject.Find("ScoreBoardGreen").gameObject;

		 mypos = this.transform.position;
		dest = meterDiamond.transform.position;



	}

	void Update () {
		
		if(this.gameObject.tag.Equals("Blue"))
		{
			dest = bluestarBoard.transform.position;
		}
		else if(this.gameObject.tag.Equals("Gold"))
		{
			dest = GoldStarBoard.transform.position;

		}
		else if(this.gameObject.tag.Equals("Green"))
		{
			dest = GreenStarBoard.transform.position;

		}
		else
		{
			dest = meterDiamond.transform.position;
		}

		transform.position = Vector3.Lerp(transform.position,dest, speed * Time.deltaTime);
		//transform.localScale = Vector3.Lerp(transform.localScale,transform.localScale.Set(0,0,0),0);
		if(transform.position==dest)
		{
			this.transform.localScale = new Vector3 (0,0,0);
		}

	}
}

