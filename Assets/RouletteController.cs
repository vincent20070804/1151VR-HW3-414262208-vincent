using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteController : MonoBehaviour
{
    float rotSpeed = 0; // 旋轉速度
    AudioSource audioSource; // 宣告音效元件變數

    void Start()
    {
        // 影格速率設為 60 FPS
        Application.targetFrameRate = 60;

        // 取得掛載在同一個物件上的 Audio Source 元件
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // 按下滑鼠且目前沒有在旋轉時，才設定旋轉速度並播放旋轉音效
        if (Input.GetMouseButtonDown(0) && this.rotSpeed == 0)
        {
            this.rotSpeed = 10;
            
            // 如果有設定音效，播放音效
            if (audioSource != null)
            {
                audioSource.Play();
            }
        }

        // 讓輪盤依照設定的速度旋轉
        transform.Rotate(0, 0, this.rotSpeed);

        // 讓輪盤減速
        this.rotSpeed *= 0.96f; 

        // 當速度小到幾乎停止時，讓速度完全歸零
        if (this.rotSpeed < 0.01f && this.rotSpeed > 0)
        {
            this.rotSpeed = 0;
        }
    }
}