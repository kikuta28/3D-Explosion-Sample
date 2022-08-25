using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject mapPrefab;
    public GameObject treePrefab;

    GameObject map;
    float x;
    float z;

    //Generateされた時間
    private float generatedTime = 10f;
    //「Generateされた時間」までカウントするための変数
    private float generateCounter;

    // Start is called before the first frame update
    void Start()
    {
        GenerateMap();
    }

    // Update is called once per frame
    void Update()
    {
        if (generateCounter >= generatedTime)
        {
            GenerateMap();
            //Counterをリセット
            //これを入れないとUpdate毎にCubeが出てきて大量になるので面白い
            generateCounter = 0;
        }
        //カウンターを＋1秒
        generateCounter += Time.deltaTime;
    }
    void GenerateMap()
    {
        float min = 150f;
        float max = 200f;
        //updateされる毎に変わる値
        //一度Update（）内に入れてDebugLogで表示させるのも良いかも
        x += Random.Range(min, max);
        z += Random.Range(min, max);
        //敵のPositionを定義。
        Vector3 mapPosition = new Vector3(x, 0f, z);

        map = Instantiate(mapPrefab);
        //PositionをInstanceに代入
        map.transform.position = mapPosition;

        for(int i=0; i<10; i++)
        {
            GenerateTree();
        }


    }
        void GenerateTree()
        {

            float min = -20f;
            float max = 20f;
            float xRange = Random.Range(min, max);
            float zRange = Random.Range(min, max);
            Vector3 mapPosition = map.transform.position + new Vector3(xRange, 3f, zRange);

            GameObject tree = Instantiate(treePrefab);
            //PositionをInstanceに代入
            tree.transform.position = mapPosition;

        }
}
