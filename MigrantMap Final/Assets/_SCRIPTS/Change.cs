using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mapbox.Utils;
using Mapbox.Unity.Map;

public class Change : MonoBehaviour
{
    
    Dropdown m_Dropdown;
    float previouszoom;
    Vector2d previouscoords;

    // Start is called before the first frame update
    void Start()
    {
        //Fetch the Dropdown GameObject
        m_Dropdown = GetComponent<Dropdown>();

        //Add listener for when the value of the Dropdown changes, to take action
        m_Dropdown.onValueChanged.AddListener(delegate {
            DropdownValueChanged();
        });

        GameObject.Find("Heatmap Toggle").GetComponent<Toggle>().onValueChanged.AddListener(delegate {
            DropdownValueChanged();
        });

    }

    void DropdownValueChanged()
    {
        //quick change regions value
        GameObject regions = GameObject.Find("Regions");
        Dropdown dd = regions.GetComponent<Dropdown>();
        
        List <GameObject> objects= new List<GameObject>();
        objects.Add(GameObject.Find("2014"));
        objects.Add(GameObject.Find("2015"));
        objects.Add(GameObject.Find("2016"));
        objects.Add(GameObject.Find("2017"));
        objects.Add(GameObject.Find("2018"));
        objects.Add(GameObject.Find("2014-2018"));
        objects.Add(GameObject.Find("2014h"));
        objects.Add(GameObject.Find("2015h"));
        objects.Add(GameObject.Find("2016h"));
        objects.Add(GameObject.Find("2017h"));
        objects.Add(GameObject.Find("2018h"));
        objects.Add(GameObject.Find("2014-2018h"));

        foreach (GameObject obj in objects){
            if (obj.GetComponent<Transform>().position.x == 0)
            {
                previouszoom = obj.GetComponent<AbstractMap>().Zoom;
                previouscoords = obj.GetComponent<AbstractMap>().CenterLatitudeLongitude;
            }
            var tmptransform = obj.transform;
            var tmpposition = tmptransform.position;
            tmpposition.x=5000;
            tmptransform.position = tmpposition;
        }

        string text = m_Dropdown.options[m_Dropdown.value].text;
        if (GameObject.Find("Heatmap Toggle").GetComponent<Toggle>().isOn)
        {
            text += "h";
        }
        Debug.Log(text);
        GameObject gameobj = GameObject.Find(text);
        Transform transform = gameobj.transform;
        var position = transform.position;
        position.x = 0;
        transform.position = position;

        gameobj.GetComponent<AbstractMap>().UpdateMap(previouscoords, previouszoom);
    }
}
