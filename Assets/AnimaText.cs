using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimaText : MonoBehaviour
{
    public GameObject prefab;
    private GameObject startPos;
    public static GameObject parent;

    private float counter = UI.TIMER * 1f;
    

    private void Awake()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y);
    }

    void Update()
    {
        if (counter > 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + (0.003f / UI.TIMER));
            counter -= Time.deltaTime;

            if (counter <= 0)
            {
                UI ui = new UI();
                ui.ClearBfColors();
                Destroy(gameObject);
            }
        }
    }

    public void ShowText(GameObject to, string text, Color textColor)
    {
        prefab = Resources.Load<GameObject>("Assets/FloatingText");
        parent = GameObject.Find("Animation");
        startPos = to;
        prefab.GetComponentInChildren<Text>().color = textColor;
        prefab.GetComponentInChildren<Text>().text = text;

        Instantiate(prefab, startPos.transform.position, new Quaternion(0, 0, 0, 0), parent.transform);
    }
}
