using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{
	public Collider bola;

	public float multiplier;

	public Color color1;
	public Color color2;
	public Color color3;

    private Renderer renderer;

	private Animator animator;

	private enum BumperState
	{
		color1,
		color2,
		color3
	}

	private BumperState state;

	private void Start()
	{
		renderer = GetComponent<Renderer>();
		animator = GetComponent<Animator>();

		state = BumperState.color1;
		renderer.material.color = color1;
	}
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.collider == bola)
		{
			Rigidbody bolaRig = bola.GetComponent<Rigidbody>();
			bolaRig.velocity *= multiplier;

			//anim
			animator.SetTrigger("hit");
			SetState();
		}
	}

	private void SetState()
    {
		if(state == BumperState.color1)
        {
			state = BumperState.color2;
			renderer.material.color = color2;
			return;

		}
		if(state == BumperState.color2)
        {
			state = BumperState.color3;
			renderer.material.color = color3;
			return;
		}
		if(state == BumperState.color3)
        {
			state = BumperState.color1;
			renderer.material.color = color1;
			return;
		}
    }
}
