using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.XR.Interaction.Toolkit;


public class OpenNextJewelry : MonoBehaviour
{
    [SerializeField]
    List<MeshRenderer> jewelries;
    [SerializeField]
    List<XRSimpleInteractable> jewleryInteractor;

    int index = 1;
    // Start is called before the first frame update
    void Start()
    {
        jewelries = this.GetComponentsInChildren<MeshRenderer>().ToList();
        jewleryInteractor = this.GetComponentsInChildren<XRSimpleInteractable>().ToList();
        for (int i = 0; i < jewleryInteractor.Count; i++)
        {
            jewleryInteractor[i + 1].GetComponent<Collider>().enabled = false;
        }
    }

    public void ActivateNextJewelry()
    {
        if (index < jewelries.Count)
        {
            jewelries[index].enabled = true;
            jewleryInteractor[index].GetComponent<Collider>().enabled = true;
            index++;
        }
    }
}
