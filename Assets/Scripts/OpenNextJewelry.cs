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

    void Start()
    {
        jewelries = this.GetComponentsInChildren<MeshRenderer>().ToList();
        Debug.Log(jewelries.Count);

        jewleryInteractor = this.GetComponentsInChildren<XRSimpleInteractable>().ToList();
        for (int i = 0; i < jewleryInteractor.Count - 1; i++)
        {
            jewleryInteractor[i + 1].GetComponent<Collider>().enabled = false;
        }

    }

    public void ActivateNextJewelry()
    {
        Debug.Log(index);

        if (index < jewelries.Count)
        {
           
            jewleryInteractor[index-1].GetComponent<Collider>().enabled = true;

        }  
       
    }
    public void AfterAgentArrived()
    {
        Debug.Log(index);

        if (index < jewelries.Count)
        {
           jewelries[index].enabled = true;
            RunEffect();
            index++;
        }
      
    }
    public void RunEffect()
    {
        jewelries[index-1].gameObject.GetComponentInChildren<Light>().enabled = true;

        if (index > 0)
        {
            jewelries[index - 1].gameObject.GetComponentInChildren<ParticleSystem>().Play();
            jewelries[index - 1].gameObject.GetComponentInChildren<ScaleHandler>().ScaleJewelry();

        }
    }

    public void StopJewlMove()
    {
        List<ObjectMovement> jewelries = this.GetComponentsInChildren<ObjectMovement>().ToList();

        jewelries[index - 1].gameObject.GetComponentInChildren<ScaleHandler>().CloseInteractor();

        if (FindObjectOfType<MenuManger>().menu.level == 3)
        {
            List<ObjectMovement> _jewelries = this.GetComponentsInChildren<ObjectMovement>().ToList();
            _jewelries[index - 1].gameObject.GetComponent<ObjectMovement>().Stop();
            Debug.Log(index + " " + _jewelries.Count);
        }
    }
}
