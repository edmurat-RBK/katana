using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    // Components
    private Rigidbody2D rb;
    private Animator anim;

    // Health
    public float maximumHealth = 10f;
    [HideInInspector] public float health;
    private bool isAlive = true;
    private bool isTakingDamage;

    // Move
    public float speed = 1f;
    public float speedModifier = 1f;
    // Dash
    public float dashSpeed = 1.5f;
    private float dashTime;
    public float initialDashTime = 1f;
    private float dashCooldown;
    public float initialDashCooldown = 2f;
    private bool isDashing = false;
    // Melee Attack
    public float attackMeleeDamage = 2f;
    public float attackMeleeRange = 0.5f;
    public float attackMeleeRadius = 1f;
    public GameObject attackMeleeMarker;
    public LayerMask enemyLayerMask;
    private float attackMeleeCooldown;
    public float initialAttackMeleeCooldown = 0.10f;
    private bool isMeleeAttacking = false;
    // Range Attack
    public GameObject projectilePrefab;
    public int projectileCount = 3;
    private float attackRangeCooldown;
    public float initialAttackRangeCooldown = 4f;
    private bool isRangeAttacking = false;
    public float projectileSpeed;
    private Transform projectileOrigin;
    private float heldTimer = 0;
    public int shurikenLoaded = 0;
    private Vector3 directionOffsetA;
    private Vector3 directionOffsetB;
    // Hold
    public GameObject itemHold;
    public Collider2D[] itemPickupable;
    public LayerMask lootLayerMask;
    [HideInInspector] public bool isHolding = false;
    public float throwForce = 20f;
   
    //manger loot
    private bool underOnionEffect = false;
    private bool underWatermelonEffect = false;
    private bool underTofuEffect = false;
    private bool underEggplantEffect = false;
    public GameObject fxMarker;
    //loot effects watermelon
    private float waterMelonEffectCooldown;
    public float initWaterMelonEffectCooldown ;
    public float waterMelonSpeedBoost ;
    public float watermelonDashCooldown;
    private float originalSpeedModifier;
    private float originalInitialDashCooldown;
    public GameObject speedParticule;
    //tofu effect
    private float tofuEffectCooldown;
    public float initTofuEffectCooldown;
    private float tofuAttackDmg;
    private float initattackdmg;
    public float tofubonusdmg;
    public GameObject attackParticule;

    //Audio
    public GameObject soundSource;
    public AudioSource source;




    void Start()
    {
        source = soundSource.GetComponent<AudioSource>();
        tofuEffectCooldown = initTofuEffectCooldown;
        initattackdmg = attackMeleeDamage;
        tofuAttackDmg = attackMeleeDamage + tofubonusdmg;
        originalInitialDashCooldown = initialDashCooldown;
        originalSpeedModifier = speedModifier;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        health = maximumHealth;
        dashTime = initialDashTime;
    }

    void Update()
    {
        //TestHealthModifier();

        if(isAlive)
        {
            Statistics();

            
            Move();
            

            if (!isMeleeAttacking)
            {
                Dash();
            }

            if (!isDashing && !isHolding)
            {
                MeleeAttack();
            }
            
            if (!isMeleeAttacking && !isDashing && !isHolding)
            {
                RangeAttack();
            }

            if(!isMeleeAttacking && !isDashing)
            {
                Pickup();
            }

            if(isHolding)
            {
                Consume();
                Throw();
            }

            anim.SetBool("isDead", false);
        }
        else
        {
            anim.SetBool("isDead", true);
        }   
    }

    void FixedUpdate()
    {
        lootEatEffects();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("StartRun"))
        {
            if(Input.GetButtonDown("Dash"))
            {
                SceneManager.LoadScene("SandboxScene");
            }
        }

        if(other.gameObject.name.Equals("StartTuto"))
        {
            if(Input.GetButtonDown("Dash"))
            {
                //SceneManager.LoadScene("TutorialScene");
            }
        }

        if (other.gameObject.name.Equals("OpenMenu"))
        { 
            other.gameObject.transform.parent.gameObject.GetComponent<SpriteOpacityManager>().IncreaseOpacity(other.gameObject.transform.Find("GlowMenu").gameObject);
            if (Input.GetButtonDown("Dash"))
            {
                //Set Menu UI Active
            }
        }

        if (other.gameObject.name.Equals("OpenFridge"))
        {
            other.gameObject.transform.parent.gameObject.GetComponent<SpriteOpacityManager>().IncreaseOpacity(other.gameObject.transform.Find("GlowFridge").gameObject);
            if (Input.GetButtonDown("Dash"))
            {
                //GameObject.FindGameObjectWithTag("UI").transform.Find("FridgeUI").gameObject.SetActive(true);
                GameObject.FindGameObjectWithTag("UI").GetComponent<FridgeUI>().Pause();
            }
        }

        if (other.gameObject.name.Equals("ReturnToHub"))
        {
            if(Input.GetButtonDown("Dash"))
            {
                SceneManager.LoadScene("HubScene");
            }  
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("OpenMenu"))
        {
            other.gameObject.transform.parent.gameObject.GetComponent<SpriteOpacityManager>().ResetOpacity(other.gameObject.transform.Find("GlowMenu").gameObject);
        }

        if (other.gameObject.name.Equals("OpenFridge"))
        {
            other.gameObject.transform.parent.gameObject.GetComponent<SpriteOpacityManager>().ResetOpacity(other.gameObject.transform.Find("GlowFridge").gameObject);
        }


    }

    private void Move()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(inputHorizontal, inputVertical, 0f);
        rb.velocity = new Vector2(movement.x, movement.y).normalized * (speed * speedModifier);

        // Animation
        if (rb.velocity.x != 0 || rb.velocity.y != 0)
        {
            anim.SetBool("isMoving", true);
            anim.SetFloat("horizontalMovement", rb.velocity.x);
            anim.SetFloat("verticalMovement", rb.velocity.y);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }
    }

    private void Dash()
    {
        bool inputDash = Input.GetButtonDown("Dash");

        if(!isDashing)
        {
            if(dashCooldown <= 0)
            {
                if(inputDash && (rb.velocity.x != 0 || rb.velocity.y != 0))
                {
                    isDashing = true;
                    source.clip = soundSource.GetComponent<PlayerAudioManager>().dashSound;
                    source.Play();
                }
            }
            else
            {
                dashCooldown -= Time.deltaTime;
                if(dashCooldown <= 0)
                {
                    dashCooldown = 0;
                }
            }
        }
        else
        {
            if (dashTime <= 0)
            {
                isDashing = false;
                dashTime = initialDashTime;
                dashCooldown = initialDashCooldown;
                rb.velocity = Vector2.zero;
            }
            else
            {
                dashTime -= Time.deltaTime;
                rb.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized * dashSpeed;
            }
        }

        // Animation & Sound
        if (isDashing)
        {
            anim.SetBool("isDashing", true);
            
        }
        else
        {
            anim.SetBool("isDashing", false);
        }
    }

    private void MeleeAttack()
    {
        bool inputMelee = Input.GetButtonDown("MeleeAttack");
        float inputHorizontal = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");

        if (!isMeleeAttacking)
        {
            // Check joystick X an Y position
            if (inputHorizontal >= Math.Sqrt(2) / 2)
            {
                attackMeleeMarker.transform.position = gameObject.transform.position + new Vector3(attackMeleeRange + 0.5f, 0.5f, 0f);
                attackMeleeMarker.GetComponent<Animator>().SetFloat("horizontalDirection", 1f);
                attackMeleeMarker.GetComponent<Animator>().SetFloat("verticalDirection", 0f);
                directionOffsetA = new Vector3(0f, 0.45f, 0f);
                directionOffsetB = new Vector3(0f, 0.05f, 0f);
            }
            else if (inputHorizontal <= -Math.Sqrt(2) / 2)
            {
                attackMeleeMarker.transform.position = gameObject.transform.position + new Vector3(-attackMeleeRange - 0.5f, 0.5f, 0f);
                attackMeleeMarker.GetComponent<Animator>().SetFloat("horizontalDirection", -1f);
                attackMeleeMarker.GetComponent<Animator>().SetFloat("verticalDirection", 0f);
                directionOffsetA = new Vector3(0f, 0.45f, 0f);
                directionOffsetB = new Vector3(0f, 0.05f, 0f);
            }
            else if (inputVertical >= Math.Sqrt(2) / 2)
            {
                attackMeleeMarker.transform.position = gameObject.transform.position + new Vector3(0f, attackMeleeRange + 1f, 0f);
                attackMeleeMarker.GetComponent<Animator>().SetFloat("horizontalDirection", 0f);
                attackMeleeMarker.GetComponent<Animator>().SetFloat("verticalDirection", 1f);
                directionOffsetA = new Vector3(0.45f, 0f, 0f);
                directionOffsetB = new Vector3(0.05f, 0f, 0f);
            }
            else if (inputVertical <= -Math.Sqrt(2) / 2)
            {
                attackMeleeMarker.transform.position = gameObject.transform.position + new Vector3(0f, -attackMeleeRange, 0f);
                attackMeleeMarker.GetComponent<Animator>().SetFloat("horizontalDirection", 0f);
                attackMeleeMarker.GetComponent<Animator>().SetFloat("verticalDirection", -1);
                directionOffsetA = new Vector3(0.45f, 0f, 0f);
                directionOffsetB = new Vector3(0.05f, 0f, 0f);
            }

            // If cooldown up
            if (attackMeleeCooldown <= 0)
            {
                if(inputMelee)
                {
                    source.clip = soundSource.GetComponent<PlayerAudioManager>().attackSound;
                    source.Play();

                    isMeleeAttacking = true;

                    Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(attackMeleeMarker.transform.position, attackMeleeRadius, enemyLayerMask);
                    for (int i = 0; i < enemiesHit.Length; i++)
                    {
                        enemiesHit[i].GetComponent<Enemy>().TakeDamage(attackMeleeDamage);
                    }
                }
            }
            else
            {
                attackMeleeCooldown -= Time.deltaTime;
                if(attackMeleeCooldown <= 0)
                {
                    attackMeleeCooldown = 0;
                }
            }
        }

        // Animation & Sounds
        if (isMeleeAttacking)
        {
            anim.SetBool("isMeleeAttacking", true);
            attackMeleeMarker.GetComponent<Animator>().SetBool("isMeleeAttacking", true);
        }
        else
        {
            anim.SetBool("isMeleeAttacking", false);
            attackMeleeMarker.GetComponent<Animator>().SetBool("isMeleeAttacking", false);
        }
    }

    private void RangeAttack()
    {
        bool inputRange = Input.GetButton("RangeAttack");

        if (attackRangeCooldown <= 0)
        {
            if(inputRange)
            {
                heldTimer += Time.deltaTime;

                // For UI
                if(heldTimer <= 0.6f)
                {
                    shurikenLoaded = 1;
                }
                else if (heldTimer > 0.6f && heldTimer <= 1.2f)
                {
                    shurikenLoaded = 2;
                }
                else if (heldTimer > 1.2f)
                {
                    shurikenLoaded = 3;
                }
            }

            if(Input.GetButtonUp("RangeAttack"))
            {
                Vector3 direction = transform.position + new Vector3(0f, 0.5f, 0f);

                if (heldTimer <= 0.6f) 
                {
                    GameObject instance = Instantiate(projectilePrefab, attackMeleeMarker.transform.position, Quaternion.identity);
                    instance.GetComponent<Rigidbody2D>().AddForce((attackMeleeMarker.transform.position - direction).normalized * projectileSpeed);
                }

                else if (heldTimer > 0.6f && heldTimer <= 1.2f)
                {
                    GameObject instanceA = Instantiate(projectilePrefab, attackMeleeMarker.transform.position + directionOffsetA, Quaternion.identity);
                    instanceA.GetComponent<Rigidbody2D>().AddForce((attackMeleeMarker.transform.position - (direction - directionOffsetB)).normalized * projectileSpeed);

                    GameObject instanceB = Instantiate(projectilePrefab, attackMeleeMarker.transform.position - directionOffsetA, Quaternion.identity);
                    instanceB.GetComponent<Rigidbody2D>().AddForce((attackMeleeMarker.transform.position - (direction + directionOffsetB)).normalized * projectileSpeed);

                }

                else if(heldTimer > 1.2f)
                {
                    GameObject instance = Instantiate(projectilePrefab, attackMeleeMarker.transform.position, Quaternion.identity);
                    instance.GetComponent<Rigidbody2D>().AddForce((attackMeleeMarker.transform.position - direction).normalized * projectileSpeed);

                    GameObject instanceA = Instantiate(projectilePrefab, attackMeleeMarker.transform.position + directionOffsetA, Quaternion.identity);
                    instanceA.GetComponent<Rigidbody2D>().AddForce((attackMeleeMarker.transform.position - (direction - directionOffsetB)).normalized * projectileSpeed);

                    GameObject instanceB = Instantiate(projectilePrefab, attackMeleeMarker.transform.position - directionOffsetA, Quaternion.identity);
                    instanceB.GetComponent<Rigidbody2D>().AddForce((attackMeleeMarker.transform.position - (direction + directionOffsetB)).normalized * projectileSpeed);

                }

                source.clip = soundSource.GetComponent<PlayerAudioManager>().shurikenSound;
                source.Play();

                heldTimer = 0;
                attackRangeCooldown = initialAttackRangeCooldown;
                shurikenLoaded = 0;
            }
        }
        else
        {
            attackRangeCooldown -= Time.deltaTime;
            if (attackRangeCooldown <= 0)
            {
                attackRangeCooldown = 0;
            }
        }
    }

    private void Pickup() 
    {
        itemPickupable = Physics2D.OverlapCircleAll(transform.position, 1f, lootLayerMask);

        if (!isHolding)
        {
            if(itemPickupable.Length >= 1)
            {
                if(Input.GetButtonDown("Pick"))
                {
                    isHolding = true;
                    anim.SetBool("isHolding", true);
                    itemHold = itemPickupable[0].gameObject;
                    itemHold.GetComponent<Loot>().isPickup = true;

                    //Audio
                    source.clip = soundSource.GetComponent<PlayerAudioManager>().pickupSound;
                    source.Play();
                }
            }
        }
        else
        {
            itemHold.transform.position = new Vector3(transform.position.x, transform.position.y + 1.25f, 0f);
            speedModifier = 0.75f;
        }
    }

    private void Throw()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Throw"))
        {
            //Audio
            source.clip = soundSource.GetComponent<PlayerAudioManager>().throwSound;
            source.Play();

            isHolding = false;
            anim.SetBool("isHolding", false);
            itemHold.GetComponent<Loot>().isThrow = true;
            itemHold.GetComponent<Loot>().isPickup = false;
            if (rb.velocity.x != 0 || rb.velocity.y != 0)
            {
                Vector2 force = new Vector2(inputHorizontal, inputVertical).normalized * throwForce;
                itemHold.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);
            }
            else
            {
                Vector2 force = ((transform.position + new Vector3(0f, 0.5f, 0f)) - attackMeleeMarker.transform.position).normalized * throwForce;
                itemHold.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);
            }

            

            speedModifier = 1f;
        }
    }

    private void Consume()
    {
        if (Input.GetButtonDown("Consume"))
        {  
            switch (itemHold.GetComponent<Loot>().item)
            {
                case Item.ONION:
                    if (health < maximumHealth)
                    {
                        health++;
                    }
                    underOnionEffect = true;
                    break;
                case Item.WATERMELON:
                    waterMelonEffectCooldown = initWaterMelonEffectCooldown;
                    underWatermelonEffect = true;
                    break;
                case Item.TOFU:
                    underTofuEffect = true;
                    break;
                case Item.EGGPLANT:
                    if (health == 9)
                    {
                        health++;
                    }
                    if (health < maximumHealth)
                    {

                        health = health + 2;
                    }
                    underEggplantEffect = true;
                    break;
                default:
                    //Do nothing
                    break;
            }

            isHolding = false;
            fxMarker.GetComponent<Animator>().SetBool("isConsuming", true);
            anim.SetBool("isHolding", false);
            speedModifier = 1f;
            Destroy(itemHold);
            
            //Audio
            source.clip = soundSource.GetComponent<PlayerAudioManager>().bonusSound;
            source.Play();
        }

    }
    private void lootEatEffects()
    {
        if (underWatermelonEffect == true)
        {
            if (waterMelonEffectCooldown > 0) //on augmente la vitesse mais on augmente le CD d
            {
                speedModifier = waterMelonSpeedBoost;
                initialDashCooldown = watermelonDashCooldown;
                waterMelonEffectCooldown--;
                speedParticule.SetActive(true);
            }
            else // on reinitialise tt
            {
                initialDashCooldown = originalInitialDashCooldown;
                speedModifier = originalSpeedModifier;
                speedParticule.SetActive(false);
            }
        }
        if (underTofuEffect == true)
        {
            if (tofuEffectCooldown > 0)
            {
                attackMeleeDamage = tofuAttackDmg;
                tofuEffectCooldown--;
                attackParticule.SetActive(true);
            
            }
            else
            {
                attackMeleeDamage = initattackdmg;
                underTofuEffect = false;
                tofuEffectCooldown = initTofuEffectCooldown;
                attackParticule.SetActive(false);
            }
        }
        
        }

    private void Statistics()
    {
        if(health <= 0)
        {
            isAlive = false;
            health = 0;
        }

    }

    public void TakeDamage(float damage)
    {

        float timeScale = 0.7f - ((damage / 10) * (damage / 10));
        if(health > 0)
        {
            health -= damage;
            Time.timeScale = timeScale;
            if (health <= 0)
            {
                health = 0;
                Time.timeScale = 1f;
            }
        }

        //Animation & Sound 
        source.clip = soundSource.GetComponent<PlayerAudioManager>().hitSound;
        source.Play();

        anim.SetBool("isDamage", true);
    }

    public void GetAnimationEvent(string eventMessage)
    {
        if(eventMessage.Equals("MeleeAttackEnded"))
        {
            isMeleeAttacking = false;
            attackMeleeCooldown = initialAttackMeleeCooldown;
        }

        if(eventMessage.Equals("Hit"))
        {
            anim.SetBool("isDamage", false);
            Time.timeScale = 1f;
        }

        if (eventMessage.Equals("DeathEnded"))
        {
            SceneManager.LoadScene("HubScene");
        }
    }

    // UI methods
    public float GetCooldownInPercentage()
    {
        return 1 - (dashCooldown / initialDashCooldown);
    }

    private void TestHealthModifier()
    {
        if(Input.GetKeyDown(KeyCode.P) && health < 10)
        {
            health++;
            anim.SetBool("isDead", false);
        }

        if (Input.GetKeyDown(KeyCode.M) && health > 0)
        {
            health--;

            // Animation (death)
            if (health <= 0)
            {
                anim.SetBool("isDead", true);
            }
            else
            {
                anim.SetBool("isDead", false);
            }
        }
    }

    public int GetHealth()
    {
        return (int)Mathf.Ceil(health);
    }
}
