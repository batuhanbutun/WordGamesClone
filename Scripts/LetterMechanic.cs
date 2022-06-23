using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterMechanic : MonoBehaviour
{
    public string letter;
    [SerializeField] WordScriptableObject _wordScriptableObj;
    private bool wrote = false;
    private void Start()
    {
        letter = GetComponentInChildren<Text>().text;
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            wrote = false;
        }
    }
    public void Writing()
    {
        if (Input.GetMouseButton(0))
        {
            if (!wrote)
            {
                _wordScriptableObj.word += letter;
                _wordScriptableObj.letterCount++;
            }
                
            wrote = true;
        }
     
    }
}
