using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class JewelryAnimationHandler : MonoBehaviour
{
    [SerializeField]
    List<ParticleSystem> jewelryPartical;
    [SerializeField]
    List<Light> jewelrLight;

    int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        jewelryPartical = this.GetComponentsInChildren<ParticleSystem>().ToList();
        jewelrLight = this.GetComponentsInChildren<Light>().ToList();
    }

    public void RunEffect()
    {
        jewelryPartical[index].Play();
        jewelrLight[index].enabled = false;
        
        if(index + 1 < jewelrLight.Count) jewelrLight[index+1].enabled = true;
        index++;
    }
}
