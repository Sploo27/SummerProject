using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]private float maxHP = 100f;
    private float currentHP; 

    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        checkHP();
    }

    public void checkHP()
    {
        if(currentHP <= 0f)
        {
            Destroy(this);
        }
    }

    public void takeDamage(float value)
    {
        currentHP -= value;
    }

    public float GetHP()
    {
        return currentHP;
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Projectile")
        {
            takeDamage(col.gameObject.GetComponent<ProjectileScript>().damage);
            Debug.Log("damage");
        }

    }
}
