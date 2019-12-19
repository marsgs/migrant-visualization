using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mapbox.Utils;
using Mapbox.Unity.Map;

public class Travel : MonoBehaviour
{
    public Dictionary<string, Vector2d> locations = new Dictionary<string, Vector2d>();
    public Dictionary<string, float> zooms = new Dictionary<string, float>();
    Dropdown m_Dropdown;
    public string text;
    // Start is called before the first frame update
    void Start()
    {
        text = "--";
        locations.Add("--", new Vector2d(24.162, 4.224));
        locations.Add("US-Mexico Border", new Vector2d(30.814, -105.834));
        locations.Add("North Africa", new Vector2d(26.848, 13.989));
        locations.Add("Mediterranean", new Vector2d(39.338, 15.580));
        locations.Add("Sub Saharan Africa", new Vector2d(-4.966, 23.444));
        locations.Add("Central America", new Vector2d(14.236, -79.213));
        locations.Add("Europe", new Vector2d(50.041, 13.260));
        locations.Add("Middle East", new Vector2d(31.288, 48.435));
        locations.Add("South Asia", new Vector2d(18.750, 89.284));

        zooms.Add("--", 1f);
        zooms.Add("US-Mexico Border", 4.5f);
        zooms.Add("North Africa", 3f);
        zooms.Add("Mediterranean", 4f);
        zooms.Add("Sub Saharan Africa", 3f);
        zooms.Add("Central America", 3f);
        zooms.Add("Europe", 3f);
        zooms.Add("Middle East", 3f);
        zooms.Add("South Asia", 3f);


        //Fetch the Dropdown GameObject
        m_Dropdown = GetComponent<Dropdown>();

        //Add listener for when the value of the Dropdown changes, to take action
        m_Dropdown.onValueChanged.AddListener(delegate {
            DropdownValueChanged();
        });
    }

    // Update is called once per frame
    void DropdownValueChanged()
    {
        text = m_Dropdown.options[m_Dropdown.value].text;

        
        GameObject mapdropdownobj = GameObject.Find("Years");
        Dropdown mapdropdown = mapdropdownobj.GetComponent<Dropdown>();
        string maptext = mapdropdown.options[mapdropdown.value].text;
        if (GameObject.Find("Heatmap Toggle").GetComponent<Toggle>().isOn)
        {
            maptext += "h";
        }

        GameObject mapobj = GameObject.Find(maptext);
        AbstractMap map = mapobj.GetComponent<AbstractMap>();

        Vector2d coords = locations[text];
        float zoom = zooms[text];
        map.UpdateMap(coords, zoom);
        
    }
}
