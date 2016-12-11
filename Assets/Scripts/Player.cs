using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public Animator anim;

	public bool carregando;
	public float tempoCarregando;
	public Projetil projetil;
	public Transform cajado;

	public int life = 100;

	public int projeteisPorSegundo = 5;

	// Use this for initialization
	void Start () {
	
	}

	public void atirar(){
		int n = Mathf.RoundToInt (tempoCarregando) * projeteisPorSegundo;

		if (n == 0)
			n = 1;
		
		for (int i = 0; i < n; i++) {
			var rand = Random.insideUnitCircle * 1f;
			Projetil proj = (Projetil)Instantiate (projetil, cajado.position + (Vector3)rand, Quaternion.Euler(0,0,90));
			if (this.transform.eulerAngles.y == 0) {
				proj.ladoDireito = false;
			} else {
				proj.ladoDireito = true;
			}
		}
		tempoCarregando = 0f;
	}


	// Update is called once per frame
	void Update () {
	
		if (carregando) {
			tempoCarregando += Time.deltaTime;
		}

		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			this.transform.eulerAngles = new Vector3 (0, 0, 0);
		}
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			this.transform.eulerAngles = new Vector3 (0, 180, 0);
		}


		if (Input.GetKeyDown (KeyCode.LeftArrow) || Input.GetKeyDown (KeyCode.RightArrow)) {
			anim.SetBool ("Carregando", true);
			carregando = true;
		}

		if (Input.GetKeyUp (KeyCode.LeftArrow) || Input.GetKeyUp (KeyCode.RightArrow)) {
			anim.SetBool ("Carregando", false);
			carregando = false;
			//atirar

		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.CompareTag ("Inimigo")) {
			life -= 5;
			if (life <= 0) {
				//String :P
				anim.SetBool ("Morreu", true);
			}
			anim.SetTrigger ("Dano");
		}
	}
}
