using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.VFX;

public class Events : MonoBehaviour
{
    public GameObject Megamineral;
   
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EventTimer());

    }

    // Update is called once per frame
    void Update()
    {
       
           
        
    }
    IEnumerator EventTimer()
    {
        while (true)
        {
            Vector3 spawn = new Vector3(Random.Range(-7,7), Random.Range(-4, 4), 0);
            Debug.Log("Evento");
            Instantiate(Megamineral, spawn,Quaternion.identity);
            yield return new WaitForSeconds(10);
        }
    }
}
