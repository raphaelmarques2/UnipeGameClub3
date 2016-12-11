using UnityEngine;
using System.Collections;

public class Atirar : MonoBehaviour {

	public void atirar(){
		this.GetComponentInParent<Player> ().atirar ();
	}

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}