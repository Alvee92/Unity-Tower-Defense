using UnityEngine;
using System.Collections;

public class Mob : MonoBehaviour {

	// Use this for initialization
	private NavMeshAgent agent;
	public int vie ;
	public GameObject particules;
	public AudioClip explosion;

	private Transform[] PathFinding;
	void Start () {
		PathFinding = GameObject.Find ("PathFinding").GetComponentsInChildren<Transform> ();
		agent = GetComponent<NavMeshAgent>();
		agent.destination = PathFinding [Random.Range (0, PathFinding.Length)].position;
		Debug.Log (agent.destination);
		//agent.destination = GameObject.Find("Home").transform.position;

	}

	void Update()
	{
		if (transform.position == agent.destination) {
			agent.destination = GameObject.Find("Home").transform.position;
		}
		if (vie <= 0)
		{
			Instantiate (particules, transform.position, Quaternion.identity);	
			GetComponent<AudioSource>().PlayOneShot(explosion);
			Destroy (this.gameObject);
			GameManager.argent += 25;
		}

		
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.name == "Home") {

			GetComponent<AudioSource>().PlayOneShot(explosion);
			GameManager.vie--;
			Instantiate (particules, transform.position, Quaternion.identity);
			Destroy (gameObject);


		} else if (col.gameObject.name == "bullet")
		{
			Destroy(col.gameObject);
			Debug.Log("avant vie " + vie);
			ApplyDammage();
			Debug.Log("après vie " + vie);


		}
	
	}
	void ApplyDammage()
	{
		vie --;
	}
}
