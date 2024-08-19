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

        Points pointsScript = FindObjectOfType<Points>();
        if (pointsScript != null)
        {
            pointsScript.UpdatePointsText();
        }

        Destroy(gameObject);
    }
}
