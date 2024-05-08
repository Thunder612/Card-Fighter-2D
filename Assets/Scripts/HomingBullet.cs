using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HomingBullet : MonoBehaviour
{
    public Transform target;
    private Rigidbody2D rb;
    public float speed = 5f;
    public float rotateSpeed = 200;
    private Collider2D proj;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        proj = gameObject.GetComponent<Collider2D>();
        Destroy(gameObject, 15f); //Destroy the bullet automagically after 15 seconds
    }

    // Update is called once per frame
    private void Update()
    {
        Collider2D[] cols = Physics2D.OverlapBoxAll(proj.bounds.center, proj.bounds.extents, 0, LayerMask.GetMask("Projectile"));
        foreach (Collider2D col in cols)
        {
            Debug.Log(col.name + " takes a damage!");
            col.GetComponentInParent<PlayerController>().takeDamage(1);
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        Vector2 direction = (Vector2)target.position - rb.position;

        direction.Normalize();

        float rotateAmount = Vector3.Cross(direction, transform.up).z;

        rb.angularVelocity = -rotateAmount * rotateSpeed;


        rb.velocity = transform.up * speed;


    }
}
