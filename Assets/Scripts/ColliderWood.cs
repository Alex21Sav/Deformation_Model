using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderWood : MonoBehaviour
{
    public int Index;

    private BoxCollider _boxCollider;
    private void Awake()
    {
        _boxCollider = GetComponent<BoxCollider>();
        Index = transform.GetSiblingIndex();
    }
    public void Hitcollider(float damage)
    {
        if(_boxCollider.size.y - damage > 0)
        {
            _boxCollider.size = new Vector3(_boxCollider.size.x, _boxCollider.size.y - damage, _boxCollider.size.z);
        }
        else
        {
            Destroy(this);
        }
    }
}
