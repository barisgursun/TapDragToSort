using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snapcontroller : MonoBehaviour
{

    public List<Transform> snapPoints;
    public List<drag> draggbleObjects;
    public float snapRange = 0.5f;
    // Start is called before the first frame update

    void Start()
    {
 
    }

    private void OnDragEnded(drag draggable)
    {
        float closestDistance = -1;
        Transform closestSnapPoint = null;

        foreach(Transform snapPoint in snapPoints)
        {
            float currentDistance = Vector2.Distance(draggable.transform.localPosition, snapPoint.localPosition);
            if(closestSnapPoint == null || currentDistance < closestDistance)
            {
                closestSnapPoint = snapPoint;
                closestDistance = currentDistance;
            }
        }
        if (closestSnapPoint != null && closestDistance <= snapRange)
        {
            draggable.transform.localPosition = closestSnapPoint.localPosition;
        }
    }
}
