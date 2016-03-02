using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {
	public int Damage, FireRate, Ammo, ReloadTime;
	public string EquipedWeapon;
	float CurrentLives;
	public float StartingLives = 3;
	public float StartingHealth = 5;
	public float CurrentHealth;
	Vector3 movement;
	public float speed = 10;
	float movementspeed;
	public GameObject pauseMenu;
	public float y = 0.1399998f;
	public float x = -3.39f;
	public GameObject GameOver;
	public GameObject Shop;
	bool paused = false;
	// Use this for initialization
	void Start () {
		CurrentLives = StartingLives;
		CurrentHealth = StartingHealth;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.E)) {
			Shop.SetActive (true);
			paused = true;
		}
		if (CurrentLives <= 0) {
			GameOver.SetActive(true);
			paused = true;
		}
		if (Input.GetKeyDown (KeyCode.H)) {
			CurrentHealth -= 1;
		
		}
		if (CurrentHealth <= 0) {
			Respawn();
			CurrentHealth = StartingHealth;
			CurrentLives -= 1;
		}
		if (Input.GetKeyDown (KeyCode.Escape)) {
			pauseMenu.SetActive (true);
			paused = true;
		}
		if (Input.GetKey (KeyCode.LeftShift)) {
			movementspeed = speed * 2;
		} else {
			movementspeed = speed;
		}
		movement = Vector3.zero;
		if (paused == false){
		movement.x += Input.GetAxis("Horizontal") * Time.deltaTime * movementspeed;
		movement.y += Input.GetAxis ("Vertical") * Time.deltaTime * movementspeed;
		}
	}	
	void FixedUpdate(){
		transform.position = transform.position + movement;


	}

	void LateUpdate(){
		transform.rotation = Quaternion.identity;
	}
	public void UnPause() {
		pauseMenu.SetActive (false);
		paused = false;
	}
	public void Respawn(){
		transform.position = new Vector3 (x, y, transform.position.z);


	}
	public void ChangeWeapon(string weapon){
		if (weapon != EquipedWeapon) {
			weapon = EquipedWeapon;
		}
	}



}
