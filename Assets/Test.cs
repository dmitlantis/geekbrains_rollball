using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("asdf".findNumOfSymbols('a'));
        List<int> list = new List<int>(){1,2,3,4,5};
        Debug.Log(list.findNumOfNumbers(5));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public static class ExtensionClass {
    public static int findNumOfSymbols(this string str, char symbol)
    {
        int counter = 0;
        for (int tmp = 0; tmp < str.Length; tmp++)
        {
            if (str[tmp] == symbol)
            {
                counter++;
            }
        }
        
        return counter;
    }

    public static int findNumOfNumbers<T>(this List<T> list, T number)
    {
        int counter = 0;
        for (int tmp = 0; tmp < list.Count; tmp++)
        {
            if (list[tmp].Equals(number))
            {
                counter++;
            }
        }
        
        return counter;
    }
}
