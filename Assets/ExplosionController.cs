using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    public ParticleSystem particle;
    public float force = 20;
    public float radius = 5;
    public float upwards = 3;

    float countToDestroy;
    GameObject text;


    public static ExplosionController instance;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        particle.gameObject.SetActive(false);

        text = GameObject.Find("Canvas");
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {

            Explosion();

        }
        if(particle.isPlaying)
        {
            countToDestroy += Time.deltaTime;
        }
        if(countToDestroy > 1)
        {
            Destroy(gameObject);
            countToDestroy = 0;
        }

    }
    public void Explosion()
    {
        particle.gameObject.SetActive(true);
        particle.Play();


        Vector3 position = particle.transform.position;

        // 設定した座標＝Positionから見た範囲＝Radius内の個数を取得
        // RigidbodyにAddExplosionForce
        Collider[] hitColliders = Physics.OverlapSphere(position, radius);

        text.GetComponent<UIController>().comboCounter += hitColliders.Length;

        

        for (int i = 0; i < hitColliders.Length; i++)
        {
            var rb = hitColliders[i].GetComponent<Rigidbody>();
            if (rb == true)
            {
                //力、座標、半径、上への向き
                rb.AddExplosionForce(force, position, radius, upwards, ForceMode.Impulse);
                
            }
        }
    }
}

