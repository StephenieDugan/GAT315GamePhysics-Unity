using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsCollider : MonoBehaviour
{
string status;
    private void OnCollisionEnter(Collision collision)
	{
		status = "collision enter: " + collision.gameObject.name;
	}
private void OnCollisionStay(Collision collision)
	{
		status = "collision stay: " + collision.gameObject.name;
	}
private void OnCollisionExit(Collision collision)
	{
		status = "collision exit: " + collision.gameObject.name;
	}
private void OnTriggerEnter(Collider collision)
	{
		status = "trigger enter: " + collision.gameObject.name;
	}
private void OnTriggerStay(Collider collision)
	{
		status = "trigger stay: " + collision.gameObject.name;
	}
private void OnTriggerExit(Collider collision)
	{
		status = "trigger exit: " + collision.gameObject.name;
	}
private void OnGUI()
{
	GUI.skin.label.fontSize = 16;
	Vector2 screen = Camera.main.WorldToScreenPoint(transform.position);
	GUI.Label(new Rect(screen.x, Screen.height - screen.y, 250, 70), status);
}

}
