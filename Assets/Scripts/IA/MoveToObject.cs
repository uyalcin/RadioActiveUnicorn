using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToObject : MonoBehaviour {

    public GameObject target;

    public float speed; // default 8
    public float slow; // default 40
    public float jump; // default 5

    Rigidbody2D rb;
    TriggerInterface trigger;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        trigger = GetComponent<TriggerInterface>();
    }

    void FixedUpdate()
    {
        if (trigger.isActive())
        {
            //
            // Move right and left
            //
            float moveHorizontal = target.transform.position.x > transform.position.x ? 1f : -1f;
            rb.AddForce(new Vector2(moveHorizontal * speed, 0f), ForceMode2D.Impulse);
            rb.AddForce(-new Vector2(rb.velocity.x, 0) * slow);
            
            //
            // Jump
            //
            float moveVertical = !isPlateformAhead(moveHorizontal) ? 1f : 0f;

            if (rb.velocity.y == 0f) // If the character is on the ground
            {
                rb.AddForce(new Vector2(0f, moveVertical) * jump, ForceMode2D.Impulse);
            }
        }
    }

    bool isPlateformAhead(float direction)
    {
        float angle = -Mathf.PI / 2f + direction * Mathf.PI / 5f;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)), 10f, 1 << LayerMask.NameToLayer("Plateform"));

        return (hit.collider != null);
    }
}
