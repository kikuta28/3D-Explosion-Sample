using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public TMP_Text comboText;
    public int comboCounter;
    public TMP_Text treeText;
    public int treeCounter;

    public static UIController instance;
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
        comboText.text = comboCounter + " combo!!";
        treeText.text = "Tree: " + treeCounter;
    }
}
