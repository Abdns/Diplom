using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class DropDownFile : MonoBehaviour
{
    public Dropdown FileSelect;
    public string FileName;
    void Start()
    {
        DirectoryInfo directoryInfo = new DirectoryInfo("C:/RawFiles");
        FileInfo[] fileInfo = directoryInfo.GetFiles("*.*", SearchOption.AllDirectories);
        FileSelect = GameObject.Find("File Selection").GetComponent<Dropdown>();
        FileSelect.options.Clear();

        foreach (FileInfo file in fileInfo)
        {
            Dropdown.OptionData optionData = new Dropdown.OptionData(file.Name);
            FileSelect.options.Add(optionData);
            FileSelect.value = 1;

        }

    }

    public void DropdownChanged()
    {
        FileName = FileSelect.options[FileSelect.value].text;
    }
}
