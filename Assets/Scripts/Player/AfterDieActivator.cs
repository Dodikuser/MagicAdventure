using UnityEngine;

public class AfterDieActivator : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Collider _collider;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Weapon _script;

    private void Start()
    {
        _player.Death += PhysicsActivation;
    }

    private void PhysicsActivation()
    {
        transform.parent = null;
        _player.transform.GetComponent<Collider>().enabled = false;
        _player.transform.gameObject.SetActive(false);
        rb.useGravity = true;
        rb.isKinematic = false;
        _collider.enabled = true;
        rb.AddForce((Vector3.forward + Vector3.up) * 300f);

        if (_script != null)
        {
            _script.enabled = false;
            _script.Active = false;
        }
    }
}
