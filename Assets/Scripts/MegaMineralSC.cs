using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MegaMineralSC : MonoBehaviour
{
    int rng;
    
    public int mineralMultiplier = 100;

    

   
    private void OnMouseUpAsButton()
    {
        RandomEffect();
        Destroy(gameObject);
    }

    //mouseenter y exit sirven para efectos de hover como hacer el objeto mas grande o que brille
    private void OnMouseEnter()
    {
        gameObject.transform.localScale = new Vector3(3.2f, 3.2f, 3.2f);
    }

    private void OnMouseExit()
    {
        gameObject.transform.localScale = new Vector3(3f, 3f, 3f);
    }
    public void RandomEffect()
    {
    rng = Random.Range(1, 10);
        switch (rng) 
        { 
        case 1:
                RandomSpawnEvent(Clicker.instance.Dmoney);
                break;
        case 2:

                RandomSpawnEvent(Clicker.instance.DPunish);
                Debug.Log("Punish");
                break;
        case 3:
                StartCoroutine(MultiplierBonus());
                break;
        case 4:
                BonusMoney();
                break;
        case 5:
                
                RandomSpawnEvent(Clicker.instance.Dmoney);
                break;
        case 6:
                for (int i = 0; i < 3; i++)
                    RandomSpawnEvent(Clicker.instance.DPunish);
                Debug.Log("Punish");
                break;
        case 7:
                BonusMoney();
                break;
        case 8 :
                BonusMoney();
                break;
        case 9:
                BonusMoney();
                break;
        case 10: for (int i = 0; i < 8; i++)
                {
                    int goodOrBad = Random.Range(1, 2);
                    if (goodOrBad == 1)
                    RandomSpawnEvent(Clicker.instance.Dmoney);
                    else
                    RandomSpawnEvent(Clicker.instance.DPunish);
                }
                Debug.Log("Jackpot");
        RandomSpawnEvent(Clicker.instance.MegaMineral);
                break;




        default:
                BonusMoney();
                break;
        
        
        }
    }
    public void BonusMoney()
    {
        Money.instance.money += Clicker.instance.moneyGained * 100;
    }
    IEnumerator MultiplierBonus()
    {
        float basemultiplier=Money.instance.multiplier;
        Money.instance.multiplier = 5;
        
        yield return new WaitForSeconds(10);
        Money.instance.multiplier = basemultiplier;
    }
        
    void RandomSpawnEvent(GameObject spawnObject)
    {
        Vector3 spawn = new Vector3(Random.Range(-7, 7), Random.Range(-4, 4), 0);
        Debug.Log("EventoSpawn");
        Instantiate(spawnObject, spawn, Quaternion.identity);
    }
            
    
}
