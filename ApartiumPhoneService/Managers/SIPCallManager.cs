using System.Collections.Concurrent;
using Microsoft.Extensions.Logging;

namespace ApartiumPhoneService.Managers;

/// <summary>
/// Manages ongoing calls
/// </summary>
public class SIPCallManager
{
    /// <summary>
    /// a dictionary that keeps track of an active calls on the server
    /// </summary>
    private readonly ConcurrentDictionary<string, SIPCall> _calls = new();
    
    /// <summary>
    /// Tries to add the call to the active calls
    /// </summary>
    /// <param name="callId">the call id</param>
    /// <param name="call">the ongoing call</param>
    /// <returns>True if succeeded, false otherwise</returns>
    protected virtual bool TryAddCall(string callId, SIPCall call)
    {
        return _calls.TryAdd(callId, call);
    }
    
    /// <summary>
    /// Tries to remove the active call
    /// </summary>
    /// <param name="callId"></param>
    /// <returns>the removed call, otherwise null</returns>
    public virtual SIPCall? TryRemoveCall(string callId)
    {
        _calls.TryRemove(callId, out var call);
        return call;
    }
    
    /// <summary>
    /// Starts a call
    /// </summary>
    /// <param name="call">the call to start</param>
    public async Task StartCall(SIPCall call)
    {
        if (!TryAddCall(call.GetId(), call))
        {
            ApartiumPhoneServer.GetLogger().LogWarning("Could not add call to active calls");
        }
        
        var audioPlayer = call.GetAudioPlayer();
        await Task.Run(() => audioPlayer.Play(VoIpSound.WelcomeSound));
        await Task.Run(() => audioPlayer.Play(VoIpSound.ExplanationSound));
        call.Proceed(); // signaling the call to continue after introduction
    }

    /// <summary>
    /// Flush all ongoing calls
    /// </summary>
    public void Flush()
    {
        foreach (var call in _calls.Values)
        {
            call.Hangup();
        }
        
        _calls.Clear();
    }
}