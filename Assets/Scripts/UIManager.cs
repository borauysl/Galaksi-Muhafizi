using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _scoretext;

    [SerializeField]
    private Image _livesimg;

    [SerializeField]
    private Sprite[] _livesprites;

    void Start()
    {
        
        _scoretext.text = "Puan: " + 0;
    }

    
    public void updatescore(int playerscore)
    {
        _scoretext.text = "Puan: " + playerscore.ToString();
    }

    public void updatelives(int currentlives)
    {
        _livesimg.sprite = _livesprites[currentlives];
    }

}
