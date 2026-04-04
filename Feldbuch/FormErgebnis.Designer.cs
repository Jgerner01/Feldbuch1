namespace Feldbuch;

partial class FormErgebnis
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        lblTitel        = new Label();
        lblTrennlinie   = new Label();
        lblStandpunkt   = new Label();
        lblInstHoehe    = new Label();
        lblR            = new Label();
        lblH            = new Label();
        lblHoehe        = new Label();
        lblOrient       = new Label();
        lblMassstab     = new Label();
        lblS0           = new Label();
        lblIter         = new Label();
        lblTrennlinie2  = new Label();
        lblResTitle     = new Label();
        dgvResiduen     = new DataGridView();
        btnNeuBerechnen = new Button();
        btnSchliessen   = new Button();

        SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvResiduen).BeginInit();

        var monoFont = new Font("Courier New", 10F);
        var boldFont = new Font("Segoe UI", 11F, FontStyle.Bold);

        // ── Fenster ───────────────────────────────────────────────────────────
        Text            = "Ergebnis – Freie Stationierung";
        StartPosition   = FormStartPosition.CenterParent;
        AutoScaleMode   = AutoScaleMode.Font;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox     = false;

        // ── Titel ─────────────────────────────────────────────────────────────
        lblTitel.Text     = "Freie Stationierung  –  Ergebnis";
        lblTitel.Location = new Point(20, 15);
        lblTitel.Size     = new Size(820, 30);
        lblTitel.Font     = new Font("Segoe UI", 14F, FontStyle.Bold);

        lblTrennlinie.BorderStyle = BorderStyle.Fixed3D;
        lblTrennlinie.Location    = new Point(20, 52);
        lblTrennlinie.Size        = new Size(820, 2);

        // ── Info-Labels ───────────────────────────────────────────────────────
        int y = 62, step = 24;
        foreach (Label lbl in new[]
            { lblStandpunkt, lblInstHoehe, lblR, lblH, lblHoehe,
              lblOrient, lblMassstab, lblS0, lblIter })
        {
            lbl.Location = new Point(20, y);
            lbl.Size     = new Size(820, 22);
            lbl.Font     = monoFont;
            y += step;
        }
        y += 4;

        // ── Zweite Trennlinie ─────────────────────────────────────────────────
        lblTrennlinie2.BorderStyle = BorderStyle.Fixed3D;
        lblTrennlinie2.Location    = new Point(20, y);
        lblTrennlinie2.Size        = new Size(820, 2);
        y += 8;

        // ── Residuen-Tabelle ──────────────────────────────────────────────────
        lblResTitle.Text     = "Residuen pro Anschlusspunkt:";
        lblResTitle.Location = new Point(20, y);
        lblResTitle.Size     = new Size(500, 24);
        lblResTitle.Font     = boldFont;
        y += 30;

        dgvResiduen.Location            = new Point(20, y);
        dgvResiduen.Size                = new Size(820, 220);
        dgvResiduen.AllowUserToAddRows  = false;
        dgvResiduen.ReadOnly            = false;
        dgvResiduen.SelectionMode       = DataGridViewSelectionMode.FullRowSelect;
        dgvResiduen.Font                = new Font("Courier New", 10F);
        dgvResiduen.RowHeadersVisible   = false;
        dgvResiduen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvResiduen.ColumnHeadersDefaultCellStyle.Font =
            new Font("Segoe UI", 9F, FontStyle.Bold);
        dgvResiduen.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;

        // ── Spalten ───────────────────────────────────────────────────────────
        // Reihenfolge: Punkt | Str.h | v Winkel [cc] | v Quer [mm] | [Hz] | v Längs [mm] | [Str] | v Höhe [mm] | [Hoe]

        var colPunktNr  = new DataGridViewTextBoxColumn
            { Name = "PunktNr",  HeaderText = "Punkt",          ReadOnly = true, FillWeight = 15 };
        var colStreckeH = new DataGridViewTextBoxColumn
            { Name = "StreckeH", HeaderText = "Str.h [m]",      ReadOnly = true, FillWeight = 13 };
        var colVWinkel  = new DataGridViewTextBoxColumn
            { Name = "vWinkel",  HeaderText = "v Winkel [cc]",  ReadOnly = true, FillWeight = 14 };
        var colVQuer    = new DataGridViewTextBoxColumn
            { Name = "vQuer",    HeaderText = "v Quer [mm]",    ReadOnly = true, FillWeight = 13 };
        var colAktivHz  = new DataGridViewCheckBoxColumn
        {
            Name        = "colAktivHz",
            HeaderText  = "Hz",
            ToolTipText = "Richtungsbeobachtung aktiv",
            FillWeight  = 6,
            Width       = 38,
            AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
            TrueValue   = true,
            FalseValue  = false
        };
        var colVLängs   = new DataGridViewTextBoxColumn
            { Name = "vLängs",   HeaderText = "v Längs [mm]",   ReadOnly = true, FillWeight = 13 };
        var colAktivStr = new DataGridViewCheckBoxColumn
        {
            Name        = "colAktivStr",
            HeaderText  = "Str",
            ToolTipText = "Streckenbeobachtung aktiv",
            FillWeight  = 6,
            Width       = 38,
            AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
            TrueValue   = true,
            FalseValue  = false
        };
        var colVHoehe   = new DataGridViewTextBoxColumn
            { Name = "vHoehe",   HeaderText = "v Höhe [mm]",    ReadOnly = true, FillWeight = 13 };
        var colAktivHoe = new DataGridViewCheckBoxColumn
        {
            Name        = "colAktivHoehe",
            HeaderText  = "Hoe",
            ToolTipText = "Höhenbeobachtung aktiv",
            FillWeight  = 6,
            Width       = 38,
            AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
            TrueValue   = true,
            FalseValue  = false
        };

        foreach (var col in new[] { colVWinkel, colVQuer, colVLängs, colVHoehe })
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

        dgvResiduen.Columns.AddRange(
            colPunktNr, colStreckeH,
            colVWinkel, colVQuer, colAktivHz,
            colVLängs, colAktivStr,
            colVHoehe, colAktivHoe);

        // Events für Checkbox-Spalten: sofort commit + Neuberechnung
        dgvResiduen.CurrentCellDirtyStateChanged += (s, e) =>
        {
            if (dgvResiduen.IsCurrentCellDirty)
            {
                var colName = dgvResiduen.CurrentCell?.OwningColumn.Name;
                if (colName is "colAktivHz" or "colAktivStr" or "colAktivHoehe")
                    dgvResiduen.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        };
        dgvResiduen.CellValueChanged += (s, e) =>
        {
            if (e.ColumnIndex >= 0)
            {
                string colName = dgvResiduen.Columns[e.ColumnIndex].Name;
                if (colName is "colAktivHz" or "colAktivStr" or "colAktivHoehe")
                    OnAktivierungGeaendert();
            }
        };

        y += 228;

        // ── Schaltflächen ─────────────────────────────────────────────────────
        btnNeuBerechnen.Text      = "↻ Neu berechnen";
        btnNeuBerechnen.Location  = new Point(20, y);
        btnNeuBerechnen.Size      = new Size(160, 36);
        btnNeuBerechnen.Font      = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnNeuBerechnen.BackColor = Color.FromArgb(60, 130, 60);
        btnNeuBerechnen.ForeColor = Color.White;
        btnNeuBerechnen.FlatStyle = FlatStyle.Flat;
        btnNeuBerechnen.Click    += btnNeuBerechnen_Click;

        btnSchliessen.Text     = "Schliessen";
        btnSchliessen.Location = new Point(714, y);
        btnSchliessen.Size     = new Size(126, 36);
        btnSchliessen.Font     = new Font("Segoe UI", 10F);
        btnSchliessen.Click   += btnSchliessen_Click;

        Controls.AddRange(new Control[]
        {
            lblTitel, lblTrennlinie,
            lblStandpunkt, lblInstHoehe, lblR, lblH, lblHoehe,
            lblOrient, lblMassstab, lblS0, lblIter,
            lblTrennlinie2, lblResTitle, dgvResiduen,
            btnNeuBerechnen, btnSchliessen
        });

        ClientSize = new Size(860, y + 56);

        ((System.ComponentModel.ISupportInitialize)dgvResiduen).EndInit();
        ResumeLayout(false);
    }

    private Label         lblTitel        = null!;
    private Label         lblTrennlinie   = null!;
    private Label         lblTrennlinie2  = null!;
    private Label         lblStandpunkt   = null!;
    private Label         lblInstHoehe    = null!;
    private Label         lblR            = null!;
    private Label         lblH            = null!;
    private Label         lblHoehe        = null!;
    private Label         lblOrient       = null!;
    private Label         lblMassstab     = null!;
    private Label         lblS0           = null!;
    private Label         lblIter         = null!;
    private Label         lblResTitle     = null!;
    private DataGridView  dgvResiduen     = null!;
    private Button        btnNeuBerechnen = null!;
    private Button        btnSchliessen   = null!;
}
