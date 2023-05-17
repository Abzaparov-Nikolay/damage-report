using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
	public Reference<float> Max;
	public Reference<float> Current;
	public Reference<bool> InvincibilityState;
	[SerializeField] private UnityEvent onDamaged;
	[SerializeField] private UnityEvent onCurrentZero;

	public void TakeDamage(float damage)
	{
		if (InvincibilityState.Value)
			return;

		Current.Set(Current - damage);
		if (Current > 0)
		{
			onDamaged?.Invoke();
		}
		else
		{
			onCurrentZero.Invoke();
		}
	}

	private void OnEnable()
	{
		Current.Set(Max);
	}
}
