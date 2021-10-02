using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _hitDamage;
    [SerializeField] private Wood _wood;
    [SerializeField] private ParticleSystem _fxWood;

    private ParticleSystem.EmissionModule _emissionModuleWood;

    private Rigidbody _bladeRigidbody;
    private Vector3 _movementVector;
    private bool _isMoving = false;
    private void Start()
    {
        _bladeRigidbody = GetComponent<Rigidbody>();

        _emissionModuleWood = _fxWood.emission;
    }
    private void Update()
    {
        _isMoving = Input.GetMouseButton(0);

        if (_isMoving)
        {
            _movementVector = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0f) * _movementSpeed * Time.deltaTime;
        }
    }
    private void FixedUpdate()
    {
        _bladeRigidbody.position += _movementVector;
    }

    private void OnCollisionExit(Collision collision)
    {
        _emissionModuleWood.enabled = false;
    }
    private void OnCollisionStay(Collision collision)
    {
        ColliderWood colliderWood = collision.collider.GetComponent<ColliderWood>();

        if(colliderWood != null)
        {
            _emissionModuleWood.enabled = true;
            _fxWood.transform.position = collision.contacts[0].point;

            colliderWood.Hitcollider(_hitDamage);
            _wood.Hit(colliderWood.Index, _hitDamage);
        }
    }
}
