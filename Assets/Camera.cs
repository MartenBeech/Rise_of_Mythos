using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Camera : MonoBehaviour
{
    public static GameObject Cam;
    public static GameObject CanvasBattle;
    public static GameObject CanvasRecruit;

    private void Start()
    {
        Cam = GameObject.Find("Main Camera");
        CanvasRecruit = GameObject.Find("CanvasRecruit");
        CanvasBattle = GameObject.Find("CanvasBattle");
        Battle();
    }

    public void Recruit()
    {
        Cam.transform.position = new Vector3(CanvasRecruit.transform.position.x, CanvasRecruit.transform.position.y, -10);
    }

    public void Battle()
    {
        Cam.transform.position = new Vector3(CanvasBattle.transform.position.x + 0.8f, CanvasBattle.transform.position.y, -10);
    }
}
