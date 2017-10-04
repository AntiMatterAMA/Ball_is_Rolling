using UnityEngine;

public class CameraFollow : MonoBehaviour {

  public Transform TargetTransform;
  public float CameraFollowSpeed = 3f;
  public Vector3 Offset = new Vector3(0f,30f,0f);

  private Vector3 _thisPosition;
  private Vector3 _repositionTargetDirection;

  public void Start()
  {
    _thisPosition = transform.position;
  }

  private void FixedUpdate()
  {
    if (TargetTransform == null)
      return;

    var targetTransformPosition = TargetTransform.position + Offset;
    _repositionTargetDirection.x = targetTransformPosition.x - _thisPosition.x;
    _repositionTargetDirection.y = targetTransformPosition.y - _thisPosition.y;
    _repositionTargetDirection.z = targetTransformPosition.z - _thisPosition.z;

    _thisPosition = _thisPosition + (_repositionTargetDirection.normalized * _repositionTargetDirection.magnitude * CameraFollowSpeed * Time.deltaTime);

    transform.position = _thisPosition;
  }
}
