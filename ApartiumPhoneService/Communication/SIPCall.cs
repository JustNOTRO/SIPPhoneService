using SIPSorcery.SIP.App;

namespace ApartiumPhoneService;

/// <summary>
/// Reperesents a SIP call
/// </summary>
public class SIPCall
{
    private readonly SIPUserAgent _userAgent;
    private readonly SIPServerUserAgent _serverUserAgent;
    private readonly ManualResetEvent _manualReset;
    private readonly VoIpAudioPlayer _audioPlayer;
    
    public SIPCall(SIPUserAgent userAgent, SIPServerUserAgent serverUserAgent, ManualResetEvent manualReset, VoIpAudioPlayer audioPlayer)
    {
        _userAgent = userAgent;
        _serverUserAgent = serverUserAgent;
        _manualReset = manualReset;
        _audioPlayer = audioPlayer;
        
        _manualReset.Reset(); // set the event as non-signaled 
    }

    public string GetId()
    {
        return _userAgent.Dialogue.CallId;
    }

    public VoIpAudioPlayer GetAudioPlayer()
    {
        return _audioPlayer;
    }
    
    public virtual void Hangup()
    {
        _userAgent.Hangup();
        _serverUserAgent.Hangup(true);
    }

    public void Proceed()
    {
        _manualReset.Set();
    }
}