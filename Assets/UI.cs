using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    GameObject SpeedUp;
    public static float TIMER = 1f;

    private void Start()
    {
        SpeedUp = GameObject.Find("SpeedUp");
    }
    public void SpeedUpGame()
    {
        switch (TIMER)
        {
            case 1f:
                TIMER = 0.5f;
                SpeedUp.GetComponentInChildren<Text>().text = "Speed = 2x";
                break;

            case 0.5f:
                TIMER = 0.25f;
                SpeedUp.GetComponentInChildren<Text>().text = "Speed = 4x";
                break;

            case 0.25f:
                TIMER = 2f;
                SpeedUp.GetComponentInChildren<Text>().text = "Speed = 0.5x";
                break;

            case 2f:
                TIMER = 1f;
                SpeedUp.GetComponentInChildren<Text>().text = "Speed = 1x";
                break;
        }
    }

    public void ClearBfColors()
    {
        for (int i = 0; i < Bf.SIZE; i++)
        {
            Bf.Bfs[i].GetComponentInChildren<Image>().color = Hue.white;
        }
    }
}
