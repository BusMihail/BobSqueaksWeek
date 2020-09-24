using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Sprite))]
public class RedArrow : MonoBehaviour
{
    [SerializeField]
    private float moveYAmount = 0.1f;
    [SerializeField]
    private float moveTime = 0.5f;

    [SerializeField]
    private float scaleValue = 0.025f;
    [SerializeField]
    private float scaleTime = 0.5f;

    private void Start()
    {
        transform.DOMoveY(transform.position.y + moveYAmount, moveTime).SetLoops(-1, LoopType.Yoyo);
        transform.DOScale(scaleValue, scaleTime).SetLoops(-1, LoopType.Yoyo);
    }
}
