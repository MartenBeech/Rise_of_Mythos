using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bf : MonoBehaviour
{
    public const int SIZE = 10;
    public static GameObject[] Bfs = new GameObject[SIZE];
    public static Card[] Cards = new Card[SIZE];
    public static bool[] occupied = new bool[SIZE];
    public static int selected = SIZE;

    private void Start()
    {
        for (int i = 0; i < SIZE; i++)
        {
            Bfs[i] = GameObject.Find("Bf (" + i + ")");
        }
    }

    public void BfClicked(int i)
    {
        selected = i;
    }
}
