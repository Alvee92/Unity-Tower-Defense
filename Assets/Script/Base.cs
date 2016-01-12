using UnityEngine;
using System.Collections;

public class Base : MonoBehaviour {

	// Use this for initialization
	public Texture2D textureError,textureBase;

	void OnMouseOver()
	{
		this.GetComponent<Renderer> ().material.mainTexture = textureError;
	}
	void OnMouseExit()
	{
		this.GetComponent<Renderer> ().material.mainTexture = textureBase;
	}
}
