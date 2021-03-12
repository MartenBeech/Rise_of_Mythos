using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimaVictory : MonoBehaviour
{
    public static GameObject prefab;
    public static GameObject parent;
    public void DisplayVictory()
    {
        prefab = Resources.Load<GameObject>("Assets/Victory");
        parent = GameObject.Find("Animation");

        GameObject position = GameObject.Find("CanvasBattle");
        Vector3 newPos = new Vector3(position.transform.position.x + 1f, position.transform.position.y, position.transform.position.z);

        prefab = Instantiate(prefab, newPos, new Quaternion(0, 0, 0, 0), parent.transform);
    }

    public void DisplayNull()
    {
        Destroy(GameObject.Find("Victory(Clone)"));
    }

    public void NextClicked()
    {
        Game game = new Game();
        game.WinBattle();
        DisplayNull();
    }
}
