using UnityEngine;
using System.Collections;

public class RearWheelDrive : MonoBehaviour {
    private const float numyavas = 0.50F;
    private const float numhizli = 0.96F;

    private const int ileri = 1;
    private const int geri = 2;
    private const int sag = 3;
    private const int sol = 4;
    private int current = 0;
    private WheelCollider[] wheels;
    public static bool blink = false; // if false dont do anything, if yes then change

	public float maxAngle = 30;
	public float maxTorque = 300;
	public GameObject wheelShape;
    private GameObject araba;


    // here we find all the WheelColliders down in the hierarchy
    public void Start()
	{
		wheels = GetComponentsInChildren<WheelCollider>();
        araba = GameObject.FindWithTag("carRoot");

        for (int i = 0; i < wheels.Length; ++i) 
		{
			var wheel = wheels [i];

			// create wheel shapes only when needed
			if (wheelShape != null)
			{
				var ws = GameObject.Instantiate (wheelShape);
				ws.transform.parent = wheel.transform;
			}
		}
	}

	// this is a really simple approach to updating wheels
	// here we simulate a rear wheel drive car and assume that the car is perfectly symmetric at local zero
	// this helps us to figure our which wheels are front ones and which are rear
	public void Update()
	{
        float torque = 0f;
        blink = false;
        // bu yon degisme , attension sonra
        bool spaceGeldi =Input.GetKey(KeyCode.Space);
        float deger = Input.GetAxis("Vertical"); //0.0 0.96 arasi gibi 
        if (spaceGeldi)
        {
            blink = true;
            if (current == 0)
            {
                current = ileri;
            }
            if(current == ileri)
            {
                araba.transform.Rotate(0,0,0,Space.Self);
                current++;

            }
            else if (current == geri)
            {
                araba.transform.Rotate(0, 90, 0, Space.Self);
                current++;
            }
            else if (current == sag)
            {   
                araba.transform.Rotate(0, 180, 0, Space.Self);
                current++;
            }
            else if(current == sol)
            {
                araba.transform.Rotate(0, 270, 0, Space.Self);
                current = ileri;
            }
        }
        
            if(deger >=0.0f && deger <=0.5f)
                torque = maxTorque * numyavas;//  Input.GetAxis("Vertical");
            else if (deger >0.5f && deger <=1f)
             torque = maxTorque * numhizli;//  Input.GetAxis("Vertical");

        print("%f is GetVertical" + torque / maxTorque + "\n");
        print("cyurent"+ current + "\n");
   


        foreach (WheelCollider wheel in wheels)
		{
			// a simple car where front wheels steer while rear ones drive
			//if (wheel.transform.localPosition.z > 0)
			//	wheel.steerAngle = angle;

			if (wheel.transform.localPosition.z < 0)
				wheel.motorTorque = torque;

			// update visual wheels if any
			if (wheelShape) 
			{
				Quaternion q;
				Vector3 p;
				wheel.GetWorldPose (out p, out q);

				// assume that the only child of the wheelcollider is the wheel shape
				Transform shapeTransform = wheel.transform.GetChild (0);
				shapeTransform.position = p;
				shapeTransform.rotation = q;
			}

		}
	}
}
