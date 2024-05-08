using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Enemy tutorialEnemy;
    public DiamondEnemy DiamondEnemy;
    public CircleEnemy CircleEnemy;
    public CapsuleEnemy CapsuleEnemy;
    public SquareEnemy SquareEnemy;
    public HexagonEnemy HexagonEnemy;
    public GameObject HexagonEnemyObject;
    public GameObject SquareEnemyObject;
    public GameObject DiamondEnemyObject;
    public GameObject CircleEnemyObject;
    public GameObject CapsuleEnemyObject;
    public GameObject winScreen;
    public Text card1Name;
    public Text card1Damage;
    public Text card1SwingTime;
    public Text card2Name;
    public Text card2Damage;
    public Text card2SwingTime;
    public Text card3Name;
    public Text card3Damage;
    public Text card3SwingTime;
    public Text removeCardName;
    public PlayerController player;
    private Card cardA;
    private Card cardB;
    private Card cardC;
    private Card cardD;
    public Deck deck;
    private float nextEnemyHealth = 30;
    public Text scoreText;
    public float score = 0;
    public AudioClip newSong;
    public AudioManager audioManager;


    public void WinScreen()
    {
        audioManager.HooraySFX();
        winScreen.SetActive(true);
        int x = Random.Range(5, 11);
        cardA = CardDatabase.cardList[x];
        x = Random.Range(5, 14);
        cardB = CardDatabase.cardList[x];
        x = Random.Range(5, 14);
        cardC = CardDatabase.cardList[x];
        cardD = player.lastUsedCard;
        displayCards(cardA, cardB, cardC, cardD);


    }

    public void addCard(string slotName)
    {
        Debug.Log(slotName);
        if (slotName.Contains('A'))
        {
            deck.addCard(cardA);
        }
        else if (slotName.Contains('B'))
        {
            deck.addCard(cardB);
        } 
        else if (slotName.Contains('C'))
        {
            deck.addCard(cardC);
        }
        else if (slotName.Contains("Remove Slot"))
        {
            deck.removeCard(cardD);
        }
        SpawnNextEnemy();
    }

    private void SpawnNextEnemy()
    {
        if (winScreen.activeInHierarchy)
        {
            winScreen.SetActive(false);
            int x = Random.Range(1, 5);
            Debug.Log("x - " + x);
            nextEnemyHealth = nextEnemyHealth * 1.2f;
            switch (x)
            {
                case 1:
                    DiamondEnemyObject.SetActive(true);
                    DiamondEnemy.spawn(nextEnemyHealth);
                    break;
                case 2:
                    CircleEnemyObject.SetActive(true);
                    CircleEnemy.spawn(nextEnemyHealth);
                    break;
                case 3:
                    SquareEnemyObject.SetActive(true);
                    SquareEnemy.spawn(nextEnemyHealth);
                    break;
                case 4:
                    HexagonEnemyObject.SetActive(true);
                    HexagonEnemy.spawn(nextEnemyHealth);
                    break;
                case 5:
                    CapsuleEnemyObject.SetActive(true);
                    CapsuleEnemy.spawn(nextEnemyHealth);
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void displayCards(Card card1, Card card2, Card card3, Card removeCard)
    {
        card1Name.text = card1.cardName;
        card1Damage.text = "Damage: " + card1.damage.ToString();
        card1SwingTime.text = "Swingtime: " + card1.swingTime.ToString();
        card2Name.text = card2.cardName;
        card2Damage.text = "Damage: " + card2.damage.ToString();
        card2SwingTime.text = "Swingtime: " + card2.swingTime.ToString();
        card3Name.text = card3.cardName;
        card3Damage.text = "Damage: " + card3.damage.ToString();
        card3SwingTime.text = "Swingtime: " + card3.swingTime.ToString();
        removeCardName.text = removeCard.cardName;
        audioManager.ChangeMusic(newSong);
    }
}
