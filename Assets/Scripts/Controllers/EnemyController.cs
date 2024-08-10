using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private AudioClip damageAudio;
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float waypointStoppingDistance = 0.2f;

    private float currentHealth;
    private AudioSource audioSource;
    private Transform target;
    private NavMeshAgent agent;
    public int currentWaypointIndex = 0;
    public float lookRadius = 5f;


    private void Start()
    {
        target = PlayerController.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        currentHealth = maxHealth;
        audioSource = GetComponent<AudioSource>();

        StartCoroutine(RotateBetweenWaypoints());
    }

    private void Update()
    {
        if (IsPlayerInSightRadius())
        {
            ChasePlayer();
        }        
    }

    private bool IsPlayerInSightRadius()
    {
        float distance = Vector3.Distance(transform.position, target.position);
        return distance <= lookRadius;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(target.position);
        if (Vector3.Distance(transform.position, target.position) <= agent.stoppingDistance)
        {
            FaceTarget();
        }
    }
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private IEnumerator RotateBetweenWaypoints()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);

            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            agent.SetDestination(waypoints[currentWaypointIndex].position);
        }
    }

    

    public void TakeDamage (int damageAmount)
    {
        currentHealth -= damageAmount;
        Debug.Log("Enemy Health: " + currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        SoundFXManager.Instance.PlaySoundFXClip(damageAudio, transform, 0.2f);
        Debug.Log("Enemy died");
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}