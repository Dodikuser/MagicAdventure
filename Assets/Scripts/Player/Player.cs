using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable, IDestroyable
{
    [SerializeField] public float MaxHP = 15f;
    [SerializeField] private float HP = 15f;
    [SerializeField] private float RegenSpeed = 1f;
    [SerializeField] public int Coins = 0;
    [SerializeField] public int Wood = 0;

    public TMP_Text GemText;
    public event Action<int> CoinsChange;
    public event Action<int> WoodChange;
    public event Action<float> HPChange;
    public event Action Death;

    public Material Material;
    public Weapon ActiveWepon;
    public static List<GameObject> EnemysISee = new List<GameObject>();
    public static GameObject ClosestEnemy;

    private void Start()
    {
        CoinsChange?.Invoke(Coins);
        WoodChange?.Invoke(Wood);
        HP = MaxHP;

        StatCanvasScript.Instance.CreateHpBar(this, transform, new Vector3(0f, 2.73f, 0.57f));
    }

    public void TakeDamage(float damage)
    {
        HP -= damage;
        StartCoroutine(ImpactDamage());
        if (HP <= 0)
        {
            DestroyEvent();
            HPChange?.Invoke(0f);
        }
        else HPChange?.Invoke( HP / MaxHP );
    }

    public void DestroyEvent()
    {
        Death?.Invoke();

        foreach (var obj in EnemySpawner.Instance.Enemys)
        {
            Enemy enemy = obj.GetComponent<Enemy>();
            enemy.SetState(enemy.Rest);
            enemy.Animator.SetTrigger("Rest");
        }
    }
    public void GiveCoins(int coins)
    {
        if (coins > 0) 
        {
            Coins += coins;
            CoinsChange?.Invoke(Coins);
        }
    }
    public void TakeCoins(int coins)
    {
        if (coins > 0)
        {
            Coins -= coins;
            CoinsChange?.Invoke(Coins);
        }
    }
    public void GiveWood(int count)
    {
        if (count > 0)
        {
            Wood += count;
            WoodChange?.Invoke(Wood);
        }
    }
    public void TakeWood(int count)
    {
        if (count > 0)
        {
            Wood -= count;
            WoodChange?.Invoke(Wood);
        }
    }

    public IEnumerator ImpactDamage()
    {
        Material.color = new Color(1.0f, 0.75f, 0.8f);
        yield return new WaitForSeconds(0.2f);
        Material.color = Color.white;
    }
}
