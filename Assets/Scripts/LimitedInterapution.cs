using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitedInterapution : MonoBehaviour
{

    private void Start()
    {
        StartCoroutine(PlayerTracker());
    }

    public IEnumerator PlayerTracker()
    {
        while (true)
        {

            if (!this.GetComponentInChildren<Renderer>().IsVisibleFrom(Camera.main))
            {
                TovaDataGet.ReturnTovaData().SetTargetsCounterEnabled(true);
            }
            yield return new WaitForSeconds(3);

        }
    }
}
