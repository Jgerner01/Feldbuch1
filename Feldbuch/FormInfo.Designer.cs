namespace Feldbuch;

partial class FormInfo
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        picIcon      = new PictureBox();
        lblName      = new Label();
        lblVersion   = new Label();
        lblAutor     = new Label();
        lblCopyright = new Label();
        lblTrenn1    = new Label();
        lblHilfe     = new Label();
        lblHilfeText = new Label();
        lblTrenn2    = new Label();
        btnOK        = new Button();

        ((System.ComponentModel.ISupportInitialize)picIcon).BeginInit();
        SuspendLayout();

        // ── Fenster ───────────────────────────────────────────────────────────
        ClientSize      = new Size(440, 400);
        Text            = "Info";
        StartPosition   = FormStartPosition.CenterParent;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox     = false;
        MinimizeBox     = false;
        AutoScaleMode   = AutoScaleMode.Font;

        // ── Programm-Icon ─────────────────────────────────────────────────────
        picIcon.Location  = new Point(24, 24);
        picIcon.Size      = new Size(48, 48);
        picIcon.SizeMode  = PictureBoxSizeMode.Zoom;
        picIcon.Image     = SystemIcons.Application.ToBitmap();

        // ── Programmname ──────────────────────────────────────────────────────
        lblName.Text      = "Feldbuch";
        lblName.Location  = new Point(86, 22);
        lblName.Size      = new Size(320, 34);
        lblName.Font      = new Font("Segoe UI", 18F, FontStyle.Bold);
        lblName.ForeColor = Color.FromArgb(30, 60, 110);

        // ── Version ───────────────────────────────────────────────────────────
        lblVersion.Text      = "Version 1.1.0";
        lblVersion.Location  = new Point(88, 58);
        lblVersion.Size      = new Size(320, 22);
        lblVersion.Font      = new Font("Segoe UI", 10F);
        lblVersion.ForeColor = Color.FromArgb(80, 80, 80);

        // ── Trennlinie 1 ──────────────────────────────────────────────────────
        lblTrenn1.BorderStyle = BorderStyle.Fixed3D;
        lblTrenn1.Location    = new Point(20, 84);
        lblTrenn1.Size        = new Size(400, 2);

        // ── Beschreibung ──────────────────────────────────────────────────────
        var lblBeschreibung = new Label
        {
            Text      = "Geodätisches Feldbuch mit Freier Stationierung,\nTachymeteranbindung und DXF-Viewer.",
            Location  = new Point(24, 98),
            Size      = new Size(396, 44),
            Font      = new Font("Segoe UI", 9.5F),
            ForeColor = Color.FromArgb(50, 50, 50)
        };

        // ── Autor / Copyright ─────────────────────────────────────────────────
        lblAutor.Text      = "Autor:   Johann Gerner";
        lblAutor.Location  = new Point(24, 152);
        lblAutor.Size      = new Size(396, 22);
        lblAutor.Font      = new Font("Segoe UI", 9.5F);

        lblCopyright.Text      = "© 2026 Johann Gerner";
        lblCopyright.Location  = new Point(24, 174);
        lblCopyright.Size      = new Size(396, 22);
        lblCopyright.Font      = new Font("Segoe UI", 9F);
        lblCopyright.ForeColor = Color.FromArgb(100, 100, 100);

        // ── Trennlinie 2 ──────────────────────────────────────────────────────
        lblTrenn2.BorderStyle = BorderStyle.Fixed3D;
        lblTrenn2.Location    = new Point(20, 208);
        lblTrenn2.Size        = new Size(400, 2);

        // ── Hilfe-Abschnitt ───────────────────────────────────────────────────
        lblHilfe.Text      = "Hilfe";
        lblHilfe.Location  = new Point(24, 220);
        lblHilfe.Size      = new Size(200, 22);
        lblHilfe.Font      = new Font("Segoe UI", 10F, FontStyle.Bold);

        lblHilfeText.Text =
            "• Bluetooth-Gerät zuerst über Windows-Einstellungen koppeln,\n" +
            "  dann unter Tachymeter Kommunikation den COM-Port wählen.\n" +
            "• DXF-Datei über den DXF Viewer öffnen.\n" +
            "• Freie Stationierung benötigt mind. 2 bekannte Punkte im DXF.";
        lblHilfeText.Location  = new Point(24, 244);
        lblHilfeText.Size      = new Size(396, 100);
        lblHilfeText.Font      = new Font("Segoe UI", 9F);
        lblHilfeText.ForeColor = Color.FromArgb(50, 50, 50);

        // ── OK-Button ─────────────────────────────────────────────────────────
        btnOK.Text      = "OK";
        btnOK.Location  = new Point(334, 354);
        btnOK.Size      = new Size(84, 32);
        btnOK.Font      = new Font("Segoe UI", 10F);
        btnOK.Click    += btnOK_Click;

        Controls.AddRange(
        [
            picIcon, lblName, lblVersion,
            lblTrenn1, lblBeschreibung,
            lblAutor, lblCopyright,
            lblTrenn2, lblHilfe, lblHilfeText,
            btnOK
        ]);

        AcceptButton = btnOK;
        ((System.ComponentModel.ISupportInitialize)picIcon).EndInit();
        ResumeLayout(false);
    }

    private PictureBox picIcon;
    private Label      lblName;
    private Label      lblVersion;
    private Label      lblAutor;
    private Label      lblCopyright;
    private Label      lblTrenn1;
    private Label      lblHilfe;
    private Label      lblHilfeText;
    private Label      lblTrenn2;
    private Button     btnOK;
}
