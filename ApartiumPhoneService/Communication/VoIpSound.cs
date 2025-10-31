namespace ApartiumPhoneService;

public class VoIpSound(string destination)
{
    public string GetDestination()
    {
        return destination;
    }
    
    public static readonly VoIpSound WelcomeSound = new("Sounds/welcome.wav");
    public static readonly VoIpSound ExplanationSound = new("Sounds/explanation.wav");
    public static readonly VoIpSound NumbersNotFound = new("Sounds/numbers-not-found.wav");
    private static readonly VoIpSound ZeroSound = new("Sounds/zero.wav");
    private static readonly VoIpSound OneSound = new("Sounds/one.wav");
    private static readonly VoIpSound TwoSound = new("Sounds/two.wav");
    private static readonly VoIpSound ThreeSound = new("Sounds/three.wav");
    private static readonly VoIpSound FourSound = new("Sounds/four.wav");
    private static readonly VoIpSound FiveSound = new("Sounds/five.wav");
    private static readonly VoIpSound SixSound = new("Sounds/six.wav");
    private static readonly VoIpSound SevenSound = new("Sounds/seven.wav");
    private static readonly VoIpSound EightSound = new("Sounds/eight.wav");
    private static readonly VoIpSound NineSound = new("Sounds/nine.wav");

    public static VoIpSound[] Values()
    {
        return
        [
            ZeroSound,
            OneSound,
            TwoSound,
            ThreeSound,
            FourSound,
            FiveSound,
            SixSound,
            SevenSound,
            EightSound,
            NineSound
        ];
    }
    
    
}