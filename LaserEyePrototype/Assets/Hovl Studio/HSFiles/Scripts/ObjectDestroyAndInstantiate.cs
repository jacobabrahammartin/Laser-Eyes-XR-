using UnityEngine;

public class ObjectDestroyAndInstantiate : MonoBehaviour
{
    public GameObject objectToInstantiate; // Prefab to instantiate upon destruction
    public bool isDestroyable = true; // Whether this object is destroyable or not

    private void OnDestroy()
    {
        if (isDestroyable)
        {
            Instantiate(objectToInstantiate, transform.position, transform.rotation);
        }
    }
}