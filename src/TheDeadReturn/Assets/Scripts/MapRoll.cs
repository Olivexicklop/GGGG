using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MapRoll : MonoBehaviour
{
    public static int MapLength;
    public static int MapCount;
    public static List<GameObject> MapBackground;
    public static List<GameObject> MapsFront;

    public static MapRoll mapRoll;

    /// <summary>
    /// 中景速度
    /// </summary>
    public float FrontSpeed;
    /// <summary>
    /// 中远景速度
    /// </summary>
    public float BackgroundSpeed;
    private void Awake()
    {
        mapRoll = this;
    }
    private void Start()
    {
        CreateMap();
    }
    private void CreateMap()
    {
        MapsFront = MapInit("Prefabs/Map","Layer4",478,FrontSpeed);

        MapBackground = MapInit("Prefabs/Map", "Layer3",-478,BackgroundSpeed);
    }

    List<GameObject> MapInit(string Path,string Layer,int y,float speed)
    {
        List<GameObject> maps = new List<GameObject>();

        switch (MapCount)
        {
            case 0:
                maps.AddRange(Resources.LoadAll<GameObject>(Path+0+"/"+Layer));
                break;
            case 1:
                maps.AddRange(Resources.LoadAll<GameObject>(Path+1));
                break;
            case 2:
                maps.AddRange(Resources.LoadAll<GameObject>(Path+2));
                break;
        }
        for (int i = 0; i < maps.Count; i++)
        {
            var g = Instantiate(maps[i], new Vector3(5940 * (i + 1), y, 0), Quaternion.identity) as GameObject;
            g.GetComponent<Map>().speed=speed;
            g.transform.SetParent(GameObject.Find(Layer).transform, false);
        }
        return maps;
    }

    private void MapEnd()
    {
        foreach(GameObject m in MapsFront)
        {
            m.GetComponent<Map>().isEnd = true ;
        }
    }
}
