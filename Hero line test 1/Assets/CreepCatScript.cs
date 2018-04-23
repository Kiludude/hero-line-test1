using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreepCatScript : MonoBehaviour {

	private Rigidbody2D rb;
	private Transform hpFill;
	float hpFillMaxScaleX;

	private bool isFighting = false;
	private float health = 100f;

	// Use this for initialization
	void Start () {
		// Get components
		rb = GetComponent<Rigidbody2D>();
		hpFill = this.gameObject.transform.GetChild(1);

		// 
		hpFillMaxScaleX = hpFill.transform.localScale.x;

		InvokeRepeating("ff", 2.0f, 2f);
	}
	
	// Update is called once per frame
	void Update () {
		//Movement ();
		//
		//health--;
		//UpdateHpBar ();
	}

	void Movement() {
		if (!isFighting) {
			rb.transform.Translate(Vector3.down * Time.deltaTime);
		}
	}

	void ff() {
		UpdateHp (-10f);
	}
	/*void UpdateHpBar() {
		print ("scale" + hpBg.transform.localScale.x);
		float scaleX = hpBg.transform.localScale.x - 0.0000001f;
		print ("scaleX" + scaleX);
		hpBg.transform.localScale += new Vector3(scaleX, 0, 0);
	}*/

	void UpdateHp(float modifier) {

		print ("health " + health);
		health += modifier;
		print ("health " + health);

		// Check if dead
		if (health <= 0) {
			Death ();
		}

		float relativeFactor = health / 100;
		float newHpFillScaleX = hpFillMaxScaleX * relativeFactor;
		print ("newHpFillScaleX " + newHpFillScaleX); 

		/*print ("scale " + hpFill.transform.localScale.x);
		float scaleX = (hpFill.transform.localScale.x - 0.05f);
		print ("scaleX " + scaleX);*/
		hpFill.transform.localScale = new Vector3(newHpFillScaleX, hpFill.transform.localScale.y);
	}

	void Death() {
		gameObject.SetActive (false);
		print ("Dead!!");
	}
}
