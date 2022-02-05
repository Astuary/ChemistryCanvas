using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class Element : MonoBehaviour
{
    public string symbol = "";
    [Space(5)]

    public bool isReactive = false;
    public List<GameObject> molecules = new List<GameObject>();
    [Space(5)]

    [HideInInspector] public bool reacted = false;

    [HideInInspector] public GameObject atom = null;
    //[HideInInspector] public List<Trigger> triggers = null;
    [HideInInspector] public Trigger[] triggers = null;
    [HideInInspector] public Dictionary<string, GameObject> reactions = new Dictionary<string, GameObject>();

    [HideInInspector] public List<string> symbols;

    private void Start()
    {
        // Setup rigidbody
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.useGravity = false;
        rigidbody.isKinematic = true;

        // Get atom gameobject (always first in tree, so index = 0)
        atom = transform.GetChild(0).gameObject;


        // Build reactions dictionary
        foreach (var molecule in molecules)
            reactions.Add(molecule.name, molecule);
    } 
}