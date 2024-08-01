using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLinks : MonoBehaviour
{
    public static MainLinks Instance { get; private set; }

    public GameObject Player;
    public Player ScriptPlayer;
    public StartCounter StartCounter;
    public Shop Shop;
    public GameObject BasicWand;
    public GameObject EpicWand;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
