using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public GameObject weapon;
    public float swingTime;
    public Animator wepAnim;

    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = player.position.z - Camera.main.transform.position.z;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            if (worldPosition.x < player.position.x)
            {
                // Clicked to the left of the player
                // Perform action here
                StartCoroutine(Attack());
                wepAnim.SetBool("SwingLeft", true);
            }
            else
            {
                // Clicked to the right of the player
                // Perform action here
                StartCoroutine(Attack());
                wepAnim.SetBool("SwingLeft", false);
            }
        }
    }

    IEnumerator Attack()
    {
        weapon.SetActive(true);
        yield return new WaitForSeconds(swingTime);
        weapon.SetActive(false);
    }
}
