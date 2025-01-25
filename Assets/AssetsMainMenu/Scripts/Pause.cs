using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;
    // Start is called before the first frame update
    public void PauseGame()
    {
        if (Time.timeScale == 1.0f)
        {
            Time.timeScale = 0.0f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        { 
            if(pausePanel.activeInHierarchy )
            {
                pausePanel.SetActive(false);
               
            }
            else
            {
                pausePanel.SetActive(true);
                
            }
            PauseGame();
           
        }
    }
}
