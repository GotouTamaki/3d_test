using UnityEngine;
using UnityEngine.UI;

public class MemorySizeDisplay : MonoBehaviour
{
    [SerializeField] private Text _displayText;
    [SerializeField] private PlayerMoveRecorder playerMoveRecorder;

    private void Update()
    {
        _displayText.text = $"PlayerRecords : " +
                            $"{Unity.Collections.LowLevel.Unsafe.UnsafeUtility.SizeOf(typeof(Record)) * playerMoveRecorder.PlayerRecords.Count}byte" +
                            $"\nTime : {Time.time.ToString("0.000")}s";
    }
}
