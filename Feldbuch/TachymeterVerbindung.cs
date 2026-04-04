using System.IO.Ports;

namespace Feldbuch;

public enum TachymeterModell
{
    LeicaTCR307,
    LeicaTS06,
    LeicaTS11,
    TrimbleS3,
    TopconGPT3000,
    SokkiaSET,
    Manuell
}

public static class TachymeterVerbindung
{
    // ── Einstellungen ─────────────────────────────────────────────────────────
    public static TachymeterModell Modell   { get; set; } = TachymeterModell.LeicaTCR307;
    public static string           Port     { get; set; } = "";
    public static int              BaudRate { get; set; } = 9600;
    public static int              DataBits { get; set; } = 8;
    public static Parity           Parität  { get; set; } = Parity.None;
    public static StopBits         StopBits { get; set; } = StopBits.One;

    // ── Verbindung ────────────────────────────────────────────────────────────
    private static SerialPort? _port;
    public  static bool IstVerbunden => _port?.IsOpen ?? false;

    public static void Verbinden()
    {
        if (IstVerbunden) return;
        if (string.IsNullOrEmpty(Port))
            throw new InvalidOperationException("Kein COM-Port ausgewählt.");

        _port = new SerialPort(Port, BaudRate, Parität, DataBits, StopBits)
        {
            ReadTimeout  = 2000,
            WriteTimeout = 2000
        };
        _port.Open();
    }

    public static void Trennen()
    {
        _port?.Close();
        _port?.Dispose();
        _port = null;
    }

    // ── Voreinstellungen je Modell ────────────────────────────────────────────
    public static (int Baud, int Bits, Parity Par, StopBits Stop) GetPreset(TachymeterModell m) =>
        m switch
        {
            TachymeterModell.LeicaTCR307   => (9600, 8, Parity.None, StopBits.One),
            TachymeterModell.LeicaTS06     => (9600, 8, Parity.None, StopBits.One),
            TachymeterModell.LeicaTS11     => (9600, 8, Parity.None, StopBits.One),
            TachymeterModell.TrimbleS3     => (9600, 8, Parity.None, StopBits.One),
            TachymeterModell.TopconGPT3000 => (9600, 8, Parity.None, StopBits.One),
            TachymeterModell.SokkiaSET     => (9600, 8, Parity.None, StopBits.One),
            _                              => (9600, 8, Parity.None, StopBits.One)
        };

    // ── Anzeigetexte ──────────────────────────────────────────────────────────
    public static string ModellAnzeige(TachymeterModell m) => m switch
    {
        TachymeterModell.LeicaTCR307   => "Leica TCR307",
        TachymeterModell.LeicaTS06     => "Leica TS06",
        TachymeterModell.LeicaTS11     => "Leica TS11",
        TachymeterModell.TrimbleS3     => "Trimble S3",
        TachymeterModell.TopconGPT3000 => "Topcon GPT-3000",
        TachymeterModell.SokkiaSET     => "Sokkia SET",
        TachymeterModell.Manuell       => "Manuell",
        _                              => m.ToString()
    };

    public static TachymeterModell[] AlleModelle =>
    [
        TachymeterModell.LeicaTCR307,
        TachymeterModell.LeicaTS06,
        TachymeterModell.LeicaTS11,
        TachymeterModell.TrimbleS3,
        TachymeterModell.TopconGPT3000,
        TachymeterModell.SokkiaSET,
        TachymeterModell.Manuell,
    ];
}
