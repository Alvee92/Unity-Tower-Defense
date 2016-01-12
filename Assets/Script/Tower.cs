using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour {

	private GameObject mob;
	public GameObject bullet;
	public GameObject gun;
	private int power = 1000;
	public AudioClip sound;
	public int value = 50;
	private bool CanAttack = false;

	public float AttackRepeatTime = 2;	//Delay between two attacks
	private float attackTime; //the time when attacking

	void Start()
	{
		attackTime = Time.time;
	}
	// Use this for initialization
	void OnTriggerEnter(Collider col)
	{
		if (mob == null) {
			if (col.tag == "Ennemy") {
				mob = col.gameObject;
			}
		}
	}
	void OnTriggerExit(Collider col)
	{
		if (col.gameObject == mob) {
			mob = null;
		}
	}
	void OnTriggerStay(Collider col)
	{
		if (mob == null) {
			if (col.tag == "Ennemy") {
				mob = col.gameObject;
			}
		}
	}
	void Update()
	{

		if (mob != null) 
		{
			transform.FindChild("Head").transform.LookAt(mob.transform.position);
			if(Time.time > attackTime){
				Fire ();
				attackTime = Time.time + AttackRepeatTime;
			}
		}
	}


	void Fire()
	{
		GameObject balle = (GameObject)Instantiate (bullet, gun.transform.position,  Quaternion.Euler (90,gun.transform.parent.eulerAngles.y,0));

		//GetComponent<AudioSource>().PlayOneShot(sound);
		balle.name = "bullet";
		balle.GetComponent<Rigidbody> ().AddForce (gun.transform.forward * power);
		Destroy (balle, 1);
	}

	public int Valeur()
	{
		return this.value;
	}
}
