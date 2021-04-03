using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine
{
    [CreateAssetMenu(fileName = "DodgeDecision", menuName = "PluggableAI/Decision/DodgeDecision")]
    public class DodgeDecision : Decision
    {

        public override bool Decide(StateController controller)
        {
            bool dodge = Dodge(controller);
            return dodge;
        }

        private bool Dodge(StateController controller)
        {
            if (controller.enemyController.b_dodge)
            {
                return true;
            }
            return false;
        }
    }
}