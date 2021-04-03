#if UNITY_EDITOR
#define DEBUG_LogStateMachine
#endif
using UnityEngine;

namespace StateMachine
{
    [CreateAssetMenu(fileName = "DodgeAction", menuName = "PluggableAI/Action/DodgeAction")]
    public class DodgeAction : Action
    {

        public override void Act(StateController controller)
        {
            Dodge(controller);
        }

        private void Dodge(StateController controller)
        {
            if (controller.enemyController.dodgeRight)
            {
                if (controller.enemyController.timeToDodge >= 0)
                {
                    controller.enemyController.timeToDodge -= Time.deltaTime;
                    Move(controller, Vector2.right, controller.enemyController.enemyData.speed);
                }
                else
                {
                    controller.enemyController.timeToDodge = controller.enemyController.enemyData.initialTimeToDodge;
                    Move(controller, Vector2.zero, controller.enemyController.enemyData.speed);
                    controller.enemyController.dodgeRight = !controller.enemyController.dodgeRight;
                    controller.enemyController.b_dodge = false;
                }
            }
            else
            {
                if (controller.enemyController.timeToDodge >= 0)
                {
                    controller.enemyController.timeToDodge -= Time.deltaTime;
                    Move(controller, Vector2.left, controller.enemyController.enemyData.speed);
                }
                else
                {
                    controller.enemyController.timeToDodge = controller.enemyController.enemyData.initialTimeToDodge;
                    Move(controller, Vector2.zero, controller.enemyController.enemyData.speed);
                    controller.enemyController.dodgeRight = !controller.enemyController.dodgeRight;
                    controller.enemyController.b_dodge = false;
                }
            }
        }

        public void Move(StateController controller, Vector2 direction, float speed)
        {
            Vector2 newMoveDirection = direction * speed;
            controller.enemyController.rb2d.velocity = newMoveDirection;
        }
    }
}