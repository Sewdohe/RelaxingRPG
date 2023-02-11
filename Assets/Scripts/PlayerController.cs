using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  public Rigidbody2D rigidBody;
  public float movementSpeed;
  public Animator myAnim;
  public static PlayerController instance;
  public string areaTransitionName;
  private Vector3 bottomLeftLimit, topRightLimit;
  public bool canMove = true;


  void Start()
  {
    if (instance == null)
    {
      instance = this;
    }
    else
    {
      if(instance != this)
      {
        Destroy(gameObject);
      }
    }

    DontDestroyOnLoad(gameObject);
  }

  void Update()
  {
    if(canMove)
    {
      rigidBody.velocity = new Vector2(
          Input.GetAxisRaw("Horizontal"),
          Input.GetAxisRaw("Vertical")
          ) * movementSpeed;

      myAnim.SetFloat("moveX", rigidBody.velocity.x);
      myAnim.SetFloat("moveY", rigidBody.velocity.y);

    } else {
      rigidBody.velocity = Vector2.zero;
    }

    if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1
    || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
    {
      if(canMove)
      {
        myAnim.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
        myAnim.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
      }
    }

    // keep the player inside the tilemap bounds
    transform.position =
      new Vector3(
        Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x),
        Mathf.Clamp(transform.position.y, bottomLeftLimit.y, topRightLimit.y), transform.position.z
      );
  }

  public void SetBounds(Vector3 bottomLeft, Vector3 topRight)
  {
    bottomLeftLimit = bottomLeft + new Vector3(0.7f, 0.7f, 0f);
    topRightLimit = topRight + new Vector3(-0.7f, -0.7f, 0f);
  }
}
