using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trigger : MonoBehaviour
{

    [HideInInspector] public Element m_element;
    private Text txt;

    private void OnTriggerEnter(Collider other)
    {
        if (!m_element)
        {
            m_element = other.GetComponentInParent<Element>();
            m_element.symbols.Add("L");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (m_element) m_element = null;
    }
}