using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public int score = 0;
    public int level = 0;
    [SerializeField] private TextMeshProUGUI scoreTxt;
    [SerializeField] private TextMeshProUGUI levelTxt;
    [SerializeField] private TextMeshProUGUI statusTxt;
    [SerializeField] private Button saveBtn;
    [SerializeField] private Button loadBtn;
    
    // Start is called before the first frame update

    private void Update()
    {
        
    }

    public void OnClickSave()
    {
        SaveData.SavePlayer(this);
        statusTxt.text = "Save Success";
    }
    public void OnClickLoad()
    {
        Data data = SaveData.Load();
        score = data.score;
        level = data.level;
        statusTxt.text = "Load Success";
        scoreTxt.text = $"Score : {score}";
        levelTxt.text = $"Level: {level}";
    }
    public void OnClickAddScore()
    {
        score++;
        scoreTxt.text = $"Score : {score}";
    }
    public void OnClickSubScore()
    {
        score--;
        scoreTxt.text = $"Score : {score}";
    }
    public void OnClickAddLevel()
    {
        level++;
        levelTxt.text = $"Level: {level}";
    }
    public void OnClickSubLevel()
    {
        level--;
        levelTxt.text = $"Level: {level}";
    }
    
}
