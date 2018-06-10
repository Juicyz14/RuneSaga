using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ProjectileEngine : MonoBehaviour {

    public List<Projectile> activeProjectiles;
    private int maxProjectilesPerUpdate;

    public Projectile projectile;


	// Use this for initialization
	void Start () {
        activeProjectiles = new List<Projectile>();


	}
	
	// Update is called once per frame
	void FixedUpdate () {



		foreach(Projectile p in activeProjectiles.ToList())
        {
            if (!(p.GetComponent<Projectile>().active))
            {
                Destroy(p.gameObject);
                activeProjectiles.Remove(p);
            }
        }
	}

    public void addProjectile()
    {
        activeProjectiles.Add(Instantiate(projectile));
    }
}
