using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    private Rigidbody2D rb;
    public Collider2D proj;
    [SerializeField] private float normalBulletSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        SetStraightVelocity();

        Destroy(gameObject, 30f); //Destroy the bullet automagically after 15 seconds
    }

    private void SetStraightVelocity()
    {
        rb.velocity = transform.up * normalBulletSpeed;
    }

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
}
