using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreepCatScript : MonoBehaviour {

	private Rigidbody2D rb;
	private Transform hpFill;
    private GameObject downCollision;
    private GameObject fightIcon;
    public LayerMask enemyLayerMask;

    float hpFillMaxScaleX;

	private bool isFighting = false;
	private float health = 100f;

    private void Awake()
    {
        downCollision = this.transform.Find("DownCollision").gameObject;
        fightIcon = this.transform.Find("FightIcon").gameObject;
    }

    // Use this for initialization
    void Start () {
		// Get components
		rb = GetComponent<Rigidbody2D>();
		hpFill = this.gameObject.transform.GetChild(1);

		// 
		hpFillMaxScaleX = hpFill.transform.localScale.x;

		//InvokeRepeating("ff", 2.0f, 2f);
	}
	
	// Update is called once per frame
	void Update ()
    {
        Movement();
        CheckForEnemy();
        Fight();
        //
        //health--;
        //UpdateHpBar ();
    }
    void Fight()
    {
        if (!isFighting)
        {
            return;
        }
        ff();


    }

    void CheckForEnemy()
    {
        RaycastHit2D hit = Physics2D.Raycast(downCollision.transform.position, Vector2.down, 0.1f, enemyLayerMask);
        if (hit.collider != null)
        {
            isFighting = true;
            print("isFighting");
            fightIcon.SetActive(true);
        }
        else
        {
            isFighting = false;
            fightIcon.SetActive(false);
        }
    }

	void Movement() {
		if (!isFighting) {
            //rb.transform.Translate(Vector3.down * Time.deltaTime);
            Vector2 newPosition = rb.transform.position;
            newPosition.y -= 0.01f; 
            rb.transform.position = newPosition;
        }
	}

	void ff() {
		UpdateHp (-1f);
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
