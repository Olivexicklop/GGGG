using UnityEngine;

using UnityEngine.UI;

using System.Collections;

using UnityEngine.EventSystems;

using System.Collections.Generic;

public class ModelDrag : MonoBehaviour

{
    public List<GameObject> LineInstance;

    private GameObject ArrowInstance;

    public static bool isMouseDrag;

    private AudioSource ClickSound;
    public AudioClip ClickSoundSource;

    private Vector3 OriginPosition;

    private Vector3 LocalOriginPosition;

    private Vector3 CurrentPosition;

    private Vector3 LocalCurrentPosition;

    public Vector3 screenPosition;

    public Transform CanvasParents;

    public Vector3 offset;

    public static Ghost Current;

    void Start()
    {
        //        Debug.Log("Start");
        isMouseDrag = false;
        // add LineRenderer component
        //lineRenderer = gameObject.AddComponent<LineRenderer>();
        //// get LineRenderer component
        //lineRenderer = GetComponent<LineRenderer>();
        //// set vertex count 2
        //lineRenderer.positionCount = 2;
        ////// set material
        //////lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
        //// set color
        //lineRenderer.startColor = Color.red;
        //lineRenderer.endColor = Color.yellow;
        //// set width
        //lineRenderer.startWidth = lineRenderer.endWidth = 0.2f;
        // set origin position
        OriginPosition = gameObject.transform.position;
        LocalOriginPosition = gameObject.transform.localPosition;

        // new a list
        LineInstance = new List<GameObject>();
        ArrowInstance = new GameObject();
        ArrowInstance = (GameObject)Instantiate(Resources.Load("P_RedArrow"), CanvasParents);
        ArrowInstance.layer = 5;

        ClickSound = gameObject.AddComponent<AudioSource>();
    }

    void OnMouseDown()

    {
        //        Debug.Log("Down");

        Cursor.visible = false;

        screenPosition = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPosition.z));

        isMouseDrag = true;

        ArrowInstance.SetActive(true);

        // load RedLine perfab
        for (int i = 0; i < 18; i++)
        {
            GameObject temp = (GameObject)Instantiate(Resources.Load("P_RedLine"), CanvasParents);
            LineInstance.Add(temp);
        }

        Current = GetComponent<Ghost>();

        ClickSound.PlayOneShot(ClickSoundSource);
    }

    void OnMouseDrag()
    {
        if (isMouseDrag)
        {
            for (int i = 0; i < LineInstance.Count; i++)
            {
                LineInstance[i].transform.localPosition = new Vector3(0.0f, 0.0f, 1.0f);
                LineInstance[i].SetActive(true);
            }

            Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPosition.z);

            CurrentPosition = Camera.main.ScreenToWorldPoint(currentScreenSpace) + offset;
            LocalCurrentPosition = currentScreenSpace - new Vector3(Screen.width / 2, Screen.height / 2, 0.0f);

            gameObject.transform.position = CurrentPosition;

            //lineRenderer.positionCount = 2;
            //lineRenderer.SetPosition(0, OriginPosition);
            //lineRenderer.SetPosition(1, CurrentPosition);

            Current = GetComponent<Ghost>();

            // create line segment
            float distance = Vector3.Distance(LocalOriginPosition, LocalCurrentPosition);

            int count = (int)(distance / 100.0f);
            float angle = Vector3.Angle(new Vector3(1.0f, 0.0f, 0.0f), LocalCurrentPosition - LocalOriginPosition) + 90.0f;
            Vector3 deltaTransform = (LocalCurrentPosition - LocalOriginPosition) / count;
            //Debug.Log(distance.ToString() + " " + angle.ToString());
            for (int i = 0; i < count; i++)
            {
                LineInstance[i].transform.localPosition = LocalOriginPosition + i * deltaTransform;
                LineInstance[i].transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
                LineInstance[i].transform.Rotate(new Vector3(0.0f, 0.0f, 1.0f), angle);
                LineInstance[i].layer = 5;
                //SizeChange
                LineInstance[i].transform.localScale = new Vector3(20.0f, 20.0f, 1.0f);
                LineInstance[i].GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.1f + i * 0.9f / count);
            }
            for (int i = count; i < 18; i++) 
                LineInstance[i].SetActive(false);
            ArrowInstance.transform.localPosition = LocalCurrentPosition;
            ArrowInstance.transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
            ArrowInstance.transform.Rotate(new Vector3(0.0f, 0.0f, 1.0f), (angle + 180.0f));
            //SizeChange
            ArrowInstance.transform.localScale = new Vector3(20.0f, 20.0f, 1.0f);
        }

    }
    private void OnMouseEnter()
    {
        //        Debug.Log("Enter");
    }
    void OnMouseUp()
    {
        Cursor.visible = true;

        if (isMouseDrag == true)
        {
            gameObject.transform.position = OriginPosition;
            //lineRenderer.positionCount = 0;
            for (int i = 0; i < 18; i++)
                Destroy(LineInstance[i]);
            LineInstance.Clear();
            ArrowInstance.SetActive(false);
        }

        isMouseDrag = false;

        Current = null;
    }

}