﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SlideGimmick : MonoBehaviour
{
    [SerializeField]
    private float checkSpeed = 1;
    [SerializeField]
    private Vector2 checkRange = default;
    [SerializeField]
    private GameObject checkBox = null;
    [SerializeField]
    private GameObject scrollbar = null;
    [SerializeField]
    private GameObject targetScrollbar = null;
    private float num=0;
    private Image targetImage = null;
    private Scrollbar nowPos = null;
    private Scrollbar targetPos = null;
    private bool is_Push = false;
    private bool is_Counter=false;
    // Start is called before the first frame update
    private void Awake()
    {
        nowPos = scrollbar.GetComponent<Scrollbar>();
        targetPos = targetScrollbar.GetComponent<Scrollbar>();
        targetImage = checkBox.GetComponent<Image>();
        targetImage.fillAmount = checkRange.y/100;
        checkRange.x = Random.Range(0, 100-checkRange.y);
        targetPos.value = checkRange.x / 100;
    }

    private void Update()
    {
        nowPos.value = num / 100;
        if (Input.GetMouseButtonDown(0))
        {
            Check();
        }
        if (!is_Counter)
        {
            if (num < 100)
            {
                num += 1 * checkSpeed*Time.deltaTime;
            }
            else
            {
                is_Counter = true;
                num = 0;
            }
        }
        else
        {
            if (num < 100)
            {
                num += 1 * checkSpeed* Time.deltaTime;
            }
            else
            {
                is_Counter = false;
                num = 0;
            }
        }
    }
    void Check()
    {
        Debug.Log(100 - checkRange.y);
        if (num >= checkRange.x && num <= checkRange.y + checkRange.x)
        {
            num = 0;
            Debug.Log("修理時間-5秒");
            //ランダムで位置を変更
            checkRange.x = Random.Range(0, 100 - checkRange.y);
            targetPos.value = checkRange.x / 100;
        }
    }
}