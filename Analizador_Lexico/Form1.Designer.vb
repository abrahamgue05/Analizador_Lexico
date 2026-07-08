<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        TabControl1 = New TabControl()
        TabPage3 = New TabPage()
        TableLayoutPanel1 = New TableLayoutPanel()
        TextBox3 = New RichTextBox()
        ListView2 = New ListView()
        Label3 = New Label()
        Label2 = New Label()
        MenuStrip1 = New MenuStrip()
        ArchivoToolStripMenuItem = New ToolStripMenuItem()
        NuevoToolStripMenuItem = New ToolStripMenuItem()
        AbrirToolStripMenuItem = New ToolStripMenuItem()
        GuardarToolStripMenuItem = New ToolStripMenuItem()
        SalirToolStripMenuItem = New ToolStripMenuItem()
        EdicionToolStripMenuItem = New ToolStripMenuItem()
        DeshacerToolStripMenuItem = New ToolStripMenuItem()
        CortarToolStripMenuItem = New ToolStripMenuItem()
        CopiarToolStripMenuItem = New ToolStripMenuItem()
        PegarToolStripMenuItem = New ToolStripMenuItem()
        SeleccionarTodoToolStripMenuItem = New ToolStripMenuItem()
        CompilarToolStripMenuItem = New ToolStripMenuItem()
        ListadoDePalabrasReservadasToolStripMenuItem = New ToolStripMenuItem()
        SepararTokensToolStripMenuItem = New ToolStripMenuItem()
        FormatoToolStripMenuItem = New ToolStripMenuItem()
        FuenteToolStripMenuItem = New ToolStripMenuItem()
        ColorToolStripMenuItem = New ToolStripMenuItem()
        AcercaDeToolStripMenuItem = New ToolStripMenuItem()
        OpenFileDialog1 = New OpenFileDialog()
        SaveFileDialog1 = New SaveFileDialog()
        ImageList1 = New ImageList(components)
        NotifyIcon1 = New NotifyIcon(components)
        ToolStrip1 = New ToolStrip()
        ToolStripButton1 = New ToolStripButton()
        ToolStripButton2 = New ToolStripButton()
        ToolStripButton3 = New ToolStripButton()
        ToolStripSeparator1 = New ToolStripSeparator()
        ToolStripButton4 = New ToolStripButton()
        ToolStripButton5 = New ToolStripButton()
        ToolStripButton6 = New ToolStripButton()
        TabControl1.SuspendLayout()
        TabPage3.SuspendLayout()
        TableLayoutPanel1.SuspendLayout()
        MenuStrip1.SuspendLayout()
        ToolStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' TabControl1
        ' 
        TabControl1.AllowDrop = True
        TabControl1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        TabControl1.Controls.Add(TabPage3)
        TabControl1.Font = New Font("Google Sans Code Medium", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        TabControl1.Location = New Point(14, 56)
        TabControl1.Margin = New Padding(5, 4, 5, 4)
        TabControl1.Name = "TabControl1"
        TabControl1.SelectedIndex = 0
        TabControl1.Size = New Size(1205, 905)
        TabControl1.TabIndex = 0
        ' 
        ' TabPage3
        ' 
        TabPage3.Controls.Add(TableLayoutPanel1)
        TabPage3.Controls.Add(Label3)
        TabPage3.Controls.Add(Label2)
        TabPage3.Font = New Font("Google Sans Code Proportional M", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        TabPage3.Location = New Point(4, 35)
        TabPage3.Margin = New Padding(5, 4, 5, 4)
        TabPage3.Name = "TabPage3"
        TabPage3.Size = New Size(1197, 866)
        TabPage3.TabIndex = 2
        TabPage3.Text = "Edicion"
        TabPage3.UseVisualStyleBackColor = True
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        TableLayoutPanel1.ColumnCount = 2
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 55F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 45F))
        TableLayoutPanel1.Controls.Add(TextBox3, 0, 0)
        TableLayoutPanel1.Controls.Add(ListView2, 1, 0)
        TableLayoutPanel1.Location = New Point(16, 79)
        TableLayoutPanel1.Margin = New Padding(5, 4, 5, 4)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 1
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel1.Size = New Size(1171, 757)
        TableLayoutPanel1.TabIndex = 5
        ' 
        ' TextBox3
        ' 
        TextBox3.Dock = DockStyle.Fill
        TextBox3.Font = New Font("Google Sans Code Medium", 11.2499981F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        TextBox3.Location = New Point(5, 4)
        TextBox3.Margin = New Padding(5, 4, 5, 4)
        TextBox3.Name = "TextBox3"
        TextBox3.Size = New Size(634, 749)
        TextBox3.TabIndex = 4
        TextBox3.Text = ""
        ' 
        ' ListView2
        ' 
        ListView2.Dock = DockStyle.Fill
        ListView2.Font = New Font("Google Sans Code Proportional M", 11.2499981F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        ListView2.GridLines = True
        ListView2.Location = New Point(649, 4)
        ListView2.Margin = New Padding(5, 4, 5, 4)
        ListView2.Name = "ListView2"
        ListView2.Size = New Size(517, 749)
        ListView2.TabIndex = 1
        ListView2.UseCompatibleStateImageBehavior = False
        ListView2.View = View.Details
        ' 
        ' Label3
        ' 
        Label3.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(665, 30)
        Label3.Margin = New Padding(5, 0, 5, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(46, 15)
        Label3.TabIndex = 3
        Label3.Text = "Tokens"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(16, 30)
        Label2.Margin = New Padding(5, 0, 5, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(45, 15)
        Label2.TabIndex = 2
        Label2.Text = "Codigo"
        ' 
        ' MenuStrip1
        ' 
        MenuStrip1.Font = New Font("Consolas", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        MenuStrip1.Items.AddRange(New ToolStripItem() {ArchivoToolStripMenuItem, EdicionToolStripMenuItem, CompilarToolStripMenuItem, FormatoToolStripMenuItem, AcercaDeToolStripMenuItem})
        MenuStrip1.Location = New Point(0, 0)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.Padding = New Padding(9, 4, 0, 4)
        MenuStrip1.Size = New Size(1239, 27)
        MenuStrip1.TabIndex = 1
        MenuStrip1.Text = "MenuStrip1"
        ' 
        ' ArchivoToolStripMenuItem
        ' 
        ArchivoToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {NuevoToolStripMenuItem, AbrirToolStripMenuItem, GuardarToolStripMenuItem, SalirToolStripMenuItem})
        ArchivoToolStripMenuItem.Name = "ArchivoToolStripMenuItem"
        ArchivoToolStripMenuItem.Size = New Size(68, 19)
        ArchivoToolStripMenuItem.Text = "&Archivo"
        ' 
        ' NuevoToolStripMenuItem
        ' 
        NuevoToolStripMenuItem.Image = My.Resources.Resources.text_document_outlined_symbol_icon_icons_com_57756
        NuevoToolStripMenuItem.Name = "NuevoToolStripMenuItem"
        NuevoToolStripMenuItem.ShortcutKeys = Keys.Control Or Keys.N
        NuevoToolStripMenuItem.Size = New Size(172, 22)
        NuevoToolStripMenuItem.Text = "&Nuevo"
        ' 
        ' AbrirToolStripMenuItem
        ' 
        AbrirToolStripMenuItem.Image = My.Resources.Resources._3643772_archive_archives_document_folder_open_113445
        AbrirToolStripMenuItem.Name = "AbrirToolStripMenuItem"
        AbrirToolStripMenuItem.ShortcutKeys = Keys.Control Or Keys.O
        AbrirToolStripMenuItem.Size = New Size(172, 22)
        AbrirToolStripMenuItem.Text = "&Abrir"
        ' 
        ' GuardarToolStripMenuItem
        ' 
        GuardarToolStripMenuItem.Image = My.Resources.Resources.save_file_option_icon_icons_com_73423
        GuardarToolStripMenuItem.Name = "GuardarToolStripMenuItem"
        GuardarToolStripMenuItem.ShortcutKeys = Keys.Control Or Keys.S
        GuardarToolStripMenuItem.Size = New Size(172, 22)
        GuardarToolStripMenuItem.Text = "&Guardar"
        ' 
        ' SalirToolStripMenuItem
        ' 
        SalirToolStripMenuItem.Image = My.Resources.Resources._4115235_exit_logout_sign_out_114030
        SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        SalirToolStripMenuItem.Size = New Size(172, 22)
        SalirToolStripMenuItem.Text = "&Salir"
        ' 
        ' EdicionToolStripMenuItem
        ' 
        EdicionToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {DeshacerToolStripMenuItem, CortarToolStripMenuItem, CopiarToolStripMenuItem, PegarToolStripMenuItem, SeleccionarTodoToolStripMenuItem})
        EdicionToolStripMenuItem.Name = "EdicionToolStripMenuItem"
        EdicionToolStripMenuItem.Size = New Size(68, 19)
        EdicionToolStripMenuItem.Text = "&Edicion"
        ' 
        ' DeshacerToolStripMenuItem
        ' 
        DeshacerToolStripMenuItem.Image = My.Resources.Resources.arrow_arrows_back_direction_left_navigation_right_icon_123237
        DeshacerToolStripMenuItem.Name = "DeshacerToolStripMenuItem"
        DeshacerToolStripMenuItem.ShortcutKeys = Keys.Control Or Keys.Z
        DeshacerToolStripMenuItem.Size = New Size(235, 22)
        DeshacerToolStripMenuItem.Text = "&Deshacer"
        ' 
        ' CortarToolStripMenuItem
        ' 
        CortarToolStripMenuItem.Image = My.Resources.Resources.square_cut_icon_icons_com_56037
        CortarToolStripMenuItem.Name = "CortarToolStripMenuItem"
        CortarToolStripMenuItem.ShortcutKeys = Keys.Control Or Keys.X
        CortarToolStripMenuItem.Size = New Size(235, 22)
        CortarToolStripMenuItem.Text = "&Cortar"
        ' 
        ' CopiarToolStripMenuItem
        ' 
        CopiarToolStripMenuItem.Image = My.Resources.Resources.copy_icon_128895
        CopiarToolStripMenuItem.Name = "CopiarToolStripMenuItem"
        CopiarToolStripMenuItem.ShortcutKeys = Keys.Control Or Keys.C
        CopiarToolStripMenuItem.Size = New Size(235, 22)
        CopiarToolStripMenuItem.Text = "&Copiar"
        ' 
        ' PegarToolStripMenuItem
        ' 
        PegarToolStripMenuItem.Image = My.Resources.Resources.clipboard_paste_button_icon_icons_com_72805
        PegarToolStripMenuItem.Name = "PegarToolStripMenuItem"
        PegarToolStripMenuItem.ShortcutKeys = Keys.Control Or Keys.V
        PegarToolStripMenuItem.Size = New Size(235, 22)
        PegarToolStripMenuItem.Text = "&Pegar"
        ' 
        ' SeleccionarTodoToolStripMenuItem
        ' 
        SeleccionarTodoToolStripMenuItem.Image = My.Resources.Resources.text_document_outlined_symbol_icon_icons_com_57756
        SeleccionarTodoToolStripMenuItem.Name = "SeleccionarTodoToolStripMenuItem"
        SeleccionarTodoToolStripMenuItem.ShortcutKeys = Keys.Control Or Keys.A
        SeleccionarTodoToolStripMenuItem.Size = New Size(235, 22)
        SeleccionarTodoToolStripMenuItem.Text = "&Seleccionar todo"
        ' 
        ' CompilarToolStripMenuItem
        ' 
        CompilarToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {ListadoDePalabrasReservadasToolStripMenuItem, SepararTokensToolStripMenuItem})
        CompilarToolStripMenuItem.Name = "CompilarToolStripMenuItem"
        CompilarToolStripMenuItem.Size = New Size(75, 19)
        CompilarToolStripMenuItem.Text = "&Compilar"
        ' 
        ' ListadoDePalabrasReservadasToolStripMenuItem
        ' 
        ListadoDePalabrasReservadasToolStripMenuItem.Name = "ListadoDePalabrasReservadasToolStripMenuItem"
        ListadoDePalabrasReservadasToolStripMenuItem.Size = New Size(284, 22)
        ListadoDePalabrasReservadasToolStripMenuItem.Text = "&Listado de Palabras Reservadas"
        ' 
        ' SepararTokensToolStripMenuItem
        ' 
        SepararTokensToolStripMenuItem.Name = "SepararTokensToolStripMenuItem"
        SepararTokensToolStripMenuItem.Size = New Size(284, 22)
        SepararTokensToolStripMenuItem.Text = "&Separar Tokens"
        ' 
        ' FormatoToolStripMenuItem
        ' 
        FormatoToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {FuenteToolStripMenuItem, ColorToolStripMenuItem})
        FormatoToolStripMenuItem.Name = "FormatoToolStripMenuItem"
        FormatoToolStripMenuItem.Size = New Size(68, 19)
        FormatoToolStripMenuItem.Text = "&Formato"
        ' 
        ' FuenteToolStripMenuItem
        ' 
        FuenteToolStripMenuItem.Name = "FuenteToolStripMenuItem"
        FuenteToolStripMenuItem.Size = New Size(116, 22)
        FuenteToolStripMenuItem.Text = "&Fuente"
        ' 
        ' ColorToolStripMenuItem
        ' 
        ColorToolStripMenuItem.Name = "ColorToolStripMenuItem"
        ColorToolStripMenuItem.Size = New Size(116, 22)
        ColorToolStripMenuItem.Text = "&Color"
        ' 
        ' AcercaDeToolStripMenuItem
        ' 
        AcercaDeToolStripMenuItem.Name = "AcercaDeToolStripMenuItem"
        AcercaDeToolStripMenuItem.Size = New Size(82, 19)
        AcercaDeToolStripMenuItem.Text = "&Acerca de"
        ' 
        ' OpenFileDialog1
        ' 
        OpenFileDialog1.FileName = "OpenFileDialog1"
        ' 
        ' ImageList1
        ' 
        ImageList1.ColorDepth = ColorDepth.Depth32Bit
        ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), ImageListStreamer)
        ImageList1.TransparentColor = Color.Transparent
        ImageList1.Images.SetKeyName(0, "save-file-option_icon-icons.com_73423.ico")
        ImageList1.Images.SetKeyName(1, "4115235-exit-logout-sign-out_114030.ico")
        ImageList1.Images.SetKeyName(2, "square-cut_icon-icons.com_56037.ico")
        ImageList1.Images.SetKeyName(3, "3643772-archive-archives-document-folder-open_113445.ico")
        ImageList1.Images.SetKeyName(4, "text-document-outlined-symbol_icon-icons.com_57756.ico")
        ImageList1.Images.SetKeyName(5, "copy_icon_128895.ico")
        ImageList1.Images.SetKeyName(6, "pen_create_compose_write_icon_145952.ico")
        ' 
        ' NotifyIcon1
        ' 
        NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), Icon)
        NotifyIcon1.Text = " "
        NotifyIcon1.Visible = True
        ' 
        ' ToolStrip1
        ' 
        ToolStrip1.Font = New Font("Consolas", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ToolStrip1.Items.AddRange(New ToolStripItem() {ToolStripButton1, ToolStripButton2, ToolStripButton3, ToolStripSeparator1, ToolStripButton4, ToolStripButton5, ToolStripButton6})
        ToolStrip1.Location = New Point(0, 27)
        ToolStrip1.Name = "ToolStrip1"
        ToolStrip1.Size = New Size(1239, 25)
        ToolStrip1.TabIndex = 2
        ToolStrip1.Text = "ToolStrip1"
        ' 
        ' ToolStripButton1
        ' 
        ToolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image
        ToolStripButton1.Image = My.Resources.Resources._3643772_archive_archives_document_folder_open_113445
        ToolStripButton1.ImageTransparentColor = Color.Magenta
        ToolStripButton1.Name = "ToolStripButton1"
        ToolStripButton1.Size = New Size(23, 22)
        ToolStripButton1.Text = "ToolStripButton1"
        ' 
        ' ToolStripButton2
        ' 
        ToolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.Image
        ToolStripButton2.Image = My.Resources.Resources.save_file_option_icon_icons_com_73423
        ToolStripButton2.ImageTransparentColor = Color.Magenta
        ToolStripButton2.Name = "ToolStripButton2"
        ToolStripButton2.Size = New Size(23, 22)
        ToolStripButton2.Text = "ToolStripButton2"
        ' 
        ' ToolStripButton3
        ' 
        ToolStripButton3.DisplayStyle = ToolStripItemDisplayStyle.Image
        ToolStripButton3.Image = My.Resources.Resources.pen_create_compose_write_icon_145952
        ToolStripButton3.ImageTransparentColor = Color.Magenta
        ToolStripButton3.Name = "ToolStripButton3"
        ToolStripButton3.Size = New Size(23, 22)
        ToolStripButton3.Text = "ToolStripButton3"
        ' 
        ' ToolStripSeparator1
        ' 
        ToolStripSeparator1.Name = "ToolStripSeparator1"
        ToolStripSeparator1.Size = New Size(6, 25)
        ' 
        ' ToolStripButton4
        ' 
        ToolStripButton4.DisplayStyle = ToolStripItemDisplayStyle.Image
        ToolStripButton4.Image = My.Resources.Resources.square_cut_icon_icons_com_56037
        ToolStripButton4.ImageTransparentColor = Color.Magenta
        ToolStripButton4.Name = "ToolStripButton4"
        ToolStripButton4.Size = New Size(23, 22)
        ToolStripButton4.Text = "ToolStripButton4"
        ' 
        ' ToolStripButton5
        ' 
        ToolStripButton5.DisplayStyle = ToolStripItemDisplayStyle.Image
        ToolStripButton5.Image = My.Resources.Resources.copy_icon_128895
        ToolStripButton5.ImageTransparentColor = Color.Magenta
        ToolStripButton5.Name = "ToolStripButton5"
        ToolStripButton5.Size = New Size(23, 22)
        ToolStripButton5.Text = "ToolStripButton5"
        ' 
        ' ToolStripButton6
        ' 
        ToolStripButton6.DisplayStyle = ToolStripItemDisplayStyle.Image
        ToolStripButton6.Image = My.Resources.Resources._4115235_exit_logout_sign_out_114030
        ToolStripButton6.ImageTransparentColor = Color.Magenta
        ToolStripButton6.Name = "ToolStripButton6"
        ToolStripButton6.Size = New Size(23, 22)
        ToolStripButton6.Text = "ToolStripButton6"
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(10F, 26F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1239, 974)
        Controls.Add(ToolStrip1)
        Controls.Add(TabControl1)
        Controls.Add(MenuStrip1)
        Font = New Font("Google Sans Code Proportional", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MainMenuStrip = MenuStrip1
        Margin = New Padding(5, 4, 5, 4)
        MinimumSize = New Size(1136, 1013)
        Name = "Form1"
        Text = "EditText"
        WindowState = FormWindowState.Maximized
        TabControl1.ResumeLayout(False)
        TabPage3.ResumeLayout(False)
        TabPage3.PerformLayout()
        TableLayoutPanel1.ResumeLayout(False)
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        ToolStrip1.ResumeLayout(False)
        ToolStrip1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents NotifyIcon1 As NotifyIcon
    Friend WithEvents ArchivoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NuevoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AbrirToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GuardarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SalirToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EdicionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeshacerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CortarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CopiarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PegarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SeleccionarTodoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents ToolStripButton3 As ToolStripButton
    Friend WithEvents ToolStripButton2 As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripButton4 As ToolStripButton
    Friend WithEvents ToolStripButton5 As ToolStripButton
    Friend WithEvents ToolStripButton6 As ToolStripButton
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents FormatoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FuenteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ColorToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AcercaDeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CompilarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ListadoDePalabrasReservadasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SepararTokensToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ListView2 As ListView
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox3 As RichTextBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel

End Class
