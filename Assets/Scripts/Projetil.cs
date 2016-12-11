using UnityEngine;
using System.Collections;
using System.Linq;

public class Projetil : MonoBehaviour {

	public Transform target;

	public float speed;

	Rigidbody2D rb;

	public bool ladoDireito;

	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (target != null) {
			Vector3 dir = target.position - this.transform.position;
			float angulo = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
			float angulo2 = Mathf.MoveTowardsAngle (rb.rotation, angulo, 360f * Time.fixedDeltaTime);
			rb.MoveRotation (angulo2);
			rb.velocity = this.transform.right * speed;
		} else {
			GameObject[] inimigos = GameObject.FindGameObjectsWithTag ("Inimigo");	

			inimigos = inimigos.Where (e => {
				if(ladoDireito){
					return e.transform.position.x > 0;
				}else{
					return e.transform.position.x < 0;
				}
			}).ToArray();

			if (inimigos.Length > 0) {
				target = inimigos [Random.Range (0, inimigos.Length)].transform;
			} else {
				Destroy (this.gameObject);
			}
		}
	}
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.CompareTag ("Inimigo")) {
			
				Destroy (this.gameObject);
			}
		}

}
