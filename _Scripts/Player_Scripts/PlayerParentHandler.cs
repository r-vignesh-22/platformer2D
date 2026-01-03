using UnityEngine;
using System.Collections;

public class PlayerParentHandler : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.TryGetComponent<MovingBlock>(out var block))
        {
            transform.SetParent(block.transform,true);
        }
    }
    void OnTriggerExit2D(Collider2D trigger)
    {
        if (trigger.gameObject.TryGetComponent<MovingBlock>(out var block))
        {
            StartCoroutine(ResetParentNextFrame());
        }
    }
    IEnumerator ResetParentNextFrame()
    {
        yield return null;
        transform.SetParent(null, true);
    }
}
