using UnityEngine;
using UnityEngine.UI;

    
public class SlicingPlane : MonoBehaviour
{
        public MeshRenderer meshRenderer;

        public Slider xSliderPos;
        public Slider ySliderPos;
        public Slider zSliderPos;

        public Slider xSliderRot;
        public Slider ySliderRot;
        public Slider zSliderRot;


    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();

        xSliderPos = GameObject.Find("XSliderPos").GetComponent<Slider>();
        ySliderPos = GameObject.Find("YSliderPos").GetComponent<Slider>();
        zSliderPos = GameObject.Find("ZSliderPos").GetComponent<Slider>();

        xSliderRot = GameObject.Find("RotSliderX").GetComponent<Slider>();
        ySliderRot = GameObject.Find("RotSliderY").GetComponent<Slider>();
        zSliderRot = GameObject.Find("RotSliderZ").GetComponent<Slider>();



    }

    private void Update()
    {
        meshRenderer.material.SetMatrix("_parentInverseMat", transform.parent.worldToLocalMatrix);
        meshRenderer.material.SetMatrix("_planeMat", Matrix4x4.TRS(transform.position, transform.rotation, transform.parent.lossyScale));
           
    }

       


}

