using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

	// Use this for initialization
	public GameObject mob;
	public float intervalle = 1;
	void Start () {
		InvokeRepeating ("SpawnMob", intervalle,intervalle);
	}
	
	// Update is called once per frame
	void SpawnMob()
	{
		Instantiate (mob, transform.position, Quaternion.identity);
	}
}
