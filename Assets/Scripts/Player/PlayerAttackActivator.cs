using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackActivator : MonoBehaviour
{
    public Player Player;
    public PlayerControler PlayerControler;

    private void OnTriggerEnter(Collider other)
    {
        GameObject enterObject = other.gameObject;
        if (other.transform.tag == "Enemy" && !Player.EnemysISee.Contains(enterObject))
        {
            Player.EnemysISee.Add(enterObject);
            //if (PlayerControler.joystickInput == new Vector2(0, 0)) { }
            Player.ActiveWepon.Active = true;
            Player.ActiveWepon.StartAttack();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        GameObject enterObject = other.gameObject;
        if (other.transform.tag == "Enemy" && Player.EnemysISee.Contains(enterObject))
        {
            Player.EnemysISee.Remove(enterObject);

            if (Player.EnemysISee.Count == 0) Player.ActiveWepon.Active = false;
        }
    }
}
