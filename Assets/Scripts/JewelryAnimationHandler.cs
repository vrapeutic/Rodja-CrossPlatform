using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class JewelryAnimationHandler : MonoBehaviour
{
    [SerializeField]
    List<ParticleSystem> jewelryPartical;
    [SerializeField]
    List<Light> jewelryLight;

    int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        jewelryPartical = this.GetComponentsInChildren<ParticleSystem>().ToList();
        jewelryLight = this.GetComponentsInChildren<Light>().ToList();
        
    }

    public void RunEffect()
    {
        jewelryPartical[index].Play();
        jewelryLight[index].GetComponent<Light>().intensity = 1;
        index++;
    }
}
