using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[RequireComponent(typeof(Camera))]
public class Snap : MonoBehaviour
{
    public Camera Cam;
    int with = 512;
    int height = 512;

    void Awake()
    {
        Cam = GetComponent<Camera>();
        if(Cam.targetTexture == null)
        {
            Cam.targetTexture = new RenderTexture(with, height, 24);
        }
        else
        {
            with = Cam.targetTexture.width;
            height = Cam.targetTexture.height;
        }
        Cam.gameObject.SetActive(false);
    }




    public Texture2D TakeSnap()
    {
        Cam.gameObject.SetActive(true);
       
        Texture2D snap = new Texture2D(with, height, TextureFormat.RGB24, false);
        Cam.Render();

        RenderTexture.active = Cam.targetTexture;
        snap.ReadPixels(new Rect(0, 0, with, height), 0, 0);
        snap.Apply();


        

        return snap;
    }

    

    

   
}
