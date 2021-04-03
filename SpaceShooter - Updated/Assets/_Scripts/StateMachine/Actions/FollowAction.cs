using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine
{
    [CreateAssetMenu(fileName = "FollowAction", menuName = "PluggableAI/Action/FollowAction")]
    public class FollowAction : Action
    {
        public override void Act(StateController controller)
        {
            Follow(controller);
        }

        private void Follow(StateController controller)
        {
            Vector2 direction = controller.enemyController.objToFollow.transform.position - controller.enemyController.transform.position;
            float distance = direction.magnitude;
            if (controller.enemyController.timeToFollow >= 0 && distance > controller.enemyController.enemyData.distanceToObject)
            {
                controller.enemyController.timeToFollow -= Time.deltaTime;
                Move(controller, direction.normalized, controller.enemyController.enemyData.speed);
            }
            else
            {
                controller.enemyController.b_targetPlayer = false;
                controller.enemyController.timeToFollow = controller.enemyController.enemyData.initialTimeToFollow;
                Move(controller, Vector2.zero, controller.enemyController.enemyData.speed);
            }
        }

        public void Move(StateController controller, Vector2 direction, float speed)
        {
            Vector2 newMoveDirection = direction * speed;
            controller.enemyController.rb2d.velocity = newMoveDirection;
        }
    }
}