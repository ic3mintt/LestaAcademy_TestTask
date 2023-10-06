using System;
using UnityEngine;

namespace GameInput
{
    public class InputHandler : MonoBehaviour
    {
        public event Action OnSpaceDown;
        public event Action<Vector3> OnWASDChange;
        public event Action<float> OnMouseXChange; 

        private void Update()
        {
            OnMouseXChange?.Invoke(Input.GetAxis("Mouse X"));
            OnWASDChange?.Invoke(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
            if(Input.GetKeyDown(KeyCode.Space)) 
                OnSpaceDown?.Invoke();
        }
    }
}