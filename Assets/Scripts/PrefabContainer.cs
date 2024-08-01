using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabContainer : MonoBehaviour
{
    public GameObject Coin;
    public GameObject Wood;
    public GameObject Sceleton;
    public GameObject Bat;
    public GameObject EnemyProjectile;
    public GameObject SkeletonMaleAttak;

    public GameObject IceBallImpact;
    public GameObject EnemyProjectileImpact;

    public static PrefabContainer Instance { get; private set; }

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

        LockOrientation();
    }

    private void LockOrientation()
    {
        Screen.orientation = ScreenOrientation.Portrait;

        Screen.autorotateToPortrait = false;
        Screen.autorotateToPortraitUpsideDown = false;
        Screen.autorotateToLandscapeLeft = false;
        Screen.autorotateToLandscapeRight = false;
    }
}
