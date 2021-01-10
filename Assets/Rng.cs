using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rng : MonoBehaviour
{
    const int rngFactor = 1000;

    public int Range(int min, int max)
    {
        List<int> numbers = new List<int>();
        min *= rngFactor;
        max *= rngFactor;

        for (int i = 0; i < 50; i++)
        {
            numbers.Add(Random.Range(min, max));
        }

        int number = numbers[Random.Range(0, numbers.Count)];
        if (number < 0)
        {
            number -= rngFactor;
        }
        float temp = number / 1000;
        return Mathf.FloorToInt(temp);
    }
}
