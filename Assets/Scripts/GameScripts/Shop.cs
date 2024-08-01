using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private Player _player;

    [SerializeField] private int _price;

    public GameObject ShopObject;
    public GameObject ShopCanvas;

    public event Action ShopDestroy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _player = other.GetComponent<Player>();
            if (_player.Wood >= _price)
            {
                ShopObject.SetActive(false);
                ShopCanvas.SetActive(false);
                _player.TakeWood(_price);
                SwapWepon(_player);

                ShopDestroy?.Invoke();
            }
        }
    }

    private void SwapWepon(Player player)
    {
        MainLinks.Instance.BasicWand.SetActive(false);
        player.ActiveWepon = MainLinks.Instance.EpicWand.GetComponent<MagicWeapon>();
        MainLinks.Instance.EpicWand.SetActive(true);
    }

}
