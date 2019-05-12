using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linker : MonoBehaviour
{
    public static List<GameObject> links;
    //link length
    public float length;

    public static Vector3 start;
    private void Start()
    {
        links = new List<GameObject>();
        start = transform.position;
    }

    void LinkMaker(Vector3 start,Vector3 end)
    {
        if (Vector3.Distance(start,end) > links.Count * (length + 2))
        {
            var link = Instantiate(Resources.Load("Prefabs/Link"), Vector3.Lerp(end,start,1/links.Count), Quaternion.identity) as GameObject;
            links.Add(link);
            link.AddComponent<Link>().count=links.Count;
            link.transform.SetParent(ModelDrag.Current.transform,false);
            link.transform.LookAt(transform.parent);
        }
    }
    private void OnDestroy()
    {
        
    }
    private void Update()
    {
//        LinkMaker(start, ModelDrag.Current.transform.position);
    }
}

public class Link : MonoBehaviour
{
    public int count;
    private void Update()
    {
        transform.position = Vector3.Lerp(Linker.start, ModelDrag.Current.transform.position, Linker.links.Count);
    }
}
