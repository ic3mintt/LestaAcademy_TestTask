using System;
using UnityEngine;

namespace GameInput
{
    public class InputHandler : MonoBehaviour
    {
        [HideInInspector] public bool IsSpaceButtonLocked, IsWASDLocked, IsMouseLocked;
        
        public event Action OnSpaceDown;
        public event Action<Vector3> OnWASDChange;
        public event Action<float> OnMouseXChange; 

        private void Update()
        {
            if(!IsSpaceButtonLocked && Input.GetKeyDown(KeyCode.Space))
                OnSpaceDown?.Invoke();
            
            if(IsMouseLocked)
                OnMouseXChange?.Invoke(0f);
            else
                OnMouseXChange?.Invoke(Input.GetAxis("Mouse X"));
            
            if(IsWASDLocked)
                OnWASDChange?.Invoke(Vector3.zero);
            else 
                OnWASDChange?.Invoke(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
        }
    }
}