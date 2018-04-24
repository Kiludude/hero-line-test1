using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

	private Transform hpFill;

	private float health = 100f;
	float hpFillMaxScaleX;

	// Use this for initialization
	void Start () {
		hpFill = this.gameObject.transform.GetChild(1);
		hpFillMaxScaleX = hpFill.transform.localScale.x;
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void applyDamage(float damage) {
		UpdateHp (-damage);
	}

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
