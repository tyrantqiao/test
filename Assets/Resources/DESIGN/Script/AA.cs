using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public  class AA : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("监听到click");
        PassEvent(eventData, ExecuteEvents.pointerClickHandler);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //PassEvent(eventData, ExecuteEvents.pointerDownHandler);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //PassEvent(eventData, ExecuteEvents.pointerUpHandler);
    }

    //事件传递
    public void PassEvent<T>(PointerEventData data, ExecuteEvents.EventFunction<T> function)
    where T : IEventSystemHandler
    {
        List<RaycastResult> results = new List<RaycastResult>();
        //RaycastAll:射出一条射线并返回所有碰撞，返回的是RaycastHit[]结构体
        //射线不会检测到ui
        //ui直接渲染在屏幕上
        EventSystem.current.RaycastAll(data, results);
        //results里面都是拥有  碰撞体  的物体、ui
        GameObject current = data.pointerCurrentRaycast.gameObject;
        for (int i = 0; i < results.Count; i++)
        {
            Debug.Log("------"+results[i].gameObject.name+"------");
            if (current != results[i].gameObject) 
            {
                ExecuteEvents.Execute(results[i].gameObject, data, function);
                Debug.Log("******"+current.gameObject.name+"******");
                break;
                //RaycastAll后ugui会自己排序，如果你只想响应透下去的最近的一个响应，这里ExecuteEvents.Execute后直接break就行。
            }
            //else
            //{
            //    Debug.Log("不是collider");
            //}
        }
    }

}
