using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bf : MonoBehaviour
{
    public const int BFSIZE = 10;
    public static GameObject[] Bfs = new GameObject[BFSIZE];
    public static Card[] Cards = new Card[BFSIZE];
    private bool[] occupied = new bool[BFSIZE];

    public bool[] Occupied { get => occupied; set => occupied = value; }

    private void Start()
    {
        for (int i = 0; i < BFSIZE; i++)
        {
            Bfs[i] = GameObject.Find("Bf (" + i + ")");
        }
    }

    public void BfClicked(int i)
    {

    }
}
