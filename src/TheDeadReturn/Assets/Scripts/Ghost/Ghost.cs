using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class Ghost : MonoBehaviour
{
    public int index;

    public GhostType type;
    public AnimationController ac;
    public static Ghost ghost;
    public AudioClip BellSoundSource;
    private AudioSource BellSound;
    private Animator soundwave;
    private GameObject Backlight;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ammo"))
        {
            //GetComponent<Image>().DOColor(Color.black, 1);
        }
    }

    private void Show()
    {
            var g = GhostPicker.ghosts[GhostPicker.CurrentIndex + 1];
            g.SetActive(true);
            g.transform.Find("GhostAnima").gameObject.AddComponent<GhostEnter>();
            GhostPicker.CurrentIndex++;
    }
    /*
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Grave"&&GhostPicker.CurrentIndex<3)
        {
            var g = GhostPicker.ghosts[GhostPicker.CurrentIndex + 1];
            g.SetActive(true);
            g.transform.Find("GhostAnima").gameObject.AddComponent<GhostEnter>();
            GhostPicker.CurrentIndex++;
        }
    }
    */
    private void Start()
    {
        //audio = Resources.Load("Audio/GhostClick") as AudioClip;
        if (type == GhostType.GT_Green)
        {
            ac = GameObject.Find("Ghost3").transform.Find("GhostAnima").GetComponent<AnimationController>();
            Backlight = GameObject.Find("Ghost3").transform.Find("Background").gameObject;
        }
        else if (type == GhostType.GT_Red)
        {
            ac = GameObject.Find("Ghost2").transform.Find("GhostAnima").GetComponent<AnimationController>();
            Backlight = GameObject.Find("Ghost2").transform.Find("Background").gameObject;
        }
        else if (type == GhostType.GT_Blue)
        {
            ac = GameObject.Find("Ghost1").transform.Find("GhostAnima").GetComponent<AnimationController>();
            Backlight = GameObject.Find("Ghost1").transform.Find("Background").gameObject;
        }
        BellSoundSource = Resources.Load("Audio/bell") as AudioClip;
        BellSound = gameObject.AddComponent<AudioSource>();
        soundwave = GameObject.Find("SoundWave").GetComponent<Animator>();
        Backlight.SetActive(false);

        GhostPicker.ghosts.Add(index, transform.parent.gameObject);
        
        //audio = Resources.Load("Audio/GhostClick") as AudioClip;
        if (index > 1)
        {
            transform.parent.gameObject.SetActive(false);
        }
    }
    private void Update()
    {
        
    }

    private void OnMouseDown()
    {
        BellSound.PlayOneShot(BellSoundSource);
        //soundwave.SetBool("IfBell", true);
        //AnimatorStateInfo info = soundwave.GetCurrentAnimatorStateInfo(0);
        //if (info.normalizedTime >= 1.0f)
        soundwave.Play("Circle", 0, 0.0f);

        Backlight.SetActive(true);
        ghost = this;
    }
    private void OnMouseUp()
    {
        if (Monster0.Hitted!=null && type==Monster0.Hitted.type)
        {
            ac.AttackAnimationOnce(type);
            Attack();
        }
        Backlight.SetActive(false);
    }
    private void Attack()
    {
        ghost = this;
        GameObject ammo = null;
        if (type == GhostType.GT_Green)
        {
            ammo = Instantiate(Resources.Load("Prefabs/Ammos 2") as GameObject, transform.parent.Find("GhostAnima").localPosition, Quaternion.identity);
        }
        else if (type == GhostType.GT_Blue)
        {
            ammo = Instantiate(Resources.Load("Prefabs/Ammos") as GameObject, transform.parent.Find("GhostAnima").localPosition, Quaternion.identity);
        }
        else if (type == GhostType.GT_Red)
        {
            ammo = Instantiate(Resources.Load("Prefabs/Ammos 1") as GameObject, transform.parent.Find("GhostAnima").localPosition, Quaternion.identity);
        }
        ammo.AddComponent<PlayerAmmo>();
        ammo.transform.SetParent(transform.parent.Find("Ammos"), false);
        Vector3 templocation = ammo.transform.localPosition;
        ammo.transform.localPosition = new Vector3(templocation.x + 200.0f, templocation.y + 50.0f, templocation.z);

        //GameObject ammo = Instantiate(Resources.Load("Prefabs/Ammos") as GameObject, transform.parent.Find("GhostAnima").localPosition, Quaternion.identity);
        //ammo.AddComponent<PlayerAmmo>().origin=this;
        //ammo.transform.SetParent(transform.parent.Find("Ammos"), false);
    }
}


public class GhostEnter : MonoBehaviour
{
    private void Start()
    {
        //var image = GetComponent<Image>().color = new Color(1, 1, 1, 0);
        //GetComponent<Image>().DOColor(new Color(1, 1, 1, 1),0.5f);
        var origin = transform.localPosition;
        transform.localPosition = new Vector3(-1080, 0, -0.1f);
        var tween = transform.DOLocalJump(origin, 200, 1, 1);
        //transform.DOShakePosition(duration: 1.0f, strength: 1);
        tween.OnKill(() => { Destroy(this); });
    }
}