#if UNITY_EDITOR
#define DEBUG_LogStateMachine
#endif
using UnityEngine;

namespace StateMachine
{
    [CreateAssetMenu(fileName = "MoveDecision", menuName = "PluggableAI/Decision/MoveDecision", order = 1)]
    public class MoveDecision : Decision
    {
        public override bool Decide(StateController controller)
        {
            bool levelStarted = Move(controller);
            return levelStarted;
        }

        private bool Move(StateController controller)
        {
            if (controller.enemyController.idle == true)
            {
                controller.enemyController.idle = false;
                return true;
            }
            if (Vector2.Distance(controller.enemyController.movementPattern.GetPositionAt(controller.enemyController.enemyId), controller.enemyController.transform.position) < 0.1f)
                return false;
            if (controller.enemyController.enabled)
                return true;
            return false;
        }
    }
}