using UnityEngine;
using DG.Tweening;

public class PlayerAmmo : MonoBehaviour
{
    public AudioClip ShootSoundSource;
    private AudioSource ShootSound;

    private Vector3 target;
    public Ghost origin;
    private GameObject targetObject;
    public float speed=1500;
    private Tween tween;
    private void Start()
    {
            ShootSoundSource = Resources.Load("Audio/火焰攻击3") as AudioClip;

            ShootSound = gameObject.AddComponent<AudioSource>();

            ShootSound.PlayOneShot(ShootSoundSource);

            //tween.OnPlay(() => { tween.target = targetObject; });
            tween.OnKill(() => { Destroy(gameObject); });
            target = Monster0.Hitted.transform.localPosition;
            targetObject = Monster0.Hitted.gameObject;
            
    }
#if !Test

    private void Update()
    {
      
        float step = speed * Time.deltaTime;
        gameObject.transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, Monster0.Hitted.gameObject.transform.localPosition, step);

        float angle = Vector3.Angle(new Vector3(1.0f, 0.0f, 0.0f), gameObject.transform.localPosition - Monster0.Hitted.gameObject.transform.localPosition);
        //Debug.Log(angle);
        gameObject.transform.rotation = new Quaternion(0.0f,0.0f,0.0f,0.0f);
        gameObject.transform.Rotate(new Vector3(0.0f, 0.0f, 1.0f), 180.0f-angle+90.0f);
        if (Vector3.Distance(gameObject.transform.localPosition , Monster0.Hitted.gameObject.transform.localPosition) <= 200.0f)
        {
            Destroy(gameObject);
        }
    
        //tween = transform.DOLocalJump(Monster0.Hitted.transform.localPosition, 200, 1, 0.5f);
        if (tween != null)
        {
            if (tween.IsPlaying())
            {
                //tween.target = targetObject;
                //tween.target = target;
            }
        }
        if (Monster0.Hitted == null)
        {
            //Destroy(gameObject);
        }
    }
#endif
#if Test
    private void Update()
    {
        //targetObject.GetComponent<Monster0>().BurningToDestroy();
        var deltaVec = target - transform.localPosition;
        transform.localPosition += deltaVec.normalized * speed*Time.deltaTime;
        if (deltaVec.magnitude < 0.1f)
        {
            Destroy(gameObject);
        }
        if (targetObject.GetComponent<Monster0>().isBurn)
        {
            Destroy(gameObject);
        }
    }
#endif
}