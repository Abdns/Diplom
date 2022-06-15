using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.SceneManagement;


public class Main : MonoBehaviour
{
  

    VolumeObjDataset dataset;
    VolumeRenderedObject VolumeObj;

    public Camera MainCam;

    public GameObject SnapCamera;
    public Snap SnapCameraComp;
   

    SlicingPlane SlicePlane;

    public GameObject ViePlane;
    public Renderer ViePlaneRend;

    private List<GameObject> ViePlaneList = new List <GameObject>();
    private List<Renderer> ViePlaneRendererList = new List<Renderer>();
    private List<Texture2D> TexToExportList = new List<Texture2D>();

    private int A = 0;

    private GameObject CrossPlane;



    
    public void CreateObj()
    {
         String FileName = GameObject.Find("File Selection").GetComponent<DropDownFile>().FileName;
         dataset = RawImport.import(FileName);
         VolumeObj =  ObjFabric.CreateObject(dataset);
       
    }

    


    public void AddPlane()
    {
        SlicePlane = VolumeObj.CreateSlicingPlane();
        

        SnapCamera = GameObject.Instantiate(Resources.Load<GameObject>("SnapCamera"));
        SnapCameraComp = SnapCamera.GetComponent<Snap>();

        SnapCamera.transform.parent = SlicePlane.transform;
        SnapCamera.transform.localPosition = new Vector3(0, -8.7f, 0);
        SnapCamera.transform.localRotation = Quaternion.Euler(-90, 0, 0);
        SnapCamera.transform.localScale = Vector3.one * 0.1f;


        CrossPlane = GameObject.Instantiate((GameObject)Resources.Load("CrossPlane"));
        CrossPlane.transform.parent = VolumeObj.transform;
        CrossPlane.transform.localPosition = Vector3.zero;
        CrossPlane.transform.localRotation = Quaternion.identity;

        CreateViePlanes();

        CrossPlane csplane = CrossPlane.gameObject.GetComponent<CrossPlane>();
        csplane.targetObject = VolumeObj;
      
    }

    public void CreateViePlanes()
    {
        float j = 1.2f;
        for (int i = 0; i < 3; i++)
        {
            ViePlaneList.Add(GameObject.Instantiate(Resources.Load<GameObject>("ViePlane")));
            ViePlaneRendererList.Add(ViePlaneList[i].GetComponent<Renderer>());
            ViePlaneList[i].transform.parent = MainCam.transform;
            ViePlaneList[i].transform.localPosition = new Vector3(-2.5f, j, 3f);
            ViePlaneList[i].transform.localRotation = Quaternion.Euler(90, -180, 0);

            j -= 1.1f;
        }
    }

    public void SlicePlaneVisible(bool value)
    {
        SlicePlane.gameObject.SetActive(value);    
    }
    public void CrossPlaneVisible(bool value)
    {
        CrossPlane.gameObject.SetActive(value);
    }
    public void LightRender(bool value)
    {
        VolumeObj.SetLightingEnabled(value);
    }


    public void TakeSnap()
    {
        ViePlaneRendererList[A].material.mainTexture = SnapCameraComp.TakeSnap();
        TexToExportList.Add(SnapCameraComp.TakeSnap());
        A++;

        if(A == 3)
        {
            A = 0;
        }
    }

    public void ExportSnaps()
    {
        for (int i = 0; i < TexToExportList.Count; i++)
        {
            byte[] itemBGBytes = TexToExportList[i].EncodeToPNG();
            string fileName = String.Format("c:/test/snap{0}.png", i);

            File.WriteAllBytes(fileName, itemBGBytes);

        }
       
    }

    public void Exit()
    {
        Application.Quit();
    }
       

}
