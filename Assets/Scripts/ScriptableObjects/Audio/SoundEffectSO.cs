using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "NewSoundEffect", menuName = "Audio/New Sound Effect")]
    public class SoundEffectSO : ScriptableObject
    {
        #region config

        public AudioClip[] clips;
        public Vector2 volume = new Vector2(0.5f, 0.5f);
        public Vector2 pitch = new Vector2(1, 1);

        [SerializeField] private SoundClipPlayOrder playOrder;

        [SerializeField]
        private int playIndex = 0;

        #endregion

        #region PreviewCode

#if UNITY_EDITOR
        private AudioSource previewer;

        private void OnEnable()
        {
            previewer = EditorUtility
                .CreateGameObjectWithHideFlags("AudioPreview", HideFlags.HideAndDontSave,
                    typeof(AudioSource))
                .GetComponent<AudioSource>();
        }

        private void OnDisable()
        {
            DestroyImmediate(previewer.gameObject);
        }

        // The functions: "PlayPreview" and "StopPreview"
        // Are made public in order to use them in the editor tool
        // So don't use them anywhere else unless you know what your'e doing
        public void PlayPreview()
        {
            Play(previewer);
        }

        public void StopPreview()
        {
            previewer.Stop();
        }
#endif

        #endregion

        private AudioClip GetAudioClip()
        {
            // get current clip
            var clip = clips[playIndex >= clips.Length ? 0 : playIndex];

            // find next clip
            switch (playOrder)
            {
                case SoundClipPlayOrder.in_order:
                    playIndex = (playIndex + 1) % clips.Length;
                    break;
                case SoundClipPlayOrder.random:
                    playIndex = Random.Range(0, clips.Length);
                    break;
                case SoundClipPlayOrder.reverse:
                    playIndex = (playIndex + clips.Length - 1) % clips.Length;
                    break;
            }

            // return clip
            return clip;
        }

        public AudioSource Play(AudioSource audioSourceParam = null)
        {
            if (clips.Length == 0)
            {
                Debug.Log($"Missing sound clips for {name}");
                return null;
            }

            var source = audioSourceParam;
            if (source == null)
            {
                var _obj = new GameObject("Sound", typeof(AudioSource));
                source = _obj.GetComponent<AudioSource>();
            }

            // set source config:
            source.clip = GetAudioClip();
            source.volume = Random.Range(volume.x, volume.y);
            source.pitch = Random.Range(pitch.x, pitch.y);

            source.Play();

#if UNITY_EDITOR
            if (source != previewer)
            {
                Destroy(source.gameObject, source.clip.length / source.pitch);
            }
#else
                Destroy(source.gameObject, source.clip.length / source.pitch);
#endif
            return source;
        }

        enum SoundClipPlayOrder
        {
            random,
            in_order,
            reverse
        }
    }
}