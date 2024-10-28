using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraMotor : MonoBehaviour
{
	public Transform lookAt;

	public Vector3 offset = new(0.0f, 4.0f, -10.0f);

	[SerializeField]
	float smoothness = 2.0f;

	public Vector3 rotation = new(35.0f, 0.0f, 0.0f);

	public bool IsMoving {
		get; set;
	}

	private void LateUpdate()
	{
		if (!IsMoving)
			return;

		var cameraTargetPosition = lookAt.position + offset;
		cameraTargetPosition.x = 0f;

		transform.SetPositionAndRotation(
			Vector3.Lerp(transform.position, cameraTargetPosition, smoothness),
			Quaternion.Lerp(transform.rotation, Quaternion.Euler(rotation), .2f)
		);
	}
}
