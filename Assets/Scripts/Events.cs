using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
       
           
        
    }
    IEnumerator EventTimer()
    {
        while (true)
        {
            Debug.Log("Evento");
            yield return new WaitForSeconds(10);
        }
    }
}
