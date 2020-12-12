using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;
using TMPro;

public class PlayerCtrl : MonoBehaviour
{
  public float speed =10;
  public TextMeshProUGUI countText;
  public GameObject winTextObject;
  private Rigidbody rb;
  private float movementX, movementY;
  private int count;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
    }
    void SetCountText(){
      countText .text = "Score: " + count.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
   /* void OnMove(InputValue movementValue){
      Vector2 movementVector = movementValue.Get<Vector2>();
      movementX = movementVector.x;
      movementY = movementVector.y;
    }*/

    private void FixedUpdate(){
      Vector3 movement = new Vector3(movementX,0.0f,movementY);
      rb.AddForce(movement*speed);
    }
    private void OnTriggerEnter (Collider other){
      other.gameObject.SetActive(false);
      count++;
      this.transform.localScale += new Vector3(0.03f,0.03f,0.03f);
      SetCountText();
      if(count == 24)   winTextObject.SetActive(true);

    }
}
