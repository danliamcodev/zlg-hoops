using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Shuffler", menuName = "Utility/Shuffler")]
public class Shuffler : ScriptableObject
{
    public void ShuffleList<T>(List<T> p_list)
    {
        int n = p_list.Count;
        for (int i = 0; i < n - 1; i++)
        {
            int j = Random.Range(i, n);
            T temp = p_list[i];
            p_list[i] = p_list[j];
            p_list[j] = temp;
        }
    }
}
