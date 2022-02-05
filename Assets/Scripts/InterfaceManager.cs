using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceManager : MonoBehaviour
{

    public Text txt;

    public void React()
    {
        foreach (KeyValuePair<string, GameObject> element in TapToPlace.objects)
        {
            Element e = element.Value.GetComponent<Element>();//.React();
            //Trigger[] triggers = e.GetComponentsInChildren<Trigger>(true);
            if (e.isReactive)
            {
                /*
                e.reacted = true;

                

                List<string> symbols = new List<string>();
                txt.text = "";
                foreach (var symbol in triggers)
                {
                    txt.text = txt.text + "\n" + symbol.ToString();
                    //txt.text = txt.text + "\n" + symbol.m_element.symbol.ToString();
                    symbols.Add(symbol.m_element.symbol.ToString());
                }
                */
                GameObject atom = e.transform.GetChild(0).gameObject;
                   
                // H2O
                //if (symbols[0] == "H" && symbols[1] == "H")
                //{
                //    txt.text = txt.text + "";
                    atom.SetActive(false);
                    foreach (KeyValuePair<string, GameObject> ele in TapToPlace.objects)
                    {
                        //if (ele.Key.ToString() != "Oxygen1")
                        if (ele.Key.ToString() != "Carbon1")
                        {
                            ele.Value.gameObject.SetActive(false);
                        }
                    }
                    //triggers[0].m_element.atom.SetActive(false);
                    //triggers[1].m_element.atom.SetActive(false);

                    //reactions["H2O"].SetActive(true);
                    //txt.text = txt.text + "\n" + e.ToString();
                    //e.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.SetActive(true);
                    e.transform.GetChild(1).gameObject.transform.GetChild(1).gameObject.SetActive(true);
                //}

                
            }

        }
    }

    public void Reset()
    {
        foreach (KeyValuePair<string, GameObject> element in TapToPlace.objects)
        {
            Destroy(element.Value);
        }
        TapToPlace.objects.Clear();
    }
}