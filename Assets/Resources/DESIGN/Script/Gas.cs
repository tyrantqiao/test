using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Gas : MonoBehaviour
{
    private Camera mainCam;
    private GameObject Gasui;
    private GameObject Can;
    private ParticleSystem Fire;
    public bool IsFire=false;
    private float BurnTime=60f;

    // Use this for initialization
    void Start()
    {
        Gasui = Resources.Load<GameObject>("DESIGN/ui/g1") as GameObject;//加载进内存

        Fire = GameObject.Find("FireParticle").gameObject.GetComponent<ParticleSystem>();

        mainCam = GameObject.Find("Main Camera").gameObject.GetComponent<Camera>();

        EventTrigger gasTri = transform.gameObject.GetComponent<EventTrigger>();//获取eventtrigger组件

        if (gasTri == null)
            gasTri=transform.gameObject.AddComponent<EventTrigger>();

        gasTri.triggers = new List<EventTrigger.Entry>();
        gasTri.triggers.Clear();

        //UnityAction<BaseEventData> action = new UnityAction<BaseEventData>(ChangeCam);
        EventTrigger.Entry entry1 = new EventTrigger.Entry
        {
            eventID = EventTriggerType.PointerClick,
            callback = new EventTrigger.TriggerEvent()
        };
        entry1.callback.AddListener(ChangeCam);
        gasTri.triggers.Add(entry1);

        Debug.Log("triggers.Count:" + gasTri.triggers.Count);
    }

    public void ChangeCam(BaseEventData arg0)
    {
        mainCam.enabled = false;
        //Cam1.enabled = true;
        Can = Instantiate(Gasui) as GameObject;
        //Can.transform.parent = canvas.transform;

        Debug.Log("Change Camera");
    }

    private void FireAndOver()
    {
        if (BurnTime <= 0 && IsFire != true)
        {
            BurnTime = 60f;
            IsFire = true;
            Debug.Log(BurnTime);
        }

        if (IsFire)
        {
            Fire.Play();
        }
        else
        {
            Fire.Stop();
        }
    }
    // Update is called once per frame
    void Update()
    {
        BurnTime -= Time.deltaTime;
        FireAndOver();
    }
}
