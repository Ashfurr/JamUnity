using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] float timerRespawn;
    [SerializeField] GameObject fish;
    [SerializeField] GameObject bomb;
    private bool CanSpawn = true;
    private GameObject liveObject = null;

    private void Start()
    {
        
        StartCoroutine(timerSpawn());
       
    }
    private void Update()
    {
      if (CanSpawn)
        {
            StartCoroutine(timerSpawn());
        }
    }
    IEnumerator timerSpawn ()
    {
        print("yes");
        Spawn();
        yield return new WaitForSeconds(timerRespawn);
        Destroy(liveObject);
        CanSpawn = true;
        print("after");
        
    }
    void Spawn()
    {
        int random = Random.Range(0, 2);
        print(random);
        if ( random == 1)
        {
            liveObject = Instantiate(fish, new Vector3(this.transform.position.x, this.transform.position.y + 1, this.transform.position.z), Quaternion.identity);
            CanSpawn = false;
        }
        else
        {
            liveObject = Instantiate(bomb, new Vector3(this.transform.position.x, this.transform.position.y + 1, this.transform.position.z), Quaternion.identity);
            CanSpawn = false;
        }
    }
}
