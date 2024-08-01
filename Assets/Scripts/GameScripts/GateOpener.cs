using UnityEngine;

public class GateOpener : MonoBehaviour
{
    private Player _player;

    [SerializeField] private int _price;
    
    public Collider GateCollider;
    public GameObject GateCanvas;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _player = other.GetComponent<Player>();
            if (_player.Coins >= _price) 
            {
                GateCollider.enabled = false;
                GetComponent<Collider>().enabled = false;
                GateCanvas.SetActive(false);
                _player.TakeCoins(_price);
            }
        }
    }
}
