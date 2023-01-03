using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllMap : MonoBehaviour
{
    /*public GameObject wall;
    public GameObject line;*/
    ArrayMaterials am;
    // Start is called before the first frame update
    void Start()
    {
        am = FindObjectOfType<ArrayMaterials>();
        gameObject.GetComponent<MeshRenderer>().materials[0] = am.mts[0].mt;
        /*gameObject.GetComponent<MeshRenderer>().materials[2] = am.mts[1].mt;*/
    }

    // Update is called once per frame
    void Update()
    {
        

    }
}
