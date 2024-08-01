using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    private Camera _camera;
    private IDamageable _damageObject;

    [SerializeField] private MonoBehaviour DamageableEntity;
    [SerializeField] private Transform FollowTransform;
    [SerializeField] private Vector3 _offset;
    [SerializeField] public Image HpFilld;

    private void OnEnable()
    {      
        _damageObject.HPChange += UpdateHpBar;
    }
    private void OnDisable()
    {
        _damageObject.HPChange -= UpdateHpBar;
    }

    private void Awake()
    {
        _damageObject = DamageableEntity as IDamageable;
        _camera = Camera.main;  
    }

    void LateUpdate()
    {
        transform.position = FollowTransform.position + _offset;
        
    }

    private void UpdateHpBar(float currentHpProgress)
    {
        if (currentHpProgress <= 0 ) Destroy(gameObject);
        HpFilld.fillAmount = currentHpProgress;
    }

    public void Init(MonoBehaviour damageableEntity, Transform followTransform, Vector3 offset)
    {
        DamageableEntity = damageableEntity;
        _damageObject = DamageableEntity as IDamageable;

        FollowTransform = followTransform;
        _offset = offset;       

        enabled = true;

        transform.LookAt(new Vector3(transform.position.x, _camera.transform.position.y, _camera.transform.position.z));
        transform.Rotate(0, 180, 0);
    }
}
