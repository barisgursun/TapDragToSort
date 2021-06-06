using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drag : MonoBehaviour
{
    public delegate void DragEndedDelegate(drag draggableObject);

    public DragEndedDelegate dragEndedCallback;

    private bool isDrag = false;
    private Vector3 mouseDragStartPosition;
    private Vector3 spriteDragStartPosition;

    private void OnMouseDown()
    {
        isDrag = true;
        mouseDragStartPosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        spriteDragStartPosition = transform.position;

    }
    private void OnMouseDrag()
    {
        
        if(isDrag)
        {
            transform.localPosition = spriteDragStartPosition + (Camera.main.ScreenToWorldPoint(Input.mousePosition) - mouseDragStartPosition);
        }
    }

    private void OnMouseUp()
    {
        isDrag = false;
        dragEndedCallback(this);
    }
}
