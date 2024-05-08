using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDatabase : MonoBehaviour
{
    public static List<Card> cardList = new List<Card>();

    public Collider2D circleSwing;
    public Collider2D upStab;
    public Collider2D downStab;
    public Collider2D leftStab;
    public Collider2D rightStab;
    public Collider2D tallUpStab;
    public Collider2D wideDownStab;
    public Collider2D healCollid;
    public Collider2D hyperBeam;
    public Collider2D poisonNeedle;
    public Collider2D downLeftStab;




    public void Start()
    {
        cardList.Add(new Card(0, "404", -1, circleSwing, null, 1));
        cardList.Add(new Card(1, "Up Stab", 5, upStab, null, 2));
        cardList.Add(new Card(2, "Down Stab", 5, downStab, null, 2));
        cardList.Add(new Card(3, "Left Stab", 5, leftStab, null, 2));
        cardList.Add(new Card(4, "Right Stab", 5, rightStab, null, 2));
        cardList.Add(new Card(5, "Circle Slash", 5, circleSwing, null, 5));
        cardList.Add(new Card(6, "Damaging Right Stab", 11, rightStab, null, 3));
        cardList.Add(new Card(7, "Quick Left Stab", 7, leftStab, null, 1));
        cardList.Add(new Card(8, "Tall Up Stab", 7, tallUpStab, null, 3));
        cardList.Add(new Card(9, "Wide Down Stab", 7, wideDownStab, null, 3));
        cardList.Add(new Card(10, "One Tenth Heal", 0, healCollid, null, 2));
        cardList.Add(new Card(11, "Hyper Beam", 20, hyperBeam, null, 8));
        cardList.Add(new Card(12, "Poison Needle", 15, poisonNeedle, null, 3));
        cardList.Add(new Card(13, "Instant Poke", 2, downLeftStab, null, .1f));

    }
}
