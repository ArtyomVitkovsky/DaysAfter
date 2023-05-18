using UnityEngine;
using UnityEngine.Events;

namespace Modules.Main.Scripts
{
    public class MouseInput : MonoBehaviour
    {
        public UnityAction<float> OnXAxisMove;
        public UnityAction<float> OnYAxisMove;

        public UnityAction OnLMBclick;
        public UnityAction OnLMBdown;
        public UnityAction OnLMBup;
        public UnityAction OnRMBclick;
        public UnityAction OnRMBdown;
        public UnityAction OnRMBup;
        
        private void Update()
        {
            GetAxisMove();
            GetMouseButtonsClick();
        }

        private void GetAxisMove()
        {
            var xAxisMove = Input.GetAxisRaw("Mouse X");
            var yAxisMove = Input.GetAxisRaw("Mouse Y");

            OnXAxisMove?.Invoke(xAxisMove);
            OnYAxisMove?.Invoke(-yAxisMove);
        }

        private void GetMouseButtonsClick()
        {
            if(Input.GetMouseButton(0)) OnLMBclick?.Invoke();
            if(Input.GetMouseButtonDown(0)) OnLMBdown?.Invoke();
            if(Input.GetMouseButtonUp(0)) OnLMBup?.Invoke();
            
            if(Input.GetMouseButton(1)) OnRMBclick?.Invoke();
            if(Input.GetMouseButtonDown(1)) OnRMBdown?.Invoke();
            if(Input.GetMouseButtonUp(1)) OnRMBup?.Invoke();
        }
    }
}