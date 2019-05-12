using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class Monster0 : MonoBehaviour,ITween
{
    
    Tween tween;
    [Range(-960,0)]
    public float targetX_Min=-900;

    [Range(-960,0)]
    public float targetX_Max=0;

    public AudioClip BurnSoundSource;
    private AudioSource BurnSound;
    public bool isBurn;

    public GhostType type;
    

    public static Monster0 Hitted;
    // Start is called before the first frame update
    void Start()
    {
        targetX_Max = MonsterInit.targetX_Max;
        targetX_Min = MonsterInit.targetX_Min;
        //type = (GhostType)Random.Range(0, GhostPicker.CurrentIndex);
        gameObject.tag = "Ammo";
        Vector3 target = new Vector3(Random.Range(targetX_Min, targetX_Max), -600, 0);
        tween = transform.DOLocalJump(target, MonsterInit.curve, 1, MonsterInit.lifescale);

        BurnSound = gameObject.AddComponent<AudioSource>();
    }

    private void Update()
    {
        if (transform.localPosition.y < -580)
            BurningToDestroy4Pos();
        //Debug.Log(Random.Range(0, 3));
        if (Input.GetMouseButtonUp(0))
        {
            if (isSelectted && Hitted == this)
            {
                if(Hitted.type==Ghost.ghost.type)
                Invoke("BurningToDestroy", 0.5f);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            BurningToDestroy();
        }
    }

    public void BurningToDestroy()
    {
        isBurn = true;
        Hitted = null;
        tween.Kill();
        var image = GetComponent<Image>();
        image.material = Instantiate(Resources.Load("Materials/Burning")) as Material;
        var tweenBurning = image.material.DOFloat(1, "_Amount", 1);
        //var tweenSize = transform.DOScale(3, 0.2f);
        tweenBurning.OnKill(() => { Destroy(gameObject); });
        BurnSound.PlayOneShot(BurnSoundSource);
    }
    
    public void BurningToDestroy4Pos()
    {
        isBurn = true;
        Hitted = null;
        Debug.Log("EEEEEEEEEEEEEEEEEEEEEE,I die");
        tween.Kill();
        var image = GetComponent<Image>();
        image.material = Instantiate(Resources.Load("Materials/Burning")) as Material;
        var tweenBurning = image.material.DOFloat(1, "_Amount", 1);
        //var tweenSize = transform.DOScale(3, 0.2f);
        tweenBurning.OnKill(() => { Destroy(gameObject); });
        //BurnSound.PlayOneShot(BurnSoundSource);
    }

    public void TweenStay()
    {

    }

    public void TweenEnd()
    {

    }
    
    void AnimaPlay(string AnimaName)
    {

    }

    public bool isSelectted = false;

    private void Selectted()
    {

    }

    private void OnDestroy()
    {
        //Instantiate(Resources.Load("Prefabs/Ammo/Destroyed"), transform.position, Quaternion.identity);
    }

    private void OnMouseEnter()
    {
        if (ModelDrag.isMouseDrag&&!isBurn)
        {
            Debug.Log("Enter");
            isSelectted = true;
            Hitted = this;
        }
    }
}

public interface ITween
{
    void TweenStay();
    void TweenEnd();
}
#if !Test
public enum GhostType
{
    GT_Red=1,
    GT_Blue=2,
    GT_Green=0
}
#endif