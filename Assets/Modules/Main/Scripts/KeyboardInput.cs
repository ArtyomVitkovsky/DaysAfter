using UnityEngine;

namespace Modules.Main.Scripts
{
    public class KeyboardInput : InputService
    {
        private void Update()
        {
            GetAxisMove();
        }

        private void GetAxisMove()
        {
            var xAxisMove = Input.GetAxisRaw("Horizontal");
            var yAxisMove = Input.GetAxisRaw("Jump");
            var zAxisMove = Input.GetAxisRaw("Vertical");

            //if (xAxisMove != 0)
            //if (yAxisMove != 0)
            //if (zAxisMove != 0) 

            OnXAxisMove?.Invoke(xAxisMove);
            OnYAxisMove?.Invoke(yAxisMove);
            OnZAxisMove?.Invoke(zAxisMove);
        }
    }
}