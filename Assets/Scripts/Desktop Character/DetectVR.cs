using UnityEngine;
using UnityEngine.XR.Management;

public class DetectVR : MonoBehaviour
{

    public bool startInVR = true;
    public GameObject xrOrigin;
    public GameObject desktopCharacter;


    void Start()
    {
        if (startInVR)
        {

            var xrSettings = XRGeneralSettings.Instance;
            if (xrSettings == null)
            {
                Debug.Log("XRGeneralSettings is null");
                return;
            }

            var xrManager = xrSettings.Manager;
            if (xrManager == null)
            {
                Debug.Log("XRManagerSettings is null");
                return;
            }

            var xrLoader = xrManager.activeLoader;
            if (xrLoader == null)
            {
                Debug.Log("XRLoader is null");
                xrOrigin.SetActive(false);
                desktopCharacter.SetActive(true);
                return;
            }
        
        } else{

            xrOrigin.SetActive(true);
            desktopCharacter.SetActive(false);

        }
        
    }

}
