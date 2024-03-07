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
    private List<SkinnedMeshRenderer> meshes;
    [SerializeField]
    private List<Material> blinkMaterials;
    private List<Material> originalMaterials;
    private List<List<Material>> allMaterials;
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

        /*foreach (var mesh in meshes)
            foreach (var material in mesh.materials)
                originalMaterials.Add(material);

        allMaterials.Add(originalMaterials);
        allMaterials.Add(blinkMaterials);*/
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
            StartCoroutine(TakeDamage(5));

        float agentVelocity = agent.velocity.magnitude;

        anim.speed = agentVelocity * walkSpeed;
        manure.Rotate(agentVelocity * rollSpeed * Time.deltaTime * Vector3.right);

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
            GameManager.Instance.Score += 100;

            GameManager.Instance.UpdateScore();

            EnemySpawn.Instance.SpawnedEnemies.Remove(gameObject);

            Destroy(gameObject);
            yield break;
        }

        /*for (int i = 1; i <= blinkTimes; i++)
        {
            List<Material> tempMaterials = new();

            meshes.ForEach(x => 
            {
                foreach (var item in x.materials)
                    tempMaterials.Add(item);
            });

            for (int j = 0; j < tempMaterials.Count; j++)
                tempMaterials[j] = allMaterials[i % allMaterials.Count][j];

            yield return new WaitForSeconds(0.1f);
        }

        List<Material> materials = new();

        meshes.ForEach(x =>
        {
            foreach (var item in x.materials)
                materials.Add(item);
        });

        for (int j = 0; j < materials.Count; j++)
            materials[j] = allMaterials[0][j];*/

        isTakingDamage = false;
    }

    public bool IsTakingDamage { get => isTakingDamage; }
    public int Score { get => score; }
}
