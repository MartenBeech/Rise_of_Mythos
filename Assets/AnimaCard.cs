using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimaCard : MonoBehaviour
{
    public static GameObject startSet;
    public static GameObject endSet;
    public static GameObject prefab;
    public static GameObject parent;
    public static Card cardSet;
    private GameObject startPos;
    private GameObject endPos;
    private Card card;

    private float counter = UI.TIMER;

    private void Awake()
    {
        startPos = startSet;
        endPos = endSet;
        card = cardSet;
    }
    void Update()
    {
        if (counter > 0)
        {
            Vector3 dir = endPos.transform.position - startPos.transform.position;
            float dist = Mathf.Sqrt(
                Mathf.Pow(endPos.transform.position.x - startPos.transform.position.x, 2) +
                Mathf.Pow(endPos.transform.position.y - startPos.transform.position.y, 2));
            this.transform.Translate(dir.normalized * dist * Time.deltaTime / UI.TIMER);

            counter -= Time.deltaTime;

            if (counter <= 0)
            {
                card.DisplayCard(endPos, card);
                Destroy(gameObject);
            }
        }
    }

    public void MoveDeckHand(Card _card, int _from, int _to)
    {
        MoveCard(_card, Deck.Decks, Hand.Hands[_to], Hand.Cards[_to]);
        Hand.occupied[_to] = true;
        Hand.Cards[_to] = _card;
        Deck deck = new Deck();
        deck.RemoveCard(_from);
    }

    public void MoveHandBf(Card _card, int _from, int _to)
    {
        MoveCard(_card, Hand.Hands[_from], Bf.Bfs[_to], Bf.Cards[_to]);
        Bf.occupied[_to] = true;
        Bf.Cards[_to] = _card;
        Hand hand = new Hand();
        hand.RemoveCard(_from);
        _card.tile = _to;
        _card.readyToAttack = false;
    }

    public void MoveBfBf(Card _card, int _from, int _to)
    {
        MoveCard(_card, Bf.Bfs[_from], Bf.Bfs[_to], Bf.Cards[_to]);
        Bf.occupied[_to] = true;
        Bf.Cards[_to] = _card;
        Bf bf = new Bf();
        bf.RemoveCard(_from);
        _card.tile = _to;
        _card.readyToAttack = true;
    }

    public void MoveCard(Card _card, GameObject _from, GameObject _to, Card _cardTo)
    {
        prefab = Resources.Load<GameObject>("Assets/Card");
        parent = GameObject.Find("Animation");
        cardSet = _card;
        startSet = _from;
        endSet = _to;

        prefab.GetComponentInChildren<Image>().sprite = _card.sprite;

        prefab = Instantiate(prefab, startSet.transform.position, new Quaternion(0, 0, 0, 0), parent.transform);
    }
}

