using UnityEngine;
using System.Collections;

public class CriadorDeInimigos : MonoBehaviour {
	
	public GameObject inimigo;
	public float inimigoCoolDown;
	// Use this for initialization
	void Start () {
		CriaInimigo();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void CriaInimigo() {
		Instantiate (inimigo, this.transform.position, this.transform.rotation);
		Invoke ("CriaInimigo", inimigoCoolDown*Random.value+0.5f);
	}
}
