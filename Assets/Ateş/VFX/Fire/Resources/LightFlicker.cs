using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{

    [SerializeField] private Light lightSource;
    [SerializeField] private float min, max, intensityMultiplier, flickerInterval;


    void Start()
    {
        StartCoroutine(Flicker(this.flickerInterval));    
    }

   private IEnumerator Flicker(float interval){
        while(interval > 0){
            yield return new WaitForSeconds(interval);
            lightSource.intensity = Random.Range(min, max) * intensityMultiplier;
        }
        while(interval <= 0){
            yield return null;
            lightSource.intensity = Random.Range(min, max) * intensityMultiplier;
        }
   }
}
