using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public static EnemyController instance;

    public GameObject target;
    public float moveSpeed = 0.3f;


    private void Awake()
    {
        instance = this;
        
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveToTarget();


        if(transform.position.y >= 5)
        {
            Destroy(gameObject);

        }
    }

    void MoveToTarget()
    {
        Vector3 distance = (target.transform.position - transform.position);
        this.transform.position += distance * moveSpeed * Time.deltaTime;

    }


}
