using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	public static int vie=2;
	public static int argent = 100;
	public Text textevie, texteargent;
	public GameObject particules;
	public AudioClip son;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		texteargent.text = "Argent :" + argent;
		if (vie == 5) 
		{
			textevie.text = "-----";
		}
		else if (vie == 4) 
		{
			textevie.text = "----";
		}
		else if (vie == 3) 
		{
			textevie.text = "---";
		}
		else if (vie == 2) 
		{
			textevie.text = "--";
		}
		else if (vie == 1) 
		{
			textevie.text = "-";
		}
		else { 
			textevie.text = "";
			Instantiate(particules, GameObject.Find("Home").transform.position, Quaternion.identity);
			GetComponent<AudioSource>().PlayOneShot(son);
			Destroy(GameObject.Find("Home"));

		}

	}
}
