using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StatCanvasScript : MonoBehaviour
{
    [SerializeField] private GameObject HpBar;

    public static StatCanvasScript Instance { get; private set; }
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

    public void CreateHpBar(MonoBehaviour damageableEntity, Transform followTransform, Vector3 offset)
    {
        GameObject hpBar = Instantiate(HpBar, transform);
        hpBar.GetComponent<HPBar>().Init(damageableEntity, followTransform, offset);
    }
}
