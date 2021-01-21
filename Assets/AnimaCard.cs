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
    public static Card PlaceSet;
    public static Card cardSet;
    private GameObject startPos;
    private GameObject endPos;
    private Card placePos;
    private Card card;

    private static float counterSet;
    private float counter;

    private void Awake()
    {
        startPos = startSet;
        endPos = endSet;
        placePos = PlaceSet;
        card = cardSet;
        counter = counterSet;
    }
    void Update()
    {
        if (counter > 0)
        {
            Vector3 dir = endPos.transform.position - startPos.transform.position;
            float dist = Mathf.Sqrt(
                Mathf.Pow(endPos.transform.position.x - startPos.transform.position.x, 2) +
                Mathf.Pow(endPos.transform.position.y - startPos.transform.position.y, 2));
            this.transform.Translate(dir.normalized * dist * Time.deltaTime / counterSet);

            counter -= Time.deltaTime;

            if (counter <= 0)
            {
                card.DisplayCard(endPos, card);
                Destroy(gameObject);
            }
        }
    }

    public void MoveDeckHand(Card _card, int _to, float _counter = 1f)
    {
        MoveCard(_card, Deck.Decks, Hand.Hands[_to], Hand.Cards[_to], _counter);
    }

    public void MoveHandBf(Card _card, int _from, int _to, float _counter = 1f)
    {
        MoveCard(_card, Hand.Hands[_from], Bf.Bfs[_to], Bf.Cards[_to], _counter);
    }

    public void MoveBfBf(Card _card, int _from, int _to, float _counter = 1f)
    {
        MoveCard(_card, Bf.Bfs[_from], Bf.Bfs[_to], Bf.Cards[_to], _counter);
    }

    public void MoveCard(Card _card, GameObject _from, GameObject _to, Card _cardTo, float _counter = 1f)
    {
        MoveSetup(_card, _counter);
        startSet = _from;
        endSet = _to;
        PlaceSet = _cardTo;

        prefab = Instantiate(prefab, startSet.transform.position, new Quaternion(0, 0, 0, 0), parent.transform);
    }

    private void MoveSetup(Card _card, float _counter)
    {
        prefab = Resources.Load<GameObject>("Assets/Card");
        parent = GameObject.Find("Animation");
        counterSet = _counter;
        cardSet = _card;
    }
}

