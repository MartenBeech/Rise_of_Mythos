using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimaInfo : MonoBehaviour
{
    public static GameObject prefab;
    public static GameObject parent;
    public void DisplayCard(Card card, GameObject position)
    {
        prefab = Resources.Load<GameObject>("Assets/Info");
        parent = GameObject.Find("Animation");

        SpecialInfo specialInfo = new SpecialInfo();
        prefab.GetComponentInChildren<Text>().text = specialInfo.GetCardInfo(card);

        Vector3 newPos = new Vector3(position.transform.position.x + 3, position.transform.position.y, position.transform.position.z);

        prefab = Instantiate(prefab, newPos, new Quaternion(0, 0, 0, 0), parent.transform);
    }

    public void DisplayNull()
    {
        Destroy(GameObject.Find("Info(Clone)"));
    }

    public void DisplayCardHand(int i)
    {
        if (Hand.occupied[i])
        {
            DisplayCard(Hand.Cards[i], Hand.Hands[i]);
        }
    }

    public void DisplayCardBf(int i)
    {
        if (Bf.occupied[i])
        {
            DisplayCard(Bf.Cards[i], Bf.Bfs[i]);
        }
    }
}
