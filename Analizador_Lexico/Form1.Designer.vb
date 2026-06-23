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
        TabPage1 = New TabPage()
        Button2 = New Button()
        TextBox2 = New TextBox()
        Button1 = New Button()
        TextBox1 = New TextBox()
        TabPage2 = New TabPage()
        ListView1 = New ListView()
        Button3 = New Button()
        ComboBox1 = New ComboBox()
        Label1 = New Label()
        TabPage3 = New TabPage()
        TextBox3 = New TextBox()
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
        ListView2 = New ListView()
        Label2 = New Label()
        Label3 = New Label()
        TabControl1.SuspendLayout()
        TabPage1.SuspendLayout()
        TabPage2.SuspendLayout()
        TabPage3.SuspendLayout()
        MenuStrip1.SuspendLayout()
        ToolStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' TabControl1
        ' 
        TabControl1.AllowDrop = True
        TabControl1.Controls.Add(TabPage1)
        TabControl1.Controls.Add(TabPage2)
        TabControl1.Controls.Add(TabPage3)
        TabControl1.Location = New Point(12, 52)
        TabControl1.Name = "TabControl1"
        TabControl1.SelectedIndex = 0
        TabControl1.Size = New Size(814, 457)
        TabControl1.TabIndex = 0
        ' 
        ' TabPage1
        ' 
        TabPage1.Controls.Add(Button2)
        TabPage1.Controls.Add(TextBox2)
        TabPage1.Controls.Add(Button1)
        TabPage1.Controls.Add(TextBox1)
        TabPage1.Location = New Point(4, 24)
        TabPage1.Name = "TabPage1"
        TabPage1.Padding = New Padding(3)
        TabPage1.Size = New Size(806, 429)
        TabPage1.TabIndex = 0
        TabPage1.Text = "Abrir Archivo"
        TabPage1.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(252, 17)
        Button2.Name = "Button2"
        Button2.Size = New Size(75, 23)
        Button2.TabIndex = 3
        Button2.Text = "Examinar"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' TextBox2
        ' 
        TextBox2.Location = New Point(87, 17)
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(159, 23)
        TextBox2.TabIndex = 2
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(6, 17)
        Button1.Name = "Button1"
        Button1.Size = New Size(75, 23)
        Button1.TabIndex = 1
        Button1.Text = "Archivo"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(6, 62)
        TextBox1.Multiline = True
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(797, 361)
        TextBox1.TabIndex = 0
        ' 
        ' TabPage2
        ' 
        TabPage2.Controls.Add(ListView1)
        TabPage2.Controls.Add(Button3)
        TabPage2.Controls.Add(ComboBox1)
        TabPage2.Controls.Add(Label1)
        TabPage2.Location = New Point(4, 24)
        TabPage2.Name = "TabPage2"
        TabPage2.Padding = New Padding(3)
        TabPage2.Size = New Size(806, 429)
        TabPage2.TabIndex = 1
        TabPage2.Text = "Seleccionar"
        TabPage2.UseVisualStyleBackColor = True
        ' 
        ' ListView1
        ' 
        ListView1.Location = New Point(5, 41)
        ListView1.Name = "ListView1"
        ListView1.Size = New Size(795, 382)
        ListView1.TabIndex = 3
        ListView1.UseCompatibleStateImageBehavior = False
        ' 
        ' Button3
        ' 
        Button3.Location = New Point(195, 9)
        Button3.Name = "Button3"
        Button3.Size = New Size(75, 23)
        Button3.TabIndex = 2
        Button3.Text = "Seleccionar"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' ComboBox1
        ' 
        ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBox1.FormattingEnabled = True
        ComboBox1.Location = New Point(68, 9)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(121, 23)
        ComboBox1.TabIndex = 1
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(5, 17)
        Label1.Name = "Label1"
        Label1.Size = New Size(57, 15)
        Label1.TabIndex = 0
        Label1.Text = "Extension"
        ' 
        ' TabPage3
        ' 
        TabPage3.Controls.Add(Label3)
        TabPage3.Controls.Add(Label2)
        TabPage3.Controls.Add(ListView2)
        TabPage3.Controls.Add(TextBox3)
        TabPage3.Location = New Point(4, 24)
        TabPage3.Name = "TabPage3"
        TabPage3.Size = New Size(806, 429)
        TabPage3.TabIndex = 2
        TabPage3.Text = "Edicion"
        TabPage3.UseVisualStyleBackColor = True
        ' 
        ' TextBox3
        ' 
        TextBox3.Location = New Point(12, 47)
        TextBox3.Multiline = True
        TextBox3.Name = "TextBox3"
        TextBox3.ScrollBars = ScrollBars.Both
        TextBox3.Size = New Size(467, 369)
        TextBox3.TabIndex = 0
        TextBox3.WordWrap = False
        ' 
        ' MenuStrip1
        ' 
        MenuStrip1.Items.AddRange(New ToolStripItem() {ArchivoToolStripMenuItem, EdicionToolStripMenuItem, CompilarToolStripMenuItem, FormatoToolStripMenuItem, AcercaDeToolStripMenuItem})
        MenuStrip1.Location = New Point(0, 0)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.Size = New Size(838, 24)
        MenuStrip1.TabIndex = 1
        MenuStrip1.Text = "MenuStrip1"
        ' 
        ' ArchivoToolStripMenuItem
        ' 
        ArchivoToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {NuevoToolStripMenuItem, AbrirToolStripMenuItem, GuardarToolStripMenuItem, SalirToolStripMenuItem})
        ArchivoToolStripMenuItem.Name = "ArchivoToolStripMenuItem"
        ArchivoToolStripMenuItem.Size = New Size(60, 20)
        ArchivoToolStripMenuItem.Text = "&Archivo"
        ' 
        ' NuevoToolStripMenuItem
        ' 
        NuevoToolStripMenuItem.Image = My.Resources.Resources.text_document_outlined_symbol_icon_icons_com_57756
        NuevoToolStripMenuItem.Name = "NuevoToolStripMenuItem"
        NuevoToolStripMenuItem.ShortcutKeys = Keys.Control Or Keys.N
        NuevoToolStripMenuItem.Size = New Size(156, 22)
        NuevoToolStripMenuItem.Text = "&Nuevo"
        ' 
        ' AbrirToolStripMenuItem
        ' 
        AbrirToolStripMenuItem.Image = My.Resources.Resources._3643772_archive_archives_document_folder_open_113445
        AbrirToolStripMenuItem.Name = "AbrirToolStripMenuItem"
        AbrirToolStripMenuItem.ShortcutKeys = Keys.Control Or Keys.O
        AbrirToolStripMenuItem.Size = New Size(156, 22)
        AbrirToolStripMenuItem.Text = "&Abrir"
        ' 
        ' GuardarToolStripMenuItem
        ' 
        GuardarToolStripMenuItem.Image = My.Resources.Resources.save_file_option_icon_icons_com_73423
        GuardarToolStripMenuItem.Name = "GuardarToolStripMenuItem"
        GuardarToolStripMenuItem.ShortcutKeys = Keys.Control Or Keys.S
        GuardarToolStripMenuItem.Size = New Size(156, 22)
        GuardarToolStripMenuItem.Text = "&Guardar"
        ' 
        ' SalirToolStripMenuItem
        ' 
        SalirToolStripMenuItem.Image = My.Resources.Resources._4115235_exit_logout_sign_out_114030
        SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        SalirToolStripMenuItem.Size = New Size(156, 22)
        SalirToolStripMenuItem.Text = "&Salir"
        ' 
        ' EdicionToolStripMenuItem
        ' 
        EdicionToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {DeshacerToolStripMenuItem, CortarToolStripMenuItem, CopiarToolStripMenuItem, PegarToolStripMenuItem, SeleccionarTodoToolStripMenuItem})
        EdicionToolStripMenuItem.Name = "EdicionToolStripMenuItem"
        EdicionToolStripMenuItem.Size = New Size(58, 20)
        EdicionToolStripMenuItem.Text = "&Edicion"
        ' 
        ' DeshacerToolStripMenuItem
        ' 
        DeshacerToolStripMenuItem.Image = My.Resources.Resources.arrow_arrows_back_direction_left_navigation_right_icon_123237
        DeshacerToolStripMenuItem.Name = "DeshacerToolStripMenuItem"
        DeshacerToolStripMenuItem.ShortcutKeys = Keys.Control Or Keys.Z
        DeshacerToolStripMenuItem.Size = New Size(204, 22)
        DeshacerToolStripMenuItem.Text = "&Deshacer"
        ' 
        ' CortarToolStripMenuItem
        ' 
        CortarToolStripMenuItem.Image = My.Resources.Resources.square_cut_icon_icons_com_56037
        CortarToolStripMenuItem.Name = "CortarToolStripMenuItem"
        CortarToolStripMenuItem.ShortcutKeys = Keys.Control Or Keys.X
        CortarToolStripMenuItem.Size = New Size(204, 22)
        CortarToolStripMenuItem.Text = "&Cortar"
        ' 
        ' CopiarToolStripMenuItem
        ' 
        CopiarToolStripMenuItem.Image = My.Resources.Resources.copy_icon_128895
        CopiarToolStripMenuItem.Name = "CopiarToolStripMenuItem"
        CopiarToolStripMenuItem.ShortcutKeys = Keys.Control Or Keys.C
        CopiarToolStripMenuItem.Size = New Size(204, 22)
        CopiarToolStripMenuItem.Text = "&Copiar"
        ' 
        ' PegarToolStripMenuItem
        ' 
        PegarToolStripMenuItem.Image = My.Resources.Resources.clipboard_paste_button_icon_icons_com_72805
        PegarToolStripMenuItem.Name = "PegarToolStripMenuItem"
        PegarToolStripMenuItem.ShortcutKeys = Keys.Control Or Keys.V
        PegarToolStripMenuItem.Size = New Size(204, 22)
        PegarToolStripMenuItem.Text = "&Pegar"
        ' 
        ' SeleccionarTodoToolStripMenuItem
        ' 
        SeleccionarTodoToolStripMenuItem.Image = My.Resources.Resources.text_document_outlined_symbol_icon_icons_com_57756
        SeleccionarTodoToolStripMenuItem.Name = "SeleccionarTodoToolStripMenuItem"
        SeleccionarTodoToolStripMenuItem.ShortcutKeys = Keys.Control Or Keys.A
        SeleccionarTodoToolStripMenuItem.Size = New Size(204, 22)
        SeleccionarTodoToolStripMenuItem.Text = "&Seleccionar todo"
        ' 
        ' CompilarToolStripMenuItem
        ' 
        CompilarToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {ListadoDePalabrasReservadasToolStripMenuItem, SepararTokensToolStripMenuItem})
        CompilarToolStripMenuItem.Name = "CompilarToolStripMenuItem"
        CompilarToolStripMenuItem.Size = New Size(68, 20)
        CompilarToolStripMenuItem.Text = "&Compilar"
        ' 
        ' ListadoDePalabrasReservadasToolStripMenuItem
        ' 
        ListadoDePalabrasReservadasToolStripMenuItem.Name = "ListadoDePalabrasReservadasToolStripMenuItem"
        ListadoDePalabrasReservadasToolStripMenuItem.Size = New Size(236, 22)
        ListadoDePalabrasReservadasToolStripMenuItem.Text = "&Listado de Palabras Reservadas"
        ' 
        ' SepararTokensToolStripMenuItem
        ' 
        SepararTokensToolStripMenuItem.Name = "SepararTokensToolStripMenuItem"
        SepararTokensToolStripMenuItem.Size = New Size(236, 22)
        SepararTokensToolStripMenuItem.Text = "&Separar Tokens"
        ' 
        ' FormatoToolStripMenuItem
        ' 
        FormatoToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {FuenteToolStripMenuItem, ColorToolStripMenuItem})
        FormatoToolStripMenuItem.Name = "FormatoToolStripMenuItem"
        FormatoToolStripMenuItem.Size = New Size(64, 20)
        FormatoToolStripMenuItem.Text = "&Formato"
        ' 
        ' FuenteToolStripMenuItem
        ' 
        FuenteToolStripMenuItem.Name = "FuenteToolStripMenuItem"
        FuenteToolStripMenuItem.Size = New Size(110, 22)
        FuenteToolStripMenuItem.Text = "&Fuente"
        ' 
        ' ColorToolStripMenuItem
        ' 
        ColorToolStripMenuItem.Name = "ColorToolStripMenuItem"
        ColorToolStripMenuItem.Size = New Size(110, 22)
        ColorToolStripMenuItem.Text = "&Color"
        ' 
        ' AcercaDeToolStripMenuItem
        ' 
        AcercaDeToolStripMenuItem.Name = "AcercaDeToolStripMenuItem"
        AcercaDeToolStripMenuItem.Size = New Size(71, 20)
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
        ToolStrip1.Items.AddRange(New ToolStripItem() {ToolStripButton1, ToolStripButton2, ToolStripButton3, ToolStripSeparator1, ToolStripButton4, ToolStripButton5, ToolStripButton6})
        ToolStrip1.Location = New Point(0, 24)
        ToolStrip1.Name = "ToolStrip1"
        ToolStrip1.Size = New Size(838, 25)
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
        ' ListView2
        ' 
        ListView2.GridLines = True
        ListView2.Location = New Point(507, 47)
        ListView2.Name = "ListView2"
        ListView2.Size = New Size(268, 369)
        ListView2.TabIndex = 1
        ListView2.UseCompatibleStateImageBehavior = False
        ListView2.View = View.Details
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(12, 17)
        Label2.Name = "Label2"
        Label2.Size = New Size(45, 15)
        Label2.TabIndex = 2
        Label2.Text = "Codigo"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(507, 17)
        Label3.Name = "Label3"
        Label3.Size = New Size(46, 15)
        Label3.TabIndex = 3
        Label3.Text = "Tokens"
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(838, 521)
        Controls.Add(ToolStrip1)
        Controls.Add(TabControl1)
        Controls.Add(MenuStrip1)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MainMenuStrip = MenuStrip1
        Name = "Form1"
        Text = "EditText"
        TabControl1.ResumeLayout(False)
        TabPage1.ResumeLayout(False)
        TabPage1.PerformLayout()
        TabPage2.ResumeLayout(False)
        TabPage2.PerformLayout()
        TabPage3.ResumeLayout(False)
        TabPage3.PerformLayout()
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        ToolStrip1.ResumeLayout(False)
        ToolStrip1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
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
    Friend WithEvents Button2 As Button
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents ListView1 As ListView
    Friend WithEvents Button3 As Button
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents TextBox3 As TextBox
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

End Class
