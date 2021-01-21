using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitAction : MonoBehaviour
{
    public void TakeAction(Card.Alignment alignment)
    {
        List<int> units = new List<int>();

        if (alignment == Card.Alignment.Ally)
        {
            for (int i = Bf.SIZE - 1; i > Bf.SIZE; i--)
            {
                if (Bf.occupied[i])
                {
                    if (Bf.Cards[i].alignment == alignment)
                    {
                        units.Add(i);
                    }
                }
            }
        }

        for (int i = 0; i < units.Count; i++)
        {

        }
    }
}
