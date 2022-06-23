using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Word/Word")]
public class WordScriptableObject : ScriptableObject
{
    [SerializeField] private int _letterCount;
    [SerializeField] private string _word;
    [SerializeField] private List<string> _meaningfulWords;

    public int letterCount { get { return _letterCount; } set { _letterCount = value; } }
    public string word { get { return _word; } set { _word = value; } }
    public List<string> meaningfulWords { get { return _meaningfulWords; } }

}
