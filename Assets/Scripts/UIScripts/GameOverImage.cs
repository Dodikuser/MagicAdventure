using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverImage : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Image _image;

    void Start()
    {
        _player.Death += ShowGameOver;
    }

    private void ShowGameOver()
    {
        _image.enabled = true;
    }
}
