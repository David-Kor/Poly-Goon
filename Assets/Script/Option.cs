using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Option : MonoBehaviour {

    List<string> 해상도_list = new List<string>() { "800 x 600", "1024 x 768", "1280 x 600" };

    public Dropdown 해상도_Dropdown;

    public Text 해상도;
    public Text Volume_text;

    public Slider Volume_slider;

	void Start () {

        PopulateList();
	}

    void Update()
    {
    }

    // Update is called once per frame

    public void Dropdown_Change(int index)
    {
        index = 해상도_Dropdown.value;
        해상도.text = 해상도_list[index];
        switch(index)
        {
            case 0:
                Screen.SetResolution(800, 600, false);
                break;
            case 1:
                Screen.SetResolution(1024, 768, false);
                break;
            case 2:
                Screen.SetResolution(1280, 600, false);
                break;
        }
    }
    public void PopulateList()
    {
        해상도_Dropdown.AddOptions(해상도_list);
    }
    public void printSlider()
    {
        Volume_text.text = "볼륨: " + (Volume_slider.value*100).ToString("f0") + "%";
    }
}
