using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public GameObject weapon;
    public float swingTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        weapon.SetActive(true);
        yield return new WaitForSeconds(swingTime);
        weapon.SetActive(false);
    }
}
