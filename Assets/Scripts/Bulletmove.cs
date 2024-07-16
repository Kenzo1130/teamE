using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletmove : MonoBehaviour
{
    [SerializeField] public float speed = -1.0f; //’e‚Ì‚Í‘¬‚³

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime); // yŽ²•ûŒü‚ÉˆÚ“®
                                                                  
       
    }

   
}
