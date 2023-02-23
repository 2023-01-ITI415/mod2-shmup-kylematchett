using System.Collections; // Required for some Arrays manipulation
using System.Collections.Generic; // Required for Lists andDictionaries
using UnityEngine; // Required for Unity

public class Enemy : MonoBehaviour
{
    [Header("Inscribed")]
    public float speed = 10f; // The movement speed is 10m/s
    public float fireRate = 0.3f; // Seconds/shot (Unused)
    public float health = 10; // Damage needed todestroy this enemy
    public int score = 100; // Points earned for destroying this
    private BoundsCheck bndCheck;
    // This is a Property: A method that acts like a field
    public Vector3 pos
    {
        // a
        get
        {
            return this.transform.position;
        }
        set
        {
            this.transform.position = value;
        }
    }




    // b


    void Awake()
    {
        // c
        bndCheck = GetComponent<BoundsCheck>();

    }

    public virtual void Move()
    { // c
        Vector3 tempPos = pos;
        tempPos.y -= speed * Time.deltaTime;
        pos = tempPos;
    }
    void Update()
    {
        Move();
        // b
        // Check whether this Enemy has gone off the bottom of the screen
        if (!bndCheck.isOnScreen)
            if (bndCheck.LocIs(BoundsCheck.eScreenLocs.offDown))
            { // a
                Destroy(gameObject);
            }
    }
    void OnCollisionEnter(Collision coll)
    {
        GameObject otherGO = coll.gameObject;
        // a
        if (otherGO.GetComponent<ProjectileHero>() != null)
        { // b
            Destroy(otherGO); // Destroy the Projectile
            Destroy(gameObject); // Destroy this Enemy GameObject
        }
        else
        {
            Debug.Log("Enemy hit by non-ProjectileHero: " + otherGO.name); // c 
        }
    }

}