using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class GameStart : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var t = GetComponent<Image>().DOColor(new Color(1, 1, 1, 0), 0.5f);
            t.OnKill(() => { Destroy(gameObject); });
        }
    }
}
