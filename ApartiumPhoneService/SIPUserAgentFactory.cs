using SIPSorcery.SIP;

namespace ApartiumPhoneService;

/// <summary>
/// UserAgent factory
/// </summary>
public class SIPUserAgentFactory : ISIPUserAgentFactory
{
    public virtual SIPUserAgentWrapper Create(SIPTransport sipTransport, SIPEndPoint outboundProxy)
    {
        return new SIPUserAgentWrapper(sipTransport, outboundProxy);
    }
}