using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keys : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<Toggle>().isOn)
        {
            //if(!yearkey.activeSelf)
            {
                GameObject.Find("Year Key").GetComponent<RawImage>().color = Color.white;
                GameObject.Find("Region Key").GetComponent<RawImage>().color = Color.white;
            }
        }

        if (!gameObject.GetComponent<Toggle>().isOn)
        {
            //if (yearkey.activeSelf)
            {
                GameObject.Find("Year Key").GetComponent<RawImage>().color = Color.clear;
                GameObject.Find("Region Key").GetComponent<RawImage>().color = Color.clear;
            }
        }
    }
}
