using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour
{
  public Transform target;
  public Tilemap tileMap;
  private Vector3 bottomLeftLimit, topRightLimit;
  private float halfHeight, halfWidth;
  void Start()
  {
    // target = PlayerController.instance.transform;
    target = FindObjectOfType<PlayerController>().transform;

    halfHeight = Camera.main.orthographicSize;
    halfWidth = halfHeight * Camera.main.aspect;

    bottomLeftLimit = tileMap.localBounds.min + new Vector3(halfWidth, halfHeight, 0f);
    topRightLimit = tileMap.localBounds.max + new Vector3(-halfWidth, -halfHeight, 0f);

    PlayerController.instance.SetBounds(tileMap.localBounds.min, tileMap.localBounds.max);
  }

  void LateUpdate()
  {
    transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);

    // keep the camera inside the tilemap bounds
    transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x), Mathf.Clamp(transform.position.y, bottomLeftLimit.y, topRightLimit.y), transform.position.z);
  }
}
