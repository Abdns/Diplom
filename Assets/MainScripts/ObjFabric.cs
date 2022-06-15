using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjFabric 
{
    public static VolumeRenderedObject CreateObject(VolumeObjDataset dataset)
    {
        GameObject outerObject = new GameObject("VolumeRenderedObject_" );
        outerObject.transform.position = new Vector3(0,0,3f);
        outerObject.AddComponent<ModelAxisController>();
        
        VolumeRenderedObject volObj = outerObject.AddComponent<VolumeRenderedObject>();

       
       
        GameObject meshContainer = GameObject.Instantiate((GameObject)Resources.Load("VolumeContainer"));
        meshContainer.transform.parent = outerObject.transform;
        meshContainer.transform.localScale = Vector3.one;
        meshContainer.transform.localPosition = Vector3.zero;
        meshContainer.transform.parent = outerObject.transform;
        outerObject.transform.localRotation = Quaternion.Euler(90.0f, 0.0f, 0.0f);

        MeshRenderer meshRenderer = meshContainer.GetComponent<MeshRenderer>();
        meshRenderer.material = new Material(meshRenderer.material);
        volObj.meshRenderer = meshRenderer;
        volObj.dataset = dataset;

        const int noiseDimX = 512;
        const int noiseDimY = 512;
        Texture2D noiseTexture = NoiseTextureGenerator.GenerateNoiseTexture(noiseDimX, noiseDimY);

        TransferFunction tf = TransferFunctionDatabase.CreateTransferFunction();
        Texture2D tfTexture = tf.GetTexture();
        volObj.transferFunction = tf;

        TransferFunction2D tf2D = TransferFunctionDatabase.CreateTransferFunction2D();
        volObj.transferFunction2D = tf2D;

        meshRenderer.material.SetTexture("_DataTex", dataset.GetDataTexture());
        meshRenderer.material.SetTexture("_GradientTex", null);
        meshRenderer.material.SetTexture("_NoiseTex", noiseTexture);
        meshRenderer.material.SetTexture("_TFTex", tfTexture);

        meshRenderer.material.EnableKeyword("MODE_DVR");
        meshRenderer.material.DisableKeyword("MODE_MIP");
        meshRenderer.material.DisableKeyword("MODE_SURF");

        if (dataset.scaleX != 0.0f && dataset.scaleY != 0.0f && dataset.scaleZ != 0.0f)
        {
            float maxScale = Mathf.Max(dataset.scaleX, dataset.scaleY, dataset.scaleZ);
            volObj.transform.localScale = new Vector3(dataset.scaleX / maxScale, dataset.scaleY / maxScale, dataset.scaleZ / maxScale);
        }
       
        return volObj;
    }
}
