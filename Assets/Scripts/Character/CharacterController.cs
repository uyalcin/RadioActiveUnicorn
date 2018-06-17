using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

	//
	// Character movement
	//
	public float speed = 11;
	public float criticSpeed = 5;
	public float slow = 40; // default 40
	public float jump = 15; // default 5
	public float maxJump = 30;
	public float maxJumpCost;
	public bool isGrounded = false;

	//
	// Radioactivity gesture
	//
	public float radioactivity = 0f;
	private bool criticalState = false;
	private bool isInRadioActivityZone = false;
	private float radioActivityRate;
	private float intervalRadioActivity = 0f;

	public List<int> paliers = new List<int>();

	//
	// Purity Gesture
	//
	public float purity = 0f;
	private float timeTreat;
	public float treatGain = 0f;

	//
	// Animation
	//
	private Rigidbody2D rb;
	private Animator anim;

	//
	// Vacum Gesture
	//
	public GameObject vacuum;
	public GameObject posLeftVacuum;
	public GameObject posRightVacuum;
	public GameObject pLeft;
	public GameObject pRight;

	//
	// Canon Gestion
	//
	public float canonCost;
	public GameObject canonZone;
	public GameObject posLeftCanon;
	public GameObject posRightCanon;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator> ();
		pLeft.SetActive (false);
		pRight.SetActive (false);
	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal") * (1 - Input.GetAxis ("Treat"));
		//
		// Move right and left
		//
		rb.AddForce (new Vector2(moveHorizontal * (criticalState ? criticSpeed : speed), 0f) ,ForceMode2D.Impulse);
		rb.AddForce (- new Vector2(rb.velocity.x, 0) * slow);

		//
		// Jump
		//
		float moveVertical = Input.GetAxis ("Jump");
		float maxMoveVertical = Input.GetAxis ("MaxJump");

		if (isGrounded && rb.velocity.y == 0f) // If the character is on the ground
		{ 
			rb.AddForce (new Vector2(0f, moveVertical) * jump, ForceMode2D.Impulse);

			// If we have enough purity for a max jump cost
			if (purity >= maxJumpCost) {
				if(maxMoveVertical == 1f)
					rb.velocity = new Vector2(rb.velocity.x, 0f);
				rb.AddForce (new Vector2 (0f, maxMoveVertical) * maxJump, ForceMode2D.Impulse);
				if (maxMoveVertical > 0f) {
					purity -= maxJumpCost;
					if (purity <= 0f)
						purity = 0f;
				}
			}
		}

		//
		// Check the sprite radioactivity
		//
		criticalState = radioactivity >= paliers [paliers.Count - 2];
		if (isInRadioActivityZone && Time.time - intervalRadioActivity >= 0.5f) 
		{
			intervalRadioActivity = Time.time;
			winRadioActivity (radioActivityRate);
		}

		// CHange the color with radioactivity
		float colorRate = 1 - radioactivity / paliers [paliers.Count - 1];
		GetComponent<SpriteRenderer> ().color = new Color (colorRate, 1, colorRate, 1f);

		//
		// Gestion of treat
		//
		if (rb.velocity == Vector2.zero && Input.GetAxis ("Treat") > 0f && Time.time - timeTreat >= 0.5f) 
		{
			timeTreat = Time.time;
			if(purity >= treatGain)
				dropRadioActivity (treatGain);
			else
				dropRadioActivity (purity);
			dropPurity (treatGain);
		}

		//
		// Gestion of animation
		//
		if (Input.GetAxis ("Horizontal") < 0f) {
			anim.SetBool ("moving", true);
			anim.SetBool ("lastInputRight", false);
			// Set the vacuum
			vacuum.transform.position = posLeftVacuum.transform.position;
			// Set the canon
			canonZone.transform.position = posLeftCanon.transform.position;
		} 
		else if (Input.GetAxis ("Horizontal") > 0f) {
			anim.SetBool ("moving", true);
			anim.SetBool ("lastInputRight", true);
			// Set the vacuum
			vacuum.transform.position = posRightVacuum.transform.position;
			// Set the canon
			canonZone.transform.position = posRightCanon.transform.position;
		} 
		else {
			anim.SetBool ("moving", false);
		}
		if (Input.GetAxis ("Vacuum") > 0f) {
			anim.SetBool ("isBlowing", true);
			// Gestion of particule
			pLeft.SetActive(!anim.GetBool("lastInputRight"));
			pRight.SetActive(anim.GetBool("lastInputRight"));
		} else {
			anim.SetBool ("isBlowing", false);
			pLeft.SetActive (false);
			pRight.SetActive (false);
		}

		//
		// Gestion of death
		//
		if (radioactivity >= paliers[paliers.Count - 1]) {
			//rb.bodyType = RigidbodyType2D.Static;
			anim.SetBool ("lastInputRight", false);
			anim.SetBool ("moving", false);
			anim.SetBool ("dead", true);
			anim.SetBool ("isBlowing", false);
			GetComponent<SpriteRenderer> ().color = Color.white;
		}

	}

	public float getRadioActivity()
	{
		return radioactivity;
	}

	public void dropRadioActivity(float n)
	{
		radioactivity -= n;
		if (radioactivity <= 0f) {
			radioactivity = 0f;
		}
	}
	public void winRadioActivity(float n)
	{
		radioactivity += n;
		if (radioactivity > paliers[paliers.Count - 1])
		{
			Debug.Log ("dead");
		}
	}
	public void inRadioActivity(float rate)
	{
		isInRadioActivityZone = true;
		radioActivityRate = rate;
	}

	public void winPurity(float n)
	{
		purity += n;
		if (purity >= 100f)
			purity = 100f;
	}

	public void dropPurity(float n)
	{
		purity -= n;
		if (purity <= 0f)
			purity = 0f;
	}

	void OnCollisionStay2D(Collision2D col)
	{
		if (col.transform.tag == "Plateform")
			isGrounded = true;
	}

	void OnCollisionExit2D(Collision2D col)
	{
		if (col.transform.tag == "Plateform")
			isGrounded = false;
	}
}
