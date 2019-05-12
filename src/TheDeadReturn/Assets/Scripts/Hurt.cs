using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class Hurt : MonoBehaviour
{
    public static Hurt hurt;

    public float lifetime;

    public float speed;

    public Vector2 range=new Vector2(1.1f,1.2f);

    private void Start()
    {
        hurt = this;
        InvokeRepeating("Flex", 0, speed*2);

        lifetime = speed * 4;

        var t = (range.x + range.y)/2;
        transform.localScale = new Vector3(t, t, t);
    }

    private void Flex()
    {
        var tween = transform.DOScale(range.y, speed);
        tween.OnKill(()=> { transform.DOScale(range.x, speed); });
    }

    private void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime<0)
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        if (hurt == this)
        {
            hurt = null;
        }
    }
}
