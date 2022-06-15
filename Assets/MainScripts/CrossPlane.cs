using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CrossPlane : MonoBehaviour
{
  
    public VolumeRenderedObject targetObject;

    public Slider xSliderPos;
    public Slider ySliderPos;
    public Slider zSliderPos;

    public Slider xSliderRot;
    public Slider ySliderRot;
    public Slider zSliderRot;

    private void Start()
    {
       

        xSliderPos = GameObject.Find("XSliderPos").GetComponent<Slider>();
        ySliderPos = GameObject.Find("YSliderPos").GetComponent<Slider>();
        zSliderPos = GameObject.Find("ZSliderPos").GetComponent<Slider>();

        xSliderRot = GameObject.Find("RotSliderX").GetComponent<Slider>();
        ySliderRot = GameObject.Find("RotSliderY").GetComponent<Slider>();
        zSliderRot = GameObject.Find("RotSliderZ").GetComponent<Slider>();



    }


    private void OnDisable()
    {
        if (targetObject != null)
            targetObject.meshRenderer.sharedMaterial.DisableKeyword("CUTOUT_PLANE");
    }

    private void Update()
    {
        if (targetObject == null)
            return;

        Material mat = targetObject.meshRenderer.sharedMaterial;

        mat.EnableKeyword("CUTOUT_PLANE");
        mat.SetMatrix("_CrossSectionMatrix", transform.worldToLocalMatrix * targetObject.transform.localToWorldMatrix);

        this.transform.localPosition = new Vector3(xSliderPos.value, ySliderPos.value, zSliderPos.value);
        this.transform.localRotation = Quaternion.Euler(xSliderRot.value + 90f, ySliderRot.value, zSliderRot.value);
    }
}
