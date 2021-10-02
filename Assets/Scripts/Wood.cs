using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Wood : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer _skinnedMeshRenderer;
    [SerializeField] private Transform _woodTransform;
    [SerializeField] private Vector3 _rotarionVector;
    [SerializeField] private float _rotationDuratuon;

    private void Start()
    {
        _woodTransform.DOLocalRotate(_rotarionVector, _rotationDuratuon, RotateMode.FastBeyond360).
            SetLoops(-1, LoopType.Restart).
            SetEase(Ease.Linear);
    }
    public void Hit(int keyIndex, float damage)
    {
        float ColliderHeight = 2.35f;
        float newWeight = _skinnedMeshRenderer.GetBlendShapeWeight(keyIndex) + damage * (100f / ColliderHeight);
        _skinnedMeshRenderer.SetBlendShapeWeight(keyIndex, newWeight);
    }
}
