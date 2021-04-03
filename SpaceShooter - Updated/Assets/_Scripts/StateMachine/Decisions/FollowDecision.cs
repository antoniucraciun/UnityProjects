using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine
{
    [CreateAssetMenu(fileName = "FollowDecision", menuName = "PluggableAI/Decision/FollowDecision")]
    public class FollowDecision : Decision
    {
        public override bool Decide(StateController controller)
        {
            bool follow = Follow(controller);
            return follow;
        }

        private bool Follow(StateController controller)
        {
            if (!controller.enemyController.objToFollow.activeInHierarchy)
                return false;
            if (controller.enemyController.b_targetPlayer)
                return true;
            return false;
        }
    }
}
