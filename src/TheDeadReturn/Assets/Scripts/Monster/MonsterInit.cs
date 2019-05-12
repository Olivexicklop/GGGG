using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterInit : MonoBehaviour
{
    public float timer = 1;

    public float timerMax = 1.5f;

    public float timerMin = 0.5f;

    public float TargetX_Min;

    public static float targetX_Min;

    public float TargetX_Max;

    public static float targetX_Max;

    /// <summary>
    /// 曲线
    /// </summary>
    public static float curve;
    
    public float Curve;

    public static float lifescale;

    public float LifeScale;
    // Start is called before the first frame update
    void Awake()
    {
        targetX_Min = TargetX_Min;
        targetX_Max = TargetX_Max;
        curve = Curve;
        lifescale = LifeScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < 0)
        {
            var type = (GhostType)Random.Range(0, GhostPicker.CurrentIndex);

            GameObject newMonster;
            switch (type)
            {
                case GhostType.GT_Blue:
                    newMonster = Instantiate(Resources.Load("Prefabs/Monster/Monster_Blue"), new Vector3(960, Random.Range(200, 600), -0.3f), Quaternion.identity) as GameObject;
                    break;
                case GhostType.GT_Green:
                    newMonster = Instantiate(Resources.Load("Prefabs/Monster/Monster_Green"), new Vector3(960, Random.Range(200, 600), -0.3f), Quaternion.identity) as GameObject;
                    break;
                case GhostType.GT_Red:
                    newMonster = Instantiate(Resources.Load("Prefabs/Monster/Monster_Red"), new Vector3(960, Random.Range(200, 600), -0.3f), Quaternion.identity) as GameObject;
                    break;
                default:
                    return;
            }
            Debug.Log(type);
            newMonster.GetComponent<Monster0>().type = type;
            newMonster.transform.SetParent(GameObject.Find("Monsters").transform,false);
            timer = Random.Range(timerMin, timerMax);
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}
