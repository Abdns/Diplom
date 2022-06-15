using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapZoom : MonoBehaviour
{
    
    private Vector3 StartPosition;
    private Vector3 StartScale;

    private bool isZoomed = false;



    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1) & isZoomed == false)
        {

            StartPosition = this.transform.localPosition;
            StartScale = this.transform.localScale;

            this.transform.localPosition = new Vector3(0,0,1.5f);
            this.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);

            isZoomed = true;
        }
        else if(Input.GetMouseButtonDown(1) & isZoomed == true)
        {
            this.transform.localPosition = StartPosition;
            this.transform.localScale = StartScale;

            isZoomed = false;
        }
    }
}
