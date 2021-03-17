using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Camera : MonoBehaviour
{
    public static GameObject Cam;
    public static GameObject CanvasBattle;
    public static GameObject CanvasRecruit;
    public static GameObject CanvasUpgrade;

    private void Start()
    {
        Cam = GameObject.Find("Main Camera");
        CanvasBattle = GameObject.Find("CanvasBattle");
        CanvasRecruit = GameObject.Find("CanvasRecruit");
        CanvasUpgrade = GameObject.Find("CanvasUpgrade");
        Battle();
    }

    public void Battle()
    {
        Cam.transform.position = new Vector3(CanvasBattle.transform.position.x + 0.8f, CanvasBattle.transform.position.y, -10);
    }

    public void Recruit()
    {
        Cam.transform.position = new Vector3(CanvasRecruit.transform.position.x + 0.8f, CanvasRecruit.transform.position.y, -10);
    }

    public void Upgrade()
    {
        Cam.transform.position = new Vector3(CanvasUpgrade.transform.position.x + 0.8f, CanvasUpgrade.transform.position.y, -10);
    }
}
