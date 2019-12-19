using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mapbox.Unity.Map;
using Mapbox.Utils;

public class Drag : MonoBehaviour
{
    Vector2d newcoords;
    float newzoom;
    void Update()
    {
        
        string text = GameObject.Find("Years").GetComponent<Dropdown>()
                                .options[GameObject.Find("Years").GetComponent<Dropdown>().value].text;
        if (GameObject.Find("Heatmap Toggle").GetComponent<Toggle>().isOn)
        {
            text += "h";
        }
        AbstractMap map = GameObject.Find(text).GetComponent<AbstractMap>();
        newzoom = map.Zoom;

        Vector2d mapvector2d = map.CenterLatitudeLongitude;
        Vector2 mapvector = new Vector2((float)mapvector2d.x, (float)mapvector2d.y);

        if (mapvector[1] < 60 * map.Zoom * (map.Zoom == 1 ? 1 : .7))
        {
            if (Input.GetKey(KeyCode.D))
            {
                mapvector[1] += 1f / map.Zoom;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                mapvector[1] += 1f / map.Zoom;
            }
        }

        if (mapvector[1] > -60 * map.Zoom * (map.Zoom == 1 ? 1 : .7))
        {
            if (Input.GetKey(KeyCode.A))
            {
                mapvector[1] += -1f / map.Zoom;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                mapvector[1] += -1f / map.Zoom;
            }
        }
        if (mapvector[0] < 60 * map.Zoom * (map.Zoom == 1 ? 1 : 2f * (map.Zoom - 1)))
        {
            if (Input.GetKey(KeyCode.W))
            {
                mapvector[0] += 1f / map.Zoom;
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                mapvector[0] += 1f / map.Zoom;
            }
        }
         
        if (mapvector[0] > -60 * map.Zoom * (map.Zoom==1 ? 1 : 2f * (map.Zoom - 1)))
        {
            if (Input.GetKey(KeyCode.S))
            {
                mapvector[0] += -1f / map.Zoom;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                mapvector[0] += -1f / map.Zoom;
            }
        }

        var scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll < 0)
        {
            if(map.Zoom > 1)
            {
                newzoom += -.1f;
            }
        }
        else if(scroll > 0)
        {
            if (map.Zoom <10)
            {
                newzoom += .1f;
            }
        }




        newcoords = new Vector2d(mapvector[0], mapvector[1]);
        map.UpdateMap(newcoords, newzoom);

    }
}
