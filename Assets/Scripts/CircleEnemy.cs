using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleEnemy : MonoBehaviour
{
    public Collider2D enemyCollider;
    public float health;
    public GameObject winScreen;
    public Timer timer;
    private float lastTime = 0f;
    private float lastTeleTime = 0f;
    public Transform bulletSpawn;

    public Transform TelePoint1;
    public Transform TelePoint2;
    public Transform TelePoint3;
    public Transform TelePoint4;
    private int lastTelePoint = 1;

    public GameObject circleArray1;
    public GameObject circleArray2;
    public GameObject circleArray3;
    public GameObject circleArray4;


    public AudioClip newSong;
    public AudioManager audioManager;


    [SerializeField] private GameObject bullet;

    private GameObject bulletInst;
    private float bulletRot = 0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void spawn(float startingHealth)
    {
        health = startingHealth;
        circleArray1.SetActive(true);
        TelePoint1.gameObject.SetActive(true);
        TelePoint2.gameObject.SetActive(true);
        TelePoint3.gameObject.SetActive(true);
        TelePoint4.gameObject.SetActive(true);
        audioManager.ChangeMusic(newSong);
    }

    public void takeDamage(int amount)
    {
        Debug.Log("Taking " + amount + " damage");
        health -= amount;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Die();
        }
        /*
        if (timer.timer > lastTime + .7)
        {
            lastTime = timer.timer;
            fireBullet();
        }
        */



        if (timer.timer > lastTeleTime + 8)
        {

            lastTeleTime = timer.timer;
            Teleport();
            
        }

        if (timer.timer > lastTeleTime + 6)
        {
            disableArrays();
        }

    }

    private void disableArrays()
    {
        circleArray1.SetActive(false);
        circleArray2.SetActive(false);
        circleArray3.SetActive(false);
        circleArray4.SetActive(false);
    }

    private void Teleport()
    {
        if (lastTelePoint == 1)
        {
            circleArray2.SetActive(true);
            gameObject.transform.position = TelePoint2.position;
            lastTelePoint = 2;

        } else if (lastTelePoint == 2)
        {
            circleArray3.SetActive(true);
            gameObject.transform.position = TelePoint3.position;
            lastTelePoint = 3;
        } else if (lastTelePoint == 3)
        {
            circleArray4.SetActive(true);
            gameObject.transform.position = TelePoint4.position;
            lastTelePoint = 4;
        } else
        {
            circleArray1.SetActive(true);
            gameObject.transform.position = TelePoint1.position;
            lastTelePoint = 1;
        }
    }

    private void fireBullet()
    {

        //Spawn bullet
        bulletInst = Instantiate(bullet, bulletSpawn.position, Quaternion.Euler(0f, 0f, bulletRot));
        bulletRot += 134f;
    }

    void Die()
    {
        disableArrays();
        TelePoint1.gameObject.SetActive(false);
        TelePoint2.gameObject.SetActive(false);
        TelePoint3.gameObject.SetActive(false);
        TelePoint4.gameObject.SetActive(false);
        health = 1;
        gameObject.SetActive(false);
        GameObject.Find("GameController").GetComponent<GameController>().WinScreen();

    }
}
