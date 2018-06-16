using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioactiveWormBehaviour : MonoBehaviour {
    void Update()
    {
        float state = transform.GetComponentInChildren<ComingFromGround>().getState();
        transform.GetChild(0).transform.localScale = new Vector2(1, 1) * state;

        if (GetComponentInChildren<RadioactivityZone>().getZoneRadius() <= 0.2f)
        {
            Destroy(gameObject);
        }
    }
}
