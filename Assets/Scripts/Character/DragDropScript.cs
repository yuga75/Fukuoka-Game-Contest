using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDropScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Vector3 prePosition;
    public Vector3 currentPosition;
    public Vector3 playerPos;

    public PlayerTest playerTest;

    private GameObject ControllButtonObject;
    private ControllButton cb;

    void Start()
    {
        ControllButtonObject = GameObject.Find("ControllButton(empty)");
        cb = ControllButtonObject.GetComponent<ControllButton>();
    }
    /// <summary>
    /// ドラッグ開始時に呼び出される
    /// </summary>
    /// <param name="eventData"></param>
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (cb.play == false && cb.stop == false)
        {
            prePosition = transform.position;
        }
    }

    /// <summary>
    /// ドラッグ中に呼び出される
    /// </summary>
    /// <param name="eventData"></param>
    public void OnDrag(PointerEventData eventData)
    {
        if (cb.play == false && cb.stop == false)
        {
            playerPos = Camera.main.ScreenToWorldPoint(eventData.position);
            playerPos.z = 0;
            transform.position = playerPos;
        }

    }

    /// <summary>
    /// ドラッグ終わりに呼び出される
    /// </summary>
    /// <param name="eventData"></param>
    public void OnEndDrag(PointerEventData eventData)
    {
        if (cb.play == false && cb.stop == false)
        {
            bool flg = true;

            var raycastResults = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, raycastResults);

            foreach (var hit in raycastResults)
            {
                if (hit.gameObject.CompareTag("NormalFloor"))
                {
                    transform.position = hit.gameObject.transform.position;
                    currentPosition = hit.gameObject.transform.position;
                    flg = false;
                    playerTest.Start();
                }
            }

            if (flg)
            {
                transform.position = prePosition;
            }
        }
    }

    void Update()
    {
        //Debug.Log(gameObject.transform.position);
    }
}
