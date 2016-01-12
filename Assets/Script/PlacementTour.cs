using UnityEngine;
using System.Collections;

public class PlacementTour : MonoBehaviour {

	// Use this for initialization
	public Texture2D textureBase, textureOn, textureError;
	public Tower turret;
	private Tower CurrentTurret ;
	private bool hasTower = false;


	void OnMouseOver()
	{
		if (GameManager.argent >= turret.Valeur ()) {
			if (!hasTower) {
				this.GetComponent<Renderer> ().material.mainTexture = textureOn;
			} else {
				this.GetComponent<Renderer> ().material.mainTexture = textureError;
			}
		} else {
			this.GetComponent<Renderer> ().material.mainTexture = textureError;
		}

	}
	void OnMouseExit()
	{
		this.GetComponent<Renderer>().material.mainTexture = textureBase;
	}

	
	// Update is called once per frame
	void OnMouseUp()
	{

		if (!hasTower) {

			if (GameManager.argent >= turret.Valeur()) {
				//Vector3 vect = new Vector3 (transform.position.x, transform.position.y + 0.5f, transform.position.z);

				CurrentTurret = (Tower)Instantiate (turret, transform.position, Quaternion.identity);
				CurrentTurret.name = "Turret";
				CurrentTurret.transform.parent = gameObject.transform;
				GameManager.argent -= turret.Valeur();
				hasTower = true;

			}
			else{
				this.GetComponent<Renderer>().material.mainTexture = textureError;
			}

		}
		else {
			Destroy(transform.FindChild("Turret").gameObject);
			GameManager.argent+= CurrentTurret.Valeur()/2;
			hasTower = false;
		}

	}
}
