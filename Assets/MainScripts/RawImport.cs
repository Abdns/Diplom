
using UnityEngine;
using System.IO;



public class RawImport 
{

    [SerializeField]
    static public int dimX = 128, dimY = 256, dimZ = 256;
 
    public static VolumeObjDataset import(string name)
    {
        FileStream fs = new FileStream("C:/RawFiles" + "/" + name, FileMode.Open);
        BinaryReader reader = new BinaryReader(fs);

        VolumeObjDataset dataset = new VolumeObjDataset();
        
        dataset.dimX = dimX;
        dataset.dimY = dimY;
        dataset.dimZ = dimZ;

        int uDimension = dimX * dimY * dimZ;
        dataset.data = new int[uDimension];

        
        for (int i = 0; i < uDimension; i++)
        {
            dataset.data[i] = (int)reader.ReadByte();
        }

        reader.Close();
        fs.Close();

        return dataset;       
    }
}
