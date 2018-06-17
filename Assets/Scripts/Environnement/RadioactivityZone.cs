using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioactivityZone : MonoBehaviour {

	public float radioActivityPower;
	public GameObject attachedSprite;
	private float radius;

	void OnTriggerStay2D(Collider2D col)
	{
		if (col.tag == "Player") {
			// Accurate radioactivity
			float radius = getZoneRadius();
			Vector2 posRadioActivity = transform.position;
			Vector2 posPlayer = col.transform.position;
			float damage = (radius - Vector2.Distance (posPlayer, posRadioActivity)) * radioActivityPower;
			if (damage <= 0f)
				damage = 0f;

			col.transform.GetComponent<CharacterController> ().inRadioActivity (damage);
		}
	}

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            col.transform.GetComponent<CharacterController>().inRadioActivity(0f);
        }
    }

    public float getZoneRadius()
	{
		return transform.localScale.x / 2f;
	}

	public void decreaseZone(float n)
	{
		if(transform.localScale.x > 0f && transform.localScale.y > 0f)
			transform.localScale = new Vector2 (transform.localScale.x - n, transform.localScale.y - n);
	}

}
