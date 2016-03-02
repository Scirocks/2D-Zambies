using UnityEngine;
using System.Collections;

public class Zombie : MonoBehaviour {
	public float time = 2;
	public static float Timer;
	public Transform target;
	public float speed = 3f;
	public GameObject Attack;
	player playerScript;
	public float StartingHealth;
	float CurrentHealth;
	public GameObject pause;
	public GameObject pause2;
	bool nopause;
	// Use this for initialization
	void Start () {
		playerScript = Attack.GetComponent <player>();
		Timer = time;
		CurrentHealth = StartingHealth;

	}
	
	// Update is called once per frame
	void Update () {
		Vector3 movement = Vector3.zero;

		if (pause.activeSelf || pause2.activeSelf) {
			nopause = false;
		} else {
			nopause = true;
		}
		if (Timer <= 0) {
			//Timer = time;
			//playerScript.CurrentHealth -= 1;
		} else {
			Timer -= Time.deltaTime;
		}
		if (target.transform.position.x != transform.position.x && nopause) {
			if(target.transform.position.x - transform.position.x < 0)
				movement.x = -speed*Time.deltaTime;
			else
				movement.x = speed*Time.deltaTime;
			if(Mathf.Abs(target.transform.position.x - transform.position.x) < movement.x && nopause){
				movement.x = target.transform.position.x - transform.position.x;
			}
		}
		if (target.transform.position.y != transform.position.y && nopause) {
			if(target.transform.position.y - transform.position.y < 0)
				movement.y = -speed*Time.deltaTime;
			else
				movement.y = speed*Time.deltaTime;
			if(Mathf.Abs(target.transform.position.y - transform.position.y) < movement.y && nopause){
				movement.y = target.transform.position.y - transform.position.y;
			}
		}
		transform.Translate (movement);
	}
	void OnTriggerStay2D (Collider2D coll){
		Debug.Log("Log");
		if (Timer <= 0) {
			Timer = time;
			playerScript.CurrentHealth -= 1;
		}

	}


}
