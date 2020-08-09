using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGame.General
{
    public class Observer : MonoBehaviour
    {
        [SerializeField]
        private float maxUp, maxDown, maxLeft, maxRight;
        [SerializeField]
        private float stepX, stepY, speedX, speedY, speed;
        [SerializeField]
        private bool isMoving;
        private void Start()
        {
            //Persistents.Instance.InputHandler.AddObservers(this);
        }
        public void OnReceiveInput(Movement mvm)
        {
    
        }
        public void OnReceiveKey(KeyCode key)
        {
            Debug.Log(key + " pressed");
            switch (key)
            {
                case KeyCode.Space:

                    break;
                case KeyCode.Backspace:

                    break;
                case KeyCode.LeftArrow:

                    break;
                case KeyCode.RightArrow:

                    break;
            }
        }
    }
}
