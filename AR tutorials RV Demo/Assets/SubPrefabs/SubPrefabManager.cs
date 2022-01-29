using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;

namespace RVir.GrupoTres
{
    /// <summary>
    /// Manages SubPrefabTargetImagePicker components. Add to the root object of your prefab.
    /// </summary>
    public class SubPrefabManager : MonoBehaviour
    {
        public List<SubPrefabTargetImagePicker> SubPrefabs = new List<SubPrefabTargetImagePicker>();

        private ARTrackedImage _trackedImage = null;
        public ARTrackedImage trackedImage
        {
            get => _trackedImage ??= GetComponent<ARTrackedImage>();
        }

        void Start()
        {
            if (trackedImage != null)
            {
                foreach (SubPrefabTargetImagePicker picker in SubPrefabs)
                {
                    Debug.Log(picker.image.name);
                    if (picker.image == trackedImage?.referenceImage && (universalPlayer.staticPlayer.clip == picker.clip || picker.clip == null)){
                        picker.TurnOn();
                    }
                    else
                        picker.TurnOff();
                }
            }
        }

        public bool childrenVisible(){
            Renderer[] childrenRenderers = GetComponentsInChildren<Renderer>();

            bool children = false;
            foreach(Renderer r in childrenRenderers)
            {
                children = r.isVisible || children;
            }
            return children;
        }

        public void showArrows(){
            //Debug.Log("show Arrows");
            ArrowManager.RequestShowArrows(this);
        }

        public void hideArrows(){
            //Debug.Log("hide Arrows");
            ArrowManager.RequestHideArrows(this);
        }
    
        void Update(){
            if(childrenVisible()){
                hideArrows();
            }
            else{
                showArrows();
            }

            foreach (var subPrefab in SubPrefabs)
            {
                // Is the playing clip the same as the clip configured on the SubPrefab
                bool shouldBeOn = (subPrefab.clip == null || subPrefab.clip == universalPlayer.staticPlayer.clip);

                // SubPrefab should be active when the correct clip is playing, and vice-versa
                if (subPrefab.gameObject.activeSelf != shouldBeOn)
                    subPrefab.gameObject.SetActive(shouldBeOn);
            }
        }
    }
}