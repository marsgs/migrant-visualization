using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Graph : MonoBehaviour
{
    public GameObject TextPrefab;
    public GameObject BarPrefab;
    public Dictionary<string, int> causes = new Dictionary<string, int>();
    public List<GameObject> barlist = new List<GameObject>();
    public List<GameObject> textlist = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        causes.Add("Drowning", 1331);
        causes.Add("Unknown", 1054);
        causes.Add("Health Condition", 938);
        causes.Add("Vehicle Accident", 781);
        causes.Add("Murdered", 376);
        causes.Add("Starvation", 226);
        causes.Add("Dehydration", 144);
        causes.Add("Hyperthermia", 118);
        causes.Add("Harsh Conditions", 98);
        causes.Add("Hypothermia", 82);
        causes.Add("Asphyxiation", 64);
        causes.Add("Mixed", 27);
        causes.Add("Harsh conditions", 25);
        causes.Add("Exposure", 24);
        causes.Add("Electrocution", 12);
        causes.Add("Stabbed", 9);
        causes.Add("Fallen", 8);
        causes.Add("Burned", 7);
        causes.Add("Killed by animals", 3);
        causes.Add("Crushed", 3);
        causes.Add("Suicide", 3);

        GenerateBars();

        Toggle toggle = gameObject.GetComponent<Toggle>();
        toggle.onValueChanged.AddListener(delegate {
            if (toggle.isOn)
            {
                GenerateBars();
            }
            else
            {
                DestroyBars();
            }
        });

    }

    // Update is called once per frame
    void Update()
    {

    }
    //WOAH DUDE RIZZLE WOWOWOWOW

    

    void GenerateBars()
    {
        barlist.Clear();
        textlist.Clear();
        int i = 0;
        foreach (KeyValuePair<string, int> cause in causes)
        {
            // for Bar prefeb
            Vector3 tarPos = new Vector3(BarPrefab.transform.position.x-15+(i * 3), 0, BarPrefab.transform.position.z-10+((cause.Value / 20f) / 2));
            GameObject p = Instantiate(BarPrefab, tarPos, Quaternion.identity);
            p.transform.localScale = new Vector3(p.transform.localScale.x,
                p.transform.localScale.y*cause.Value/20f,
                p.transform.localScale.z); ;
            p.transform.rotation = BarPrefab.transform.rotation;
            barlist.Add(p);

            Vector3 tarPos2 = new Vector3(0f, 0f, 0f);
            GameObject txt = Instantiate(TextPrefab, tarPos2, TextPrefab.transform.rotation);
            txt.transform.SetParent(GameObject.Find("Canvas").transform);
            tarPos2 = new Vector3(573f+(i*20.2f), 33f, 0f);
            txt.transform.position = tarPos2;
            txt.GetComponent<Text>().text = cause.Key;
            textlist.Add(txt);


            i++;
        }
    }

    void DestroyBars()
    {
        foreach (GameObject bar in barlist)
        {
            bar.Destroy();
        }
        foreach(GameObject txt in textlist)
        {
            txt.Destroy();
        }
    }


}
