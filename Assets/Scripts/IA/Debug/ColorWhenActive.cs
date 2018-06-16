using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorWhenActive : MonoBehaviour {

	void Update () {
		if(GetComponent<TriggerInterface>().isActive())
        {
            gameObject.GetComponent<Renderer>().material.color = Color.green;
        } else
        {
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
	}
}
