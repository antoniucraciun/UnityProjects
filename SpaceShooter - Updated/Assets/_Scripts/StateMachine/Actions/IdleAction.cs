using UnityEngine;

namespace StateMachine
{
    [CreateAssetMenu(fileName = "IdleAction", menuName = "PluggableAI/Action/IdleAction")]
    public class IdleAction : Action
    {
        public override void Act(StateController controller)
        {
            controller.enemyController.idle = true;
        }
    }
}