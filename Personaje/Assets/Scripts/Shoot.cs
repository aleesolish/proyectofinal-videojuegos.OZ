using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    public GameObject projectile;
    public Vector3 velocity;
    bool canShoot;
    public Vector3 offset = new Vector3(0.4f, 0.1f,0);
    public float cooldown = 1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKeyDown(KeyCode.Space) && canShoot){
          
            GameObject go = (GameObject) Instantiate(projectile, transform.position + offset * transform.localScale.x, Quaternion.identity);
            go.GetComponent<Rigidbody>().velocity = new Vector3(velocity.x * transform.localScale.x, velocity.y);
        }
    }



    IEnumerator CanShoot()
    {
        canShoot = false;
        yield return new WaitForSeconds(cooldown);
    }
}
