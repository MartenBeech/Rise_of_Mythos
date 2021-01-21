using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimaText : MonoBehaviour
{
    public GameObject prefab;
    private GameObject startPos;
    public static GameObject parent;
    private float counter = 1f;

    private void Awake()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y);
    }

    void Update()
    {
        if (counter > 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.05f);
            counter -= Time.deltaTime;

            if (counter <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    public void ShowText(int to, string text, Color textColor)
    {
        prefab = Resources.Load<GameObject>("Assets/FloatingText");
        parent = GameObject.Find("Animation");
        startPos = Bf.Bfs[to];
        prefab.GetComponentInChildren<Text>().color = textColor;
        prefab.GetComponentInChildren<Text>().text = text;

        Instantiate(prefab, startPos.transform.position, new Quaternion(0, 0, 0, 0), parent.transform);
    }
}
