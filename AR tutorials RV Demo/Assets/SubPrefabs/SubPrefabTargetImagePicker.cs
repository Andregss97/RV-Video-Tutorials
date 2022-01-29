using UnityEngine;
using UnityEngine.Video;
using UnityEngine.XR.ARSubsystems;

namespace RVir.GrupoTres
{

    /// <summary>
    /// Allows you to choose which of the images in the given XRReferenceImageLibrary 
    /// this SubPrefab responds to. Remember to add this component to the SubPrefabManager!
    /// </summary>
    public class SubPrefabTargetImagePicker : MonoBehaviour
    {
        public VideoClip clip;
        public XRReferenceImageLibrary referenceImageLibrary;
        public XRReferenceImage image;

        public virtual void TurnOn()
        {
            gameObject.SetActive(true);
        }

        public virtual void TurnOff()
        {
            gameObject.SetActive(false);
            Destroy(this);
        }
    }
}