using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mapbox.Unity.Map;

public class UpdateZoom : MonoBehaviour
{
    Dropdown dropdown;
    Slider slider;
    string txt;
    // Start is called before the first frame update
    void Start()
    {
        dropdown = GameObject.Find("Years").GetComponent<Dropdown>();
        slider = gameObject.GetComponent<Slider>();

        slider.onValueChanged.AddListener(delegate {
            ApplyZoom();
        });
    }

    // Update is called once per frame
    void Update()
    {
        txt = dropdown.options[dropdown.value].text;
        if (GameObject.Find("Heatmap Toggle").GetComponent<Toggle>().isOn)
        {
            txt += "h";
        }
        GameObject.Find("Zoom Amount").GetComponent<Text>().text =
            GameObject.Find(txt).GetComponent<AbstractMap>().Zoom.ToString();

        slider.value = GameObject.Find(txt)
                .GetComponent<AbstractMap>().Zoom;
    }

    void ApplyZoom()
    {
        txt = dropdown.options[dropdown.value].text;
        if (GameObject.Find("Heatmap Toggle").GetComponent<Toggle>().isOn)
        {
            txt += "h";
        }
        AbstractMap map = GameObject.Find(txt).GetComponent<AbstractMap>();

        map.UpdateMap(map.CenterLatitudeLongitude, slider.value);
    }
}
