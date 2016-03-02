using UnityEngine;
using System.Collections;

public class UIController : MonoBehaviour {
	public void ChangeScene(string SceneName){

		Application.LoadLevel (SceneName);

	}

	public void Quit (){

		Application.Quit();

	}


}
