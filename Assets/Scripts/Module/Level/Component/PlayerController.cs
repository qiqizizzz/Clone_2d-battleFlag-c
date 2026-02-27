/*
* ┌──────────────────────────────────┐
* │  描    述: 人物控制器                      
* │  类    名: PlayerController.cs       
* │  创    建: By qiqizizzz
* └──────────────────────────────────┘
*/

using System;
using UnityEngine;

namespace Module.Level.Component
{
    public class PlayerController : MonoBehaviour
    {
        public float moveSpeed = 2.5f;
        public Animator ani;
        
        private void Start()
        {
            ani = GetComponent<Animator>();
            GameApp.CameraManager.SetPos(transform.position);//设置摄像机位置
        }

        private void Update()
        {
            float h = Input.GetAxisRaw("Horizontal");
            if (h == 0)
            {
                ani.Play("idle");
            }
            else
            {
                if ((h > 0 && transform.localScale.x < 0) || (h < 0 && transform.localScale.x > 0))
                {
                    Flip();
                }

                Vector3 pos = transform.position + Vector3.right * h * moveSpeed * Time.deltaTime;
                pos.x = Mathf.Clamp(pos.x, -32, 24);//限制玩家移动范围
                transform.position = pos;
                
                GameApp.CameraManager.SetPos(transform.position);//设置摄像机位置
                ani.Play("move");
            }
        }

        //转向
        public void Flip()
        {
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
}