using UnityEngine;

public class RotatingObject : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 100f;
    private float multiplier = 10f;

    private void Update()
    {
        transform.Rotate(0f, 0f, rotationSpeed * multiplier * Time.deltaTime);
       
    }

   
}
