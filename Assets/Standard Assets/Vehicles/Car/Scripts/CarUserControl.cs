using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour
    {
        private CarController m_Car; // the car controller we want to use
        public float horizontal;
        public bool throttle = false;
        public bool reverse = false;
        public float v;
        private bool isKeyboard;
        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
        }
        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.G))
            {
                isKeyboard = !isKeyboard;
            }
        }

        private void FixedUpdate()
        {
            float h;
            // pass the input to the car!
            if (isKeyboard)
            {
                h=CrossPlatformInputManager.GetAxis("Horizontal");
            }
            else
            {
                h = horizontal;
            }
                
            v = CrossPlatformInputManager.GetAxis("Vertical");
            if (throttle) { v = 1; }
            if (reverse) { v = -1; }
#if !MOBILE_INPUT
            float handbrake = CrossPlatformInputManager.GetAxis("Jump");
            m_Car.Move(h, v, v, handbrake);
#else
            m_Car.Move(h, v, v, 0f);
#endif
        }

        
    }
}
