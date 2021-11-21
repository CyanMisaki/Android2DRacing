using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace AssetBundles
{
    public class AssetBundleViewBase : MonoBehaviour
    {
        private const string UrlAssetBundleSprites = "https://drive.google.com/uc?export=download&id=1JoP3g31Mruuk7kAEWJfrgzAwzUFYyVtN";

        [SerializeField] private DataSpriteBundle[] _dataSpriteBundles;

        private AssetBundle _spriteAssetBundle;
        
        internal DateTime _bundleTime;
        internal DateTime _addressablesTime;

        protected IEnumerator DownloadAndSetAssetBundle()
        {
            yield return GetSpritesAssetBundle();

            if (_spriteAssetBundle == null)
            {
                Debug.LogError("ErrorAssetBundle");
                yield break;
            }

            SetDownloadAsset();
            yield return null;
            
        }

        private IEnumerator GetSpritesAssetBundle()
        {
            var request = UnityWebRequestAssetBundle.GetAssetBundle(UrlAssetBundleSprites);
            yield return request.SendWebRequest();

            while (!request.isDone)
                yield return null;
            StateRequest(request, ref _spriteAssetBundle);
        }

        private void StateRequest(UnityWebRequest request, ref AssetBundle assetBundle)
        {
            if (request.error == null)
            {
                assetBundle = DownloadHandlerAssetBundle.GetContent(request);
                Debug.Log("Complete Assets Loading");
            }
            else
            {
                Debug.LogError(request.error);
            }
        }

        private void SetDownloadAsset()
        {
            foreach (var data in _dataSpriteBundles)
            {
                data.Image.sprite = _spriteAssetBundle.LoadAsset<Sprite>(data.AssetBundleName);
            }
            Debug.Log($"{Math.Abs(_bundleTime.Millisecond-DateTime.Now.Millisecond)} ms. bundle downloading and setting");
        }
    }
}