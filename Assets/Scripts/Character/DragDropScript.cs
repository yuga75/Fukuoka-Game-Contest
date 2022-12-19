using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDropScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Vector3 prePosition;
    public Vector3 playerPos;


    /// <summary>
    /// ドラッグ開始時に呼び出される
    /// </summary>
    /// <param name="eventData"></param>
    public void OnBeginDrag(PointerEventData eventData)
    {
        prePosition = transform.position;
    }

    /// <summary>
    /// ドラッグ中に呼び出される
    /// </summary>
    /// <param name="eventData"></param>
    public void OnDrag(PointerEventData eventData)
    {
        playerPos = Camera.main.ScreenToWorldPoint(eventData.position);
        playerPos.z = 0;
        transform.position = playerPos;

    }

    /// <summary>
    /// ドラッグ終わりに呼び出される
    /// </summary>
    /// <param name="eventData"></param>
    public void OnEndDrag(PointerEventData eventData)
    {
        bool flg = true;

        var raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raycastResults);

        foreach (var hit in raycastResults)
        {
            if (hit.gameObject.CompareTag("NormalFloor"))
            {
                transform.position = hit.gameObject.transform.position;
                flg = false;
            }
        }

        if (flg)
        {
            transform.position = prePosition;
        }
    }

    void Update()
    {
        //Debug.Log(gameObject.transform.position);
    }
}
