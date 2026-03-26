using System;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.EventSystems;

public class pointerscriprleftcopy : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public static bool ispressed = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        ispressed = true;
        Debug.Log("pressed");
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        ispressed = false;
        Debug.Log("realised");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
