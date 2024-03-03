using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [Header("Animation and movement")]
    [SerializeField] 
    private Transform plant;
    [SerializeField] 
    private Transform plantTarget;
    [SerializeField] 
    private Transform manure;
    [SerializeField] 
    private float manureIncrement;
    [SerializeField] 
    private float walkSpeed;
    [SerializeField] 
    private float rollSpeed;

    [Header("Gameplay")]
    [SerializeField]
    private float lives;
    [SerializeField]
    private List<GameObject> meshes;
    [SerializeField]
    private int blinkTimes;
    [SerializeField]
    private int score;

    private bool isTakingDamage;

    private float manureSize = 0;

    private NavMeshAgent agent;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = plant.GetChild(0).GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float agentVelocity = agent.velocity.magnitude;

        anim.speed = agentVelocity * walkSpeed;
        manure.Rotate(Vector3.right * agentVelocity * rollSpeed * Time.deltaTime);

        manureSize += agentVelocity * manureIncrement * Time.deltaTime;
        manure.parent.transform.localScale = Vector3.one * manureSize;
        plant.transform.position = plantTarget.position;

    }

    public IEnumerator TakeDamage(float amount)
    {
        isTakingDamage = true;

        lives -= amount;

        if (lives <= 0)
        {
            GameManager.Instance.UpdateScore();

            Destroy(gameObject);
            yield break;
        }

        meshes.ForEach(x => x.SetActive(false));

        for (int i = 1; i <= blinkTimes; i++)
        {
            var activeMesh = meshes[i % meshes.Count];

            activeMesh.SetActive(true);

            yield return new WaitForSeconds(0.25f);

            activeMesh.SetActive(false);
        }

        meshes.ForEach(x => x.SetActive(false));

        meshes[0].SetActive(true);

        isTakingDamage = false;
    }

    public bool IsTakingDamage { get => isTakingDamage; }
    public int Score { get => score; }
}
