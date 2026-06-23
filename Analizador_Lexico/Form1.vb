Imports System.Text.RegularExpressions

Public Class Form1

#Region "Variables"
    ' Variable global para almacenar la ruta y nombre del archivo
    Dim nombreArchivo As String
#End Region

    ' ====================================================================
    ' MENU: NUEVO ARCHIVO
    ' ====================================================================
    Private Sub NuevoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoToolStripMenuItem.Click
        ' Limpiamos el editor de texto correcto (TextBox3)
        TextBox3.Text = ""
        ' Nos movemos a la pestaña de edicion (indice 2 = TabPage3)
        TabControl1.SelectedIndex = 2
    End Sub

    ' ====================================================================
    ' MENU: GUARDAR
    ' ====================================================================
    Private Sub GuardarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarToolStripMenuItem.Click
        ' Validamos que el TextBox3 no este vacio
        If TextBox3.Text = "" Then
            MsgBox("El archivo no puede estar vacio!!!", MsgBoxStyle.Critical, "Contenido vacio!!")
            TabControl1.SelectedIndex = 2
        Else
            ' Pedimos un nombre temporal
            nombreArchivo = InputBox("Escribe un nombre para el archivo")

            With SaveFileDialog1
                .FileName = nombreArchivo
                .Filter = "Archivos de texto|*.txt|Todos los archivos|*.*"

                ' Abrimos la ventana de guardado y validamos si el usuario dio "Aceptar"
                If .ShowDialog() = DialogResult.OK Then
                    nombreArchivo = .FileName ' Actualizamos con la ruta completa
                    Guardar() ' Llamamos a nuestra funcion personalizada
                End If
            End With
        End If
    End Sub

    ' ====================================================================
    ' FUNCION PERSONALIZADA: GUARDAR FISICAMENTE EN EL DISCO
    ' ====================================================================
    Private Sub Guardar()
        ' 1. Escribimos el archivo en el disco usando StreamWriter
        Dim sw As New IO.StreamWriter(nombreArchivo, False, System.Text.Encoding.Default)

        ' Usamos .Lines en TextBox3 para guardar respetando los saltos de linea
        For Each linea In TextBox3.Lines
            sw.WriteLine(linea)
        Next
        sw.Close()

        ' 2. Anadimos el archivo a la lista de recientes (ListView1)
        Dim archivoExiste As Boolean = False

        ' Recorremos el ListView para ver si la ruta ya esta en el historial
        For Each item As ListViewItem In ListView1.Items
            If item.Text = nombreArchivo Then
                archivoExiste = True
                Exit For
            End If
        Next

        ' Si no existe en el ListView1, lo agregamos
        If archivoExiste = False Then
            ListView1.Items.Add(nombreArchivo)
        End If
    End Sub

    ' ====================================================================
    ' MENU: ABRIR ARCHIVO
    ' ====================================================================
    Private Sub AbrirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AbrirToolStripMenuItem.Click
        With OpenFileDialog1
            .Filter = "Archivos de texto|*.txt|Todos los archivos|*.*"
            .FileName = ""

            ' Si el usuario selecciona un archivo y da en Aceptar
            If .ShowDialog() = DialogResult.OK Then
                nombreArchivo = .FileName
                AbrirArchivo()
            End If
        End With
    End Sub

    ' Proceso personalizado para leer el archivo del disco
    Private Sub AbrirArchivo()
        ' Usamos StreamReader para leer el archivo respetando acentos (Encoding.Default)
        Dim sr As New IO.StreamReader(nombreArchivo, System.Text.Encoding.Default)

        ' Volcamos todo el texto del archivo en tu TextBox3
        TextBox3.Text = sr.ReadToEnd()

        ' IMPORTANTE: Siempre cerrar la lectura
        sr.Close()

        ' Nos movemos a la pestaña de edicion automaticamente
        TabControl1.SelectedIndex = 2
    End Sub

    ' ====================================================================
    ' MENU: SALIR
    ' ====================================================================
    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        End ' Esta instruccion finaliza la aplicacion y limpia la memoria RAM
    End Sub

    ' ====================================================================
    ' MENU EDICION
    ' ====================================================================
    Private Sub DeshacerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeshacerToolStripMenuItem.Click
        If TextBox3.CanUndo Then
            TextBox3.Undo()
            TextBox3.ClearUndo()
        End If
    End Sub

    Private Sub CortarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CortarToolStripMenuItem.Click
        If TextBox3.SelectionLength > 0 Then
            TextBox3.Cut()
        End If
    End Sub

    Private Sub CopiarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopiarToolStripMenuItem.Click
        If TextBox3.SelectionLength > 0 Then
            TextBox3.Copy()
        End If
    End Sub

    Private Sub PegarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PegarToolStripMenuItem.Click
        If Clipboard.ContainsText() Then
            TextBox3.Paste()
        End If
    End Sub

    Private Sub SeleccionarTodoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SeleccionarTodoToolStripMenuItem.Click
        TextBox3.SelectAll()
    End Sub

    ' ====================================================================
    ' MENU FORMATO: FUENTE Y COLOR
    ' ====================================================================
    Private Sub CambiarFuente()
        Dim fontDialog As New FontDialog()
        fontDialog.Font = TextBox3.Font
        If fontDialog.ShowDialog() = DialogResult.OK Then
            TextBox3.Font = fontDialog.Font
        End If
    End Sub

    Private Sub FuenteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FuenteToolStripMenuItem.Click
        CambiarFuente()
    End Sub

    Private Sub ColorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ColorToolStripMenuItem.Click
        Dim colorDialog As New ColorDialog()
        colorDialog.Color = TextBox3.ForeColor
        If colorDialog.ShowDialog() = DialogResult.OK Then
            TextBox3.ForeColor = colorDialog.Color
        End If
    End Sub

    ' ====================================================================
    ' BOTONES DE ACCESO RAPIDO (TOOLSTRIP)
    ' ====================================================================

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Call AbrirToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Call GuardarToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        Call NuevoToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Call CortarToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        Call CopiarToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click
        Call SalirToolStripMenuItem_Click(sender, e)
    End Sub

    ' ====================================================================
    ' MENU: ACERCA DE
    ' ====================================================================
    Private Sub AcercaDeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AcercaDeToolStripMenuItem.Click
        Dim datos As String = "Analizador lexico" & vbCrLf &
                              "Version: 1.0"

        MessageBox.Show(datos, "Acerca de este programa", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ' ====================================================================
    ' MENU COMPILAR: PALABRAS RESERVADAS (Abre Form2)
    ' ====================================================================
    Private Sub ListadoDePalabrasReservadasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListadoDePalabrasReservadasToolStripMenuItem.Click
        Dim ventanaPalabras As New Form2()
        ventanaPalabras.ShowDialog()
    End Sub

    ' ====================================================================
    ' MENU COMPILAR: SEPARAR TOKENS (ANALIZADOR LEXICO)
    ' ====================================================================
    Private Sub SepararTokensToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SepararTokensToolStripMenuItem.Click
        ' 1. Limpiamos la tabla de tokens anteriores
        ListView2.Items.Clear()

        ' 2. Creamos los titulos de las columnas si no existen
        If ListView2.Columns.Count = 0 Then
            ListView2.Columns.Add("Token", 120)
            ListView2.Columns.Add("Tipo", 150)
        End If

        ' 3. Leemos el texto del cuadro "Codigo" (TextBox3)
        Dim codigo As String = TextBox3.Text

        If String.IsNullOrWhiteSpace(codigo) Then
            MessageBox.Show("No hay codigo para analizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' 4. Separamos simbolos pegados
        Dim simbolosASeparar() As String = {"+", "-", "*", "/", "=", "<", ">", "{", "}", "(", ")", "[", "]", ";", ",", """"}
        Dim codigoPreparado As String = codigo
        For Each sim In simbolosASeparar
            codigoPreparado = codigoPreparado.Replace(sim, " " & sim & " ")
        Next

        ' 5. Dividimos el texto en palabras usando los espacios y saltos de linea
        Dim delimitadores() As Char = {" "c, ControlChars.Cr, ControlChars.Lf, ControlChars.Tab}
        Dim tokens() As String = codigoPreparado.Split(delimitadores, StringSplitOptions.RemoveEmptyEntries)

        ' 6. Diccionarios de clasificacion (C++)
        Dim reservadas() As String = {"if", "while", "do", "for", "else", "switch", "int", "double", "string", "#include", "cout", "cin", "return", "using", "namespace", "std"}
        Dim operadoresAritmeticos() As String = {"+", "-", "*", "/", "="}
        Dim operadoresRelacionales() As String = {"<", ">"}
        Dim simbolos() As String = {"{", "}", "(", ")", "[", "]", ";", ",", """"}

        ' 7. Analizamos y clasificamos cada token
        For Each token As String In tokens
            Dim tipo As String = "Desconocido"

            If Array.IndexOf(reservadas, token) >= 0 Then
                tipo = "Palabra Reservada"
            ElseIf Array.IndexOf(operadoresAritmeticos, token) >= 0 Then
                tipo = "Operador Aritmetico"
            ElseIf Array.IndexOf(operadoresRelacionales, token) >= 0 Then
                tipo = "Operador Relacional"
            ElseIf Array.IndexOf(simbolos, token) >= 0 Then
                tipo = "Simbolo"
            ElseIf IsNumeric(token) Then
                tipo = "Numero"
            ElseIf Regex.IsMatch(token, "^[a-zA-Z_][a-zA-Z0-9_]*$") Then
                tipo = "Identificador"
            End If

            ' 8. Agregamos el resultado a tu tabla ListView2
            Dim fila As New ListViewItem(token)
            fila.SubItems.Add(tipo)
            ListView2.Items.Add(fila)
        Next
    End Sub

End Class