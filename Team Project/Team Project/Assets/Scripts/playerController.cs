using UnityEngine;

public class playerController : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] LayerMask ignoreLayer;

    [SerializeField] int speed;
    [SerializeField] int sprintMod;
    [SerializeField] int jumpVel;
    [SerializeField] int jumpMax;
    [SerializeField] int gravity;

    [SerializeField] int shootDamage;
    [SerializeField] float shootRate;
    [SerializeField] int shootDist;

    Vector3 moveDir;
    Vector3 playerVel;

    int jumpCount;
<<<<<<< HEAD:Team Project/Team Project/Assets/Scripts/playerController.cs
<<<<<<< HEAD:Team Project/Team Project/Assets/Scripts/playerController.cs
    int HPOrig;
=======
>>>>>>> parent of 696740da (Second Commit added enemy AI, Bullet, and NavMesh):Team Project/Assets/Scripts/playerController.cs
=======
>>>>>>> parent of 696740da (Second Commit added enemy AI, Bullet, and NavMesh):Team Project/Assets/Scripts/playerController.cs

    float shootTimer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
<<<<<<< HEAD:Team Project/Team Project/Assets/Scripts/playerController.cs
<<<<<<< HEAD:Team Project/Team Project/Assets/Scripts/playerController.cs
        HPOrig = HP;
        updatePlayerUI();
=======
        
>>>>>>> parent of 696740da (Second Commit added enemy AI, Bullet, and NavMesh):Team Project/Assets/Scripts/playerController.cs
=======
        
>>>>>>> parent of 696740da (Second Commit added enemy AI, Bullet, and NavMesh):Team Project/Assets/Scripts/playerController.cs
    }

    // Update is called once per frame
    void Update()
    {

        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * shootDist, Color.red);
        sprint();

        movement();
    }

    void movement()
    {

        shootTimer += Time.deltaTime;

        if(controller.isGrounded)
        {
            playerVel = Vector3.zero;
            jumpCount = 0;
        }
        moveDir = (Input.GetAxis("Horizontal") * transform.right) + (Input.GetAxis("Vertical") * transform.forward);
        controller.Move(moveDir * speed * Time.deltaTime);

        jump();

        controller.Move(playerVel * Time.deltaTime);
        playerVel.y -= gravity * Time.deltaTime;

        if(Input.GetButton("Fire1") && shootTimer > shootRate)
        {
            shoot();
        }
    }

    void jump()
    {
        if (Input.GetButtonDown("Jump") && jumpCount < jumpMax)
        {
            playerVel.y = jumpVel;
            jumpCount++;
        }
    }

    void sprint()
    {
        if (Input.GetButtonDown("Sprint"))
        {
            speed *= sprintMod;
        }
        else if (Input.GetButtonUp("Sprint"))
        {
            speed /= sprintMod;
        }
    }

    void shoot()
    {
        shootTimer = 0;

        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, shootDist, ~ignoreLayer))
        {
            //Debug.Log(hit.collider.name);
            IDamage dmg = hit.collider.GetComponent<IDamage>();

            if (dmg != null)
            {
                dmg.takeDamage(shootDamage);
            }
        }
    }
<<<<<<< HEAD:Team Project/Team Project/Assets/Scripts/playerController.cs
<<<<<<< HEAD:Team Project/Team Project/Assets/Scripts/playerController.cs

    public void takeDamage(int amount)
    {
        HP -= amount;

        updatePlayerUI();

        StartCoroutine(damageFlashScreen());

        if (HP <= 0)
        {
            // you dead
            gameManager.instance.youLose();
        }
    }

    public void updatePlayerUI()
    {
        gameManager.instance.playerHPBar.fillAmount = (float)HP / HPOrig;
    }

    IEnumerator damageFlashScreen()
    {
        gameManager.instance.playerDamagePanel.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        gameManager.instance.playerDamagePanel.SetActive(false);
    }
=======
>>>>>>> parent of 696740da (Second Commit added enemy AI, Bullet, and NavMesh):Team Project/Assets/Scripts/playerController.cs
=======
>>>>>>> parent of 696740da (Second Commit added enemy AI, Bullet, and NavMesh):Team Project/Assets/Scripts/playerController.cs
}
