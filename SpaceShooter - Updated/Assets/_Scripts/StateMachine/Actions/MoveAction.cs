#if UNITY_EDITOR
#define DEBUG_LogStateMachine
#endif
using UnityEngine;

namespace StateMachine
{
    [CreateAssetMenu(fileName = "MoveAction", menuName = "PluggableAI/Action/MoveAction")]
    public class MoveAction : Action
    {
        public override void Act(StateController controller)
        {
            Move(controller);
        }

        private void Move(StateController controller)
        {
            Vector2 direction = controller.enemyController.movementPattern.GetPositionAt(controller.enemyController.enemyId) - (Vector2)controller.enemyController.transform.position;
            if (Vector2.Distance(controller.enemyController.movementPattern.GetPositionAt(controller.enemyController.enemyId), controller.enemyController.transform.position) < 0.1f)
            {
                direction = Vector2.zero;
                controller.enemyController.rb2d.velocity = direction.normalized * controller.enemyController.enemyData.speed;
            }
            controller.enemyController.rb2d.velocity = direction.normalized * controller.enemyController.enemyData.speed;
        }
    }
}