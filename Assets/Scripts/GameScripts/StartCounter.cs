using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartCounter : MonoBehaviour
{
    public TMP_Text CounterText;

    public event Action StartGame;
    
    private IEnumerator Start()
    {
        for (int i = 3; i >= 0; i--)
        {
            CounterText.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }
        CounterText.text = "";

        StartGame.Invoke();
    }
}
