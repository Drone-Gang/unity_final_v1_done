using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationFix : MonoBehaviour
{
    int F = 0;

    public GameObject g;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // hack the planet, pips r going down
        if(F < 20) {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, g.transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
            transform.position = g.transform.position;
            F++;
        }
        if(F == 20) {
            //transform.Rotate(0, 180, 0);
            F++;
        }


        
    }
}
