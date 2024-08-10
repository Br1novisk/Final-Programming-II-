using OpenCover.Framework.Model;
using UnityEngine;

public class Collectable : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Collect();

        }
    }

    protected virtual void Collect()
    {
        GameManager.Instance.getCollectable();        
        Destroy(gameObject);
    }
}