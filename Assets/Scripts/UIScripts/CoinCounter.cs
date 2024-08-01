using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    [SerializeField] protected Player _player;
    [SerializeField] public TMP_Text GemText;

    private void OnEnable()
    {
        _player.CoinsChange += UpdateCounter;
    }

    private void OnDisable()
    {
        _player.CoinsChange -= UpdateCounter;
    }

    protected void UpdateCounter(int coins)
    {
        GemText.text = coins.ToString();
    }
}
