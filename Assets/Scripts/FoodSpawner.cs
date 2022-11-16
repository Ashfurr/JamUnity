using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] float timerRespawn;
    [SerializeField] GameObject fish;
    [SerializeField] GameObject bomb;
    [SerializeField] ParticleSystem fxSpawn;
    
    private bool CanSpawn = true;
    private GameObject liveObject = null;
    private Transform spawnLocate;

    private void Start()
    {
        
        StartCoroutine(timerSpawn());
       
    }
    private void Update()
    {
      if (CanSpawn)
        {
            print("la");
            StartCoroutine(timerSpawn());
        }
    }
    IEnumerator timerSpawn ()
    {
       
        Spawn();
        yield return new WaitForSeconds(timerRespawn);
        if(liveObject != null)
        {
            if (liveObject.GetComponent<Projectiles>().alive == false)
            {
                Destroy(liveObject);
            }
        }
        
        
        CanSpawn = true;
      
        
    }
    void Spawn()
    {
        int random = Random.Range(0, 2);
        
        if ( random == 1)
        {
            
            liveObject = Instantiate(fish, new Vector3(this.transform.position.x, this.transform.position.y + 0.3f, this.transform.position.z), Quaternion.identity);
            Instantiate(fxSpawn,new Vector3(this.transform.position.x, this.transform.position.y + 0.3f, this.transform.position.z), Quaternion.identity);
            spawnLocate = liveObject.transform;
            CanSpawn = false;
        }
        else
        {
           
            liveObject = Instantiate(bomb, new Vector3(this.transform.position.x, this.transform.position.y + 0.3f, this.transform.position.z), Quaternion.identity);
            Instantiate(fxSpawn, new Vector3(this.transform.position.x, this.transform.position.y + 0.3f, this.transform.position.z),Quaternion.identity);
            CanSpawn = false;
            spawnLocate = liveObject.transform;
        }
    }
}
