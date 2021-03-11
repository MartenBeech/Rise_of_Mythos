using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimaHeroInfo : MonoBehaviour
{
    public static GameObject prefab;
    public static GameObject parent;
    public void DisplayHeroInfo()
    {
        prefab = Resources.Load<GameObject>("Assets/HeroInfo");
        parent = GameObject.Find("Animation");

        EnemyHero enemyHero = new EnemyHero();
        prefab.GetComponentInChildren<Text>().text = enemyHero.GetHeroInfo();

        GameObject position = Hero.Heroes[1];
        Vector3 newPos = new Vector3(position.transform.position.x + 0f, position.transform.position.y + 1.65f, position.transform.position.z);

        prefab = Instantiate(prefab, newPos, new Quaternion(0, 0, 0, 0), parent.transform);
    }

    public void DisplayNull()
    {
        Destroy(GameObject.Find("HeroInfo(Clone)"));
    }
}
