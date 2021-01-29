using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimaText : MonoBehaviour
{
    private GameObject prefab;
    private GameObject startPos;
    private GameObject parent;
    private static bool clusteredText;

    private float counter = UI.TIMER * 1f;
    

    private void Awake()
    {
        if (clusteredText)
        {
            Rng rng = new Rng();
            float rndX = rng.Range((int)(transform.position.x * 1000) - 400, (int)(transform.position.x * 1000) + 400);
            rndX /= 1000;
            float rndY = rng.Range((int)(transform.position.y * 1000) - 400, (int)(transform.position.y * 1000) + 400);
            rndY /= 1000;
            transform.position = new Vector3(rndX, rndY);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y);
        }
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

    public void ShowText(GameObject to, string text, Color textColor, bool _clusteredText = false)
    {
        prefab = Resources.Load<GameObject>("Assets/FloatingText");
        parent = GameObject.Find("Animation");
        startPos = to;
        prefab.GetComponentInChildren<Text>().color = textColor;
        prefab.GetComponentInChildren<Text>().text = text;
        clusteredText = _clusteredText;

        Instantiate(prefab, startPos.transform.position, new Quaternion(0, 0, 0, 0), parent.transform);
    }
}
