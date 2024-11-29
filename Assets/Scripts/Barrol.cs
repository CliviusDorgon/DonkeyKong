using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrol : MonoBehaviour
{
    /*private new Rigidbody2D rigidbody;
    private Collider2D colliders;
    public float speed = 1f;
    public float fallSpeed = 5f; // Snelheid van de valbeweging
    private bool shouldFall = false;
    private float fallSpeedShouldfall = 4f;
    private bool hasCollided = false; // Vlag om bij te houden of de actie al is uitgevoerd

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        colliders = GetComponent<Collider2D>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            rigidbody.AddForce(collision.transform.right * speed, ForceMode2D.Impulse);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("fallORnot"))
        {
            int randomValue = Random.Range(0, 2); // Geeft 0 of 1 terug
            if(randomValue == 1)
            {
                shouldFall = true;
            }
            else if(randomValue == 0)
            {
                colliders.isTrigger = false;
                shouldFall = false;
            }
            
            if(shouldFall == true)
            {
                colliders.isTrigger = true; // Schakel collider over naar trigger-modus om door objecten te gaan
            }
        }
        // Controleer of de barrol de grond raakt terwijl het in valmodus is
        if (shouldFall && other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            shouldFall = false;
            rigidbody.constraints = RigidbodyConstraints2D.None;
            colliders.isTrigger = false; // Zet trigger-modus uit voor normale botsingen
            rigidbody.velocity = Vector2.zero; // Stop de barrol
        }
    }

    private void FixedUpdate()
    {
        if (shouldFall)
        {
            // Pas een constante valkracht toe aan de Rigidbody
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, -fallSpeedShouldfall);
            rigidbody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        }
    }*/

    private new Rigidbody2D rigidbody;
    private Collider2D colliders;
    public float speed = 1f;
    public float fallSpeed = 5f; // Snelheid van de valbeweging
    private bool shouldFall = false;
    private float fallSpeedShouldfall = 4f;
    private bool hasCollided = false; // Vlag om bij te houden of de actie al is uitgevoerd

    public float groundCheckDistance = 0.1f;
    bool isFalling;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        colliders = GetComponent<Collider2D>();
    }
    private void FixedUpdate()
    {
        if (shouldFall)
        {
            // Pas een constante valkracht toe aan de Rigidbody
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, -fallSpeedShouldfall);
            rigidbody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("fallORnot"))
        {
            int randomValue = Random.Range(0, 2); // Geeft 0 of 1 terug
            if (randomValue == 1)
            {
                shouldFall = true;
            }
            else if (randomValue == 0)
            {
                shouldFall = false;
            }
        }
    }
    private void Update()
    {

        RaycastHit hit;
        if (Physics.Raycast(transform.position, -Vector2.up, out hit, groundCheckDistance, LayerMask.NameToLayer("Ground")) && isFalling)
        {

            rigidbody.constraints = RigidbodyConstraints2D.None;
            rigidbody.velocity = Vector2.zero; // Stop de barrol
            rigidbody.AddForce(hit.transform.right * speed);
            isFalling = false;
        }
        else
        {
            isFalling = true;
        }
    }
}