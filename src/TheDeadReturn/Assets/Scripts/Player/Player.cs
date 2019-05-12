using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class Player : MonoBehaviour
{
    private void Start()
    {
        Shake();
    }
    private void Shake()
    {
        transform.DOShakePosition(10);
    }
}
