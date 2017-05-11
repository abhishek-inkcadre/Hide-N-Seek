using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class splash : MonoBehaviour {


		void Awake ()
		{
			StartCoroutine ("PlayMovie");
		}
		public IEnumerator PlayMovie ()
		{
		Debug.Log("Playing Video");

		#if UNITY_ANDROID
		Handheld.PlayFullScreenMovie("WSE.mp4", Color.black, FullScreenMovieControlMode.Hidden);
		#endif
		 
			yield return new WaitForSeconds (0.1f);
			Application.LoadLevel ("Demo");
		}

}
