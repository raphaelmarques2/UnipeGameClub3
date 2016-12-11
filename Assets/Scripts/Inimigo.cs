using UnityEngine;
using System.Collections;

public class Inimigo : MonoBehaviour {

	Rigidbody2D rb;
	public float speed;
	public int life;

	public GameObject explosion;

	Animator anim;
	Player player;
	public float playerDistance = 2f;

	void Start(){
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		player = GameObject.FindObjectOfType<Player> ();
	}

	void FixedUpdate(){
		rb.velocity = -this.transform.right * speed;
	}

	void Update(){
		if (Vector3.Distance (player.transform.position, this.transform.position) < playerDistance) {
			anim.SetTrigger ("Near");
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.CompareTag ("Player")) {
			Destruir ();
		}
		if(col.gameObject.CompareTag("Projetil")){
			life-=5;
			if (life <= 0) {
				Destruir ();
			}
		}
	}

	void Destruir(){
		GameObject newExplosion = (GameObject)Instantiate (explosion, this.transform.position, Quaternion.identity);
		Destroy (newExplosion, 2f);
		Destroy (this.gameObject);
	}

}
