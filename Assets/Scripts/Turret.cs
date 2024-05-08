using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private GameObject player;
    public Timer timer;
    private float lastTime = 0f;
    private GameObject bulletInst;
    [SerializeField] private GameObject bullet;
    float rot;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.transform.position - transform.position;
        rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        gameObject.transform.rotation = Quaternion.Euler(0, 0, rot);

        if (timer.timer > lastTime + 1.3)
        {
            lastTime = timer.timer;
            fireBullet();
        }
    }

    private void fireBullet()
    {

        //Spawn bullet
        bulletInst = Instantiate(bullet, transform.position, Quaternion.Euler(0f, 0f, rot + 90f));
    }
}
