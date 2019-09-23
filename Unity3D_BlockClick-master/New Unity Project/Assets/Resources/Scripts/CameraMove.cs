using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Camera camera;
    private Vector3 gap;
    private Quaternion targetRotation;

    void Update()
    {
        //이동
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        //플레이어
        Vector3 v = ((transform.forward * z) + (transform.right * x)).normalized * 3;
        transform.position += v * Time.deltaTime;

        //자유시점
        //v = ((camera.transform.forward * z) + (camera.transform.right * x)).normalized * 1.5f;
        //camera.transform.position += v * Time.deltaTime;

        RotatePlayerAndCamera();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().AddForce(Vector3.up * 5f, ForceMode.Impulse);
        }
        
        GameObject.FindWithTag("Respawn").transform.position = new Vector3(transform.position.x, 180, transform.position.z);
    }

    private void RotatePlayerAndCamera()
    {
        //마우스에 따른 회전
        //gap.x += Input.GetAxis("Mouse Y") * 1.5f * -1;
        //gap.y += Input.GetAxis("Mouse X") * 1.5f;
        //gap.z = 0f;

        //// 카메라 회전범위 제한.
        //gap.x = Mathf.Clamp(gap.x, -90f, 90f);

        //// 회전 값을 변수에 저장.
        //targetRotation = Quaternion.Euler(gap);

        //// 카메라벡터 객체에 Axis객체의 x,z회전 값을 제외한 y값만을 넘긴다.
        //camera.transform.rotation = targetRotation;

        //transform.rotation = Quaternion.Euler(0, gap.y, 0); //플레이어 회전

        float x = Input.GetAxis("Mouse Y") * -1;
        float y = Input.GetAxis("Mouse X");

        Vector3 temp = new Vector3(x, y) * 1.5f;
        
        //PlayerMotor.RotatePC(temp) { rot += temp; }
        gap += temp;
        gap.x = Mathf.Clamp(gap.x, -90f, 90f);

        camera.transform.rotation = Quaternion.Euler(gap);
        transform.rotation = Quaternion.Euler(0f, gap.y, 0f);

    }
}
