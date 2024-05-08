using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BombBehavior : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    private float startTime;
    private Timer timer;
    private AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.FindObjectOfType<AudioManager>();
        timer = GameObject.Find("Timer").GetComponent<Timer>();
        startTime = timer.timer;
        Destroy(gameObject, 5f); //Destroy the bullet automagically after 3 seconds
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.timer > startTime + 3)
        {
            audioManager.PopSFX();
            Instantiate(bullet, gameObject.transform.position, Quaternion.Euler(0f, 0f, 0));
            startTime = 1000;

        }
    }

}
