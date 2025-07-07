using UnityEngine;
using System.Collections;

public class enemyAI : MonoBehaviour, IDamage
{
    [SerializeField] Renderer model;

    [SerializeField] int HP;

    Color colorOrg;

<<<<<<< HEAD:Team Project/Team Project/Assets/Scripts/EnemyAI.cs
<<<<<<< HEAD:Team Project/Team Project/Assets/Scripts/EnemyAI.cs
    float shootTimer;
    float roamTimer;
    float angleToPlayer;
    float stoppingDistOrig;


    bool playerInTrigger;

    Vector3 playerDir;
    Vector3 startingPos;

=======
>>>>>>> parent of 696740da (Second Commit added enemy AI, Bullet, and NavMesh):Team Project/Assets/Scripts/enemyAI.cs
=======
>>>>>>> parent of 696740da (Second Commit added enemy AI, Bullet, and NavMesh):Team Project/Assets/Scripts/enemyAI.cs
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        colorOrg = model.material.color;
<<<<<<< HEAD:Team Project/Team Project/Assets/Scripts/EnemyAI.cs
<<<<<<< HEAD:Team Project/Team Project/Assets/Scripts/EnemyAI.cs
        gameManager.instance.updateGameGoal(1);
        startingPos = transform.position;
        stoppingDistOrig = agent.stoppingDistance;
=======
>>>>>>> parent of 696740da (Second Commit added enemy AI, Bullet, and NavMesh):Team Project/Assets/Scripts/enemyAI.cs
=======
>>>>>>> parent of 696740da (Second Commit added enemy AI, Bullet, and NavMesh):Team Project/Assets/Scripts/enemyAI.cs
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD:Team Project/Team Project/Assets/Scripts/EnemyAI.cs
<<<<<<< HEAD:Team Project/Team Project/Assets/Scripts/EnemyAI.cs

        if (agent.remainingDistance < 0.01f)
        {
            roamTimer += Time.deltaTime;
        }

        if (playerInTrigger && !canSeePlayer())
        {
            roamCheck();
        }
        else if (!playerInTrigger)
        {
            roamCheck();
        }
    }

    void roamCheck()
    {
        if (roamTimer >= roamPauseTime && agent.remainingDistance < 0.01f)
        {
            roam();
        }
    }

    void roam()
    {
        roamTimer = 0;
        agent.stoppingDistance = 0;

        Vector3 ranPos = Random.insideUnitSphere * roamDist;
        ranPos += startingPos;

        NavMeshHit hit;
        NavMesh.SamplePosition(ranPos, out hit, roamDist, 1);
        agent.SetDestination(hit.position);
    }

    bool canSeePlayer()
    {
        playerDir = gameManager.instance.player.transform.position - headPos.position;
        angleToPlayer = Vector3.Angle(playerDir, transform.forward);

        Debug.DrawRay(headPos.position, playerDir);

        RaycastHit hit;
        if (Physics.Raycast(headPos.position, playerDir, out hit))
        {
            if (hit.collider.CompareTag("Player") && angleToPlayer <= fov)
            {
                shootTimer += Time.deltaTime;

                if (shootTimer >= shootRate)
                {
                    shoot();
                }

                agent.SetDestination(gameManager.instance.player.transform.position);

                if (agent.remainingDistance <= agent.stoppingDistance)
                    faceTarget();

                return true;
            }
        }
        agent.stoppingDistance = stoppingDistOrig;
        return false;
    }

    void faceTarget()
    {
        Quaternion rot = Quaternion.LookRotation(new Vector3(playerDir.x, transform.position.y, playerDir.z));
        transform.rotation = Quaternion.Lerp(transform.rotation, rot, faceTargetSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = false;
            agent.stoppingDistance = 0;
        }
=======
        
>>>>>>> parent of 696740da (Second Commit added enemy AI, Bullet, and NavMesh):Team Project/Assets/Scripts/enemyAI.cs
=======
        
>>>>>>> parent of 696740da (Second Commit added enemy AI, Bullet, and NavMesh):Team Project/Assets/Scripts/enemyAI.cs
    }
    public void takeDamage(int amount)
    {
        HP -= amount;
<<<<<<< HEAD:Team Project/Team Project/Assets/Scripts/EnemyAI.cs
<<<<<<< HEAD:Team Project/Team Project/Assets/Scripts/EnemyAI.cs
        agent.SetDestination(gameManager.instance.player.transform.position);

        if (HP <= 0)
        {
            gameManager.instance.updateGameGoal(-1);
=======

        if (HP <= 0)
        {
>>>>>>> parent of 696740da (Second Commit added enemy AI, Bullet, and NavMesh):Team Project/Assets/Scripts/enemyAI.cs
=======

        if (HP <= 0)
        {
>>>>>>> parent of 696740da (Second Commit added enemy AI, Bullet, and NavMesh):Team Project/Assets/Scripts/enemyAI.cs
            Destroy(gameObject);
        }
        else
        {
            StartCoroutine(flashRed());
        }
    }

    IEnumerator flashRed()
    {
        model.material.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        model.material.color = colorOrg;
    }
<<<<<<< HEAD:Team Project/Team Project/Assets/Scripts/EnemyAI.cs
<<<<<<< HEAD:Team Project/Team Project/Assets/Scripts/EnemyAI.cs

    void shoot()
    {
        shootTimer = 0;

        Instantiate(bullet, shootPos.position, transform.rotation);
    }
=======
>>>>>>> parent of 696740da (Second Commit added enemy AI, Bullet, and NavMesh):Team Project/Assets/Scripts/enemyAI.cs
=======
>>>>>>> parent of 696740da (Second Commit added enemy AI, Bullet, and NavMesh):Team Project/Assets/Scripts/enemyAI.cs
}
