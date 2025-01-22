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
        gameObject.transform.localScale = new Vector3(1.2f,1.2f,1.2f);
    }

    private void OnMouseExit()
    {
        gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
    }
    public void RandomEffect()
    {
    rng = Random.Range(1, 10);
        switch (rng) 
        { 
        case 1:
                BonusMoney();
                break;
        case 2:
                BonusMoney();
                break;
        case 3:
                StartCoroutine(MultiplierBonus());
                break;
        case 4:
                BonusMoney();
                break;
        case 5:
                BonusMoney();
                break;
        default:
                BonusMoney();
                break;
        
        
        }
    }
    public void BonusMoney()
    {
        Money.instance.money += Clicker.instance.moneyGained * 500;
    }
    IEnumerator MultiplierBonus()
    {
        float basemultiplier=Money.instance.multiplier;
        Money.instance.multiplier = 5;
        
        yield return new WaitForSeconds(10);
        Money.instance.multiplier = basemultiplier;
    }
        
           
            
    
}
