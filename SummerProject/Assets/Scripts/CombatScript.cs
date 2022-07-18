using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatScript : MonoBehaviour
{
    public GameObject projectile;
    public Transform projectileSpawnPoint;

    // Update is called once per frame
    void Update()
    {
        checkInput();
    }

    void checkInput()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            fireProjectile(projectile);
        }
    }

    void fireProjectile(GameObject proj)
    {
        GameObject projectileObj = Instantiate(proj, projectileSpawnPoint.position, Quaternion.identity);

        projectileObj.transform.position = projectileSpawnPoint.position;
        projectileObj.GetComponent<Rigidbody>().velocity = this.transform.forward.normalized * projectile.GetComponent<ProjectileScript>().projSpeed;
    }
}
