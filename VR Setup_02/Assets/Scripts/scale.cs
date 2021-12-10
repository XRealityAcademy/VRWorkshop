using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class scale : MonoBehaviour
{
    public Vector2 topCorners;

    public Vector2 bottomCorners;

    
    private void OnValidate()
    {
        var scaleVector = Vector2.zero - topCorners - bottomCorners;
        var isNegative = scaleVector.x < 0 || scaleVector.y < 0; 
        var scaleBy = scaleVector.magnitude;
        if (isNegative)
        {
            scaleBy = -scaleBy; 
        }

        Vector3 anchorPoint = new Vector3();

        var currentPosition = transform.position;
        var currentScale = transform.localScale;

        if (topCorners.y != 0)
        {
            anchorPoint.x = currentPosition.x - currentScale.x/2.0f;
            anchorPoint.y = currentPosition.y - currentScale.y/2.0f; 
        }

        if (topCorners.x != 0)
        {
            anchorPoint.x = currentPosition.x + currentScale.x/2.0f;
            anchorPoint.y = currentPosition.y - currentScale.y/2.0f; 
        }

        ScaleTheQuadWithNewAnchorPoint(anchorPoint, scaleBy);
        topCorners = Vector2.zero;
        bottomCorners = Vector2.zero; 
    }

    public GameObject container; 
    private void ScaleTheQuadWithNewAnchorPoint(Vector3 anchorPoint,float scaleBy)
    {
        //transform.localScale += Vector3.one * scaleBy; 

        container.transform.position = anchorPoint;
        transform.parent = container.transform;
        container.transform.localScale += Vector3.one * scaleBy;
        
        
        container.transform.DetachChildren();
      //  container.transform.position = transform.position;
       // container.transform.localScale = Vector3.one; 

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(container.transform.position,1);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
