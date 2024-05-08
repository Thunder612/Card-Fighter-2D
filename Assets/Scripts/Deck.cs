using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class Deck : MonoBehaviour
{

    public List<Card> deck = new List<Card>();
    public int deckSize = 0;

    public Text cardName;
    public Text cardDamage;
    public Text cardSwingTime;


    

    public void removeCard(Card removeCard)
    {
        Debug.Log("Removing " + removeCard.cardName);
        for (int i = 0; i < deckSize; i++)
        {
            if (removeCard.id == deck[i].id)
            {
                if (i == deckSize - 1)
                {
                    deck[i] = null;
                    deckSize--;
                }
                else
                {
                    deck[i] = deck[deckSize - 1];
                    deckSize--;
                    break;
                }
            }
        }
        

    }

    public void displayCard(Card card)
    {
        cardName.text = card.cardName;
        cardDamage.text = "Damage: " + card.damage.ToString();
        cardSwingTime.text = "Swingtime: " + card.swingTime.ToString();
    }

    public void addCard(Card card)
    {
        deck[deckSize] = card;
        deckSize++;
        Debug.Log("Adding card " + card.cardName);
    }

    public void loadStarterDeck()
    {
        int x = -1;
        for (int i = 0; i < 3; i++)
        {

            x = Random.Range(1, 5); //range of starter cards is 1, 5
            
            deck[i] = CardDatabase.cardList[x];
            deckSize++;
        }
        displayCard(deck[0]);
    }

    public void shuffle()
    {
        for (int i = 0; i < deckSize; i++)
        {
            Card container = deck[i];
            int randomIndex = Random.Range(i, deckSize);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = container;
            Debug.Log(deck[i].cardName);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (deckSize == 0)
        {
            deck[0] = CardDatabase.cardList[1];
            deckSize++;
        }
    }
}
