using UnityEngine;
using System.Collections;

public class scroll : MonoBehaviour {


	
	// Update is called once per frame
	void Update () {

		MeshRenderer mr = GetComponent<MeshRenderer> ();

		Material mat = mr.material;
		mat.mainTexture.wrapMode=TextureWrapMode.Repeat;

		Vector2 offset = mat.mainTextureOffset;

		offset.x += Time.deltaTime /10f;

		mat.mainTextureOffset = offset;
	
	}
}
