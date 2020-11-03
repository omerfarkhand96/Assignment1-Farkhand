using UnityEngine;
using System.Collections;
public class MouseAim : MonoBehaviour
{
    public Transform spine;
    public Transform weapon;
    public GameObject crosshairImage;
    public Vector2 xLimit = new Vector2(-30f, 30f);
    public Vector2 yLimit = new Vector2(-30f, 30f);
    private float xAxis = 0f;
    private float yAxis = 0f;
    public void LateUpdate()
    {
        RotateSpine();
        ShowCrosshairIfRaycastHit();
    }
    private void RotateSpine()
    {
        yAxis += Input.GetAxis("Mouse X");
        yAxis = Mathf.Clamp(yAxis, yLimit.x, yLimit.y);
        xAxis -= Input.GetAxis("Mouse Y");
        xAxis = Mathf.Clamp(xAxis, xLimit.x, xLimit.y);
        Vector3 newSpineRotation = new Vector3(xAxis,
        yAxis, spine.localEulerAngles.z);
        spine.localEulerAngles = newSpineRotation;
    }
    private void ShowCrosshairIfRaycastHit()
    {
        Vector3 weaponForwardDirection = weapon.TransformDirection(Vector3.forward);
        RaycastHit hit;
        Vector3 fromPosition = weapon.position +
        Vector3.one;
        if (Physics.Raycast(fromPosition,
        weaponForwardDirection, out hit))
        {
            Vector3 hitLocation = Camera.main.WorldToScreenPoint(hit.point);
            DisplayPointerImage(hitLocation);
        }
        else
            crosshairImage.SetActive(false);
    }
    private void DisplayPointerImage(Vector3 hitLocation)
    {
        crosshairImage.transform.position = hitLocation;
        crosshairImage.SetActive(true);
    }
}