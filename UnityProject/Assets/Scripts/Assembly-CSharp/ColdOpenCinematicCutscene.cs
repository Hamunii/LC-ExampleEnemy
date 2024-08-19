using UnityEngine;
using UnityEngine.InputSystem;

public class ColdOpenCinematicCutscene : MonoBehaviour
{
	public Camera cam;

	public Transform camContainer;

	public Transform camTarget;

	private InputActionAsset inputAsset;

	public float cameraUp;

	public float maxCameraUp;

	public float minCameraUp;

	[Space(5f)]
	public float cameraTurn;

	public float maxCameraTurn;

	public float minCameraTurn;

	private float startInputTimer;

	public Animator cameraAnimator;

	public float lookSens;

	private void TurnCamera(Vector2 input)
	{
	}

	public void Start()
	{
	}

	public void Update()
	{
	}

	public void ShakeCameraSmall()
	{
	}

	public void ShakeCameraLong()
	{
	}

	public void EndColdOpenCutscene()
	{
	}
}
