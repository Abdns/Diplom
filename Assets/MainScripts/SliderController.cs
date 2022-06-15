using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public Slider xSliderPos;
    public Slider ySliderPos;
    public Slider zSliderPos;

    public Slider xSliderRot;
    public Slider ySliderRot;
    public Slider zSliderRot;

    
    void Start()
    {
        xSliderPos = GameObject.Find("XSliderPos").GetComponent<Slider>();
        ySliderPos = GameObject.Find("YSliderPos").GetComponent<Slider>();
        zSliderPos = GameObject.Find("ZSliderPos").GetComponent<Slider>();

        xSliderRot = GameObject.Find("RotSliderX").GetComponent<Slider>();
        ySliderRot = GameObject.Find("RotSliderY").GetComponent<Slider>();
        zSliderRot = GameObject.Find("RotSliderZ").GetComponent<Slider>();

    }

   
    void Update()
    {
        this.transform.localPosition = new Vector3(xSliderPos.value, ySliderPos.value, zSliderPos.value);
        this.transform.localRotation = Quaternion.Euler(xSliderRot.value, ySliderRot.value, zSliderRot.value);


    }
}
