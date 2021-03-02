using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    GameObject SpeedUp;
    public static float TIMER = 2f;

    private void Start()
    {
        SpeedUp = GameObject.Find("SpeedUp");
        SpeedUpGame();
    }

    public void SpeedUpGame()
    {
        switch (TIMER)
        {
            case 1f:
                TIMER = 0.5f;
                SpeedUp.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("UI/Speed2");
                break;

            case 0.5f:
                TIMER = 0.25f;
                SpeedUp.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("UI/Speed3");
                break;

            case 0.25f:
                TIMER = 2f;
                SpeedUp.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("UI/Speed0");
                break;

            case 2f:
                TIMER = 1f;
                SpeedUp.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("UI/Speed1");
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
