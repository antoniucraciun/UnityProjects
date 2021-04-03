using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

namespace StateMachine
{
	[CreateAssetMenu(fileName = "State", menuName = "PluggableAI/State", order = 0)]
	public class State : ScriptableObject
	{
		public Action[] actions;
		public Transition[] transitions;
		public Color sceneGizmosColor = Color.green;

		public void UpdateState(StateController controller)
		{
			DoActions(controller);
			CheckTransitions(controller);
		}

		private void DoActions(StateController controller)
		{
			for (int i = 0; i < actions.Length; i++)
			{
				actions[i].Act(controller);
			}
		}	

		private void CheckTransitions(StateController controller)
		{
			for (int i = 0; i < transitions.Length; i++)
			{
				bool decisionsSucceeded = transitions[i].decision.Decide(controller);
				if (decisionsSucceeded)
				{
					controller.TransitionToState(transitions[i].trueState);
					return;
				}
				else
				{
					controller.TransitionToState(transitions[i].falseState);
				}
			}
		}
	}
}