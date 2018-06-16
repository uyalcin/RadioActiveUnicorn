using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioactiveUnicornBehaviour : MonoBehaviour {
	void Update () {
		if(GetComponentInChildren<RadioactivityZone>().getZoneRadius() <= 0.2f)
        {
            Destroy(gameObject);
        }
	}
}
