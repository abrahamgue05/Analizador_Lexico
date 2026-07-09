Imports System.Text.RegularExpressions
Imports System.Runtime.InteropServices

Public Class Form1

#Region "API DE WINDOWS (Anti-Parpadeo)"
    ' Importamos SendMessage de user32.dll para pausar el dibujado de la pantalla
    ' y evitar el parpadeo del texto al colorear múltiples palabras.
    <DllImport("user32.dll")>
    Private Shared Function SendMessage(hWnd As IntPtr, msg As Integer, wParam As Boolean, lParam As Integer) As IntPtr
    End Function
    Private Const WM_SETREDRAW As Integer = &HB
#End Region

#Region "VARIABLES GLOBALES"
    ' Control de resaltado (Highlighter)
    Private lastHighlightedStart As Integer = -1
    Private lastHighlightedLength As Integer = 0

    ' Bandera para evitar bucles infinitos durante el coloreo
    Private pintando As Boolean = False

    ' Control de longitud para detectar pegado de código masivo
    Private lastTextLength As Integer = 0
    Private nombreArchivo As String = ""

    ' ====================================================================
    ' DICCIONARIOS DE DATOS DEL ANALIZADOR LÉXICO
    ' ====================================================================
    Private reservadas() As String = {
        "#include", "alignas", "alignof", "and", "and_eq", "asm", "auto", "bitand", "bitor", "bool", "break",
        "case", "catch", "char", "char8_t", "char16_t", "char32_t", "cin", "class", "cmath", "compl", "concept",
        "const", "const_cast", "consteval", "constexpr", "constinit", "continue", "co_await", "co_return",
        "co_yield", "cout", "decltype", "default", "delete", "do", "double", "dynamic_cast", "else", "endl",
        "enum", "explicit", "export", "extern", "false", "float", "for", "friend", "fstream", "goto", "if",
        "inline", "int", "iostream", "long", "math.h", "mutable", "namespace", "new", "noexcept", "not",
        "not_eq", "nullptr", "operator", "or", "or_eq", "private", "protected", "public", "register",
        "reinterpret_cast", "requires", "return", "short", "signed", "sizeof", "static", "static_assert",
        "static_cast", "std", "stdio.h", "stdlib.h", "string", "struct", "switch", "template", "this",
        "thread_local", "throw", "true", "try", "typedef", "typeid", "typename", "union", "unsigned",
        "using", "vector", "virtual", "void", "volatile", "wchar_t", "while", "xor", "xor_eq"
    }

    Private operadoresAritmeticos() As String = {"+", "-", "*", "/", "="}
    Private operadoresRelacionales() As String = {"<", ">"}
    Private simbolos() As String = {"{", "}", "(", ")", "[", "]", ":", ";", ","}
#End Region

#Region "EVENTOS DE INICIO"
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Forzamos a que se pinte el número "1" de la primera línea al abrir el programa
        PictureBoxLineas.Invalidate()
    End Sub
#End Region

#Region "MENÚ ARCHIVO (Gestión del Documento)"
    Private Sub NuevoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoToolStripMenuItem.Click
        TabControl1.SelectedIndex = 2
        TextBox3.Clear()
        ListView2.Items.Clear()
    End Sub

    Private Sub AbrirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AbrirToolStripMenuItem.Click
        With OpenFileDialog1
            .Filter = "Archivos de texto|*.txt|Archivos C++|*.cpp|Todos los archivos|*.*"
            .FileName = ""
            If .ShowDialog() = DialogResult.OK Then
                nombreArchivo = .FileName
                AbrirArchivo()
            End If
        End With
    End Sub

    Private Sub AbrirArchivo()
        Using sr As New IO.StreamReader(nombreArchivo, System.Text.Encoding.Default)
            Dim contenidoDelArchivo As String = sr.ReadToEnd()
            TabControl1.SelectedIndex = 2
            TextBox3.Text = contenidoDelArchivo
        End Using
    End Sub

    Private Sub GuardarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarToolStripMenuItem.Click
        If String.IsNullOrWhiteSpace(TextBox3.Text) Then
            MessageBox.Show("El archivo no puede estar vacío.", "Contenido vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TabControl1.SelectedIndex = 2
            Return
        End If

        With SaveFileDialog1
            .FileName = InputBox("Escribe un nombre para el archivo", "Guardar como")
            .Filter = "Archivos de texto|*.txt|Todos los archivos|*.*"
            If .ShowDialog() = DialogResult.OK Then
                nombreArchivo = .FileName
                GuardarEnDisco()
            End If
        End With
    End Sub

    Private Sub GuardarEnDisco()
        Using sw As New IO.StreamWriter(nombreArchivo, False, System.Text.Encoding.Default)
            For Each linea In TextBox3.Lines
                sw.WriteLine(linea)
            Next
        End Using
    End Sub

    Private Sub ExportarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportarToolStripMenuItem.Click
        If ListView2.Items.Count = 0 Then
            MessageBox.Show("No hay tokens para exportar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim saveDialog As New SaveFileDialog() With {
            .Filter = "Archivo Excel (CSV)|*.csv",
            .Title = "Guardar tabla de tokens",
            .FileName = "Tokens_Analizador.csv"
        }

        If saveDialog.ShowDialog() = DialogResult.OK Then
            Try
                Using sw As New IO.StreamWriter(saveDialog.FileName, False, System.Text.Encoding.UTF8)
                    sw.WriteLine("Token,Tipo,Línea,Columna")
                    For Each item As ListViewItem In ListView2.Items
                        Dim lineaCSV As String = String.Format("""{0}"",""{1}"",{2},{3}",
                                                               item.Text.Replace("""", """"""),
                                                               item.SubItems(1).Text,
                                                               item.SubItems(2).Text,
                                                               item.SubItems(3).Text)
                        sw.WriteLine(lineaCSV)
                    Next
                End Using
                MessageBox.Show("Archivo exportado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Error al exportar: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Application.Exit()
    End Sub
#End Region

#Region "MENÚ EDICIÓN Y FORMATO"
    Private Sub DeshacerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeshacerToolStripMenuItem.Click
        If TextBox3.CanUndo Then
            TextBox3.Undo()
            TextBox3.ClearUndo()
        End If
    End Sub

    Private Sub CortarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CortarToolStripMenuItem.Click
        If TextBox3.SelectionLength > 0 Then TextBox3.Cut()
    End Sub

    Private Sub CopiarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopiarToolStripMenuItem.Click
        If TextBox3.SelectionLength > 0 Then TextBox3.Copy()
    End Sub

    Private Sub PegarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PegarToolStripMenuItem.Click
        If Clipboard.ContainsText() Then TextBox3.Paste()
    End Sub

    Private Sub SeleccionarTodoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SeleccionarTodoToolStripMenuItem.Click
        TextBox3.SelectAll()
    End Sub

    Private Sub FuenteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FuenteToolStripMenuItem.Click
        Using fontDialog As New FontDialog()
            fontDialog.Font = TextBox3.Font
            If fontDialog.ShowDialog() = DialogResult.OK Then TextBox3.Font = fontDialog.Font
        End Using
    End Sub

    Private Sub ColorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ColorToolStripMenuItem.Click
        Using colorDialog As New ColorDialog()
            colorDialog.Color = TextBox3.ForeColor
            If colorDialog.ShowDialog() = DialogResult.OK Then TextBox3.ForeColor = colorDialog.Color
        End Using
    End Sub
#End Region

#Region "BARRA DE HERRAMIENTAS (Accesos Rápidos)"
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        AbrirToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        GuardarToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        NuevoToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        CortarToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        CopiarToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click
        SalirToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub btnExportarBarra_Click(sender As Object, e As EventArgs) Handles btnExportarBarra.Click
        ExportarToolStripMenuItem_Click(sender, e)
    End Sub
#End Region

#Region "MOTOR DEL ANALIZADOR LÉXICO (Scanner)"
    Private Function ClasificarToken(palabra As String) As String
        If palabra = "." Then Return "Simbolo"
        If Array.IndexOf(reservadas, palabra) >= 0 Then Return "Palabra Reservada"
        If Array.IndexOf(operadoresAritmeticos, palabra) >= 0 Then Return "Operador Aritmetico"
        If Array.IndexOf(operadoresRelacionales, palabra) >= 0 Then Return "Operador Relacional"
        If Array.IndexOf(simbolos, palabra) >= 0 Then Return "Simbolo"
        If IsNumeric(palabra) Then Return "Numero"
        If Regex.IsMatch(palabra, "^[a-zA-Z_][a-zA-Z0-9_]*$") Then Return "Identificador"

        Return "Desconocido"
    End Function

    Private Sub SepararTokensToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SepararTokensToolStripMenuItem.Click
        ListView2.Items.Clear()

        If ListView2.Columns.Count = 0 Then
            ListView2.Columns.Add("Token", 100)
            ListView2.Columns.Add("Tipo", 100)
            ListView2.Columns.Add("Línea", 50)
            ListView2.Columns.Add("Col.", 50)
        End If

        Dim codigo As String = TextBox3.Text
        If String.IsNullOrWhiteSpace(codigo) Then
            MessageBox.Show("No hay código para analizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim linea As Integer = 1
        Dim col As Integer = 1
        Dim i As Integer = 0

        While i < codigo.Length
            Dim c As Char = codigo(i)

            If c = vbCrLf Or c = vbLf Or c = vbCr Then
                linea += 1
                col = 1
                i += 1
                Continue While
            End If

            If Char.IsWhiteSpace(c) Then
                col += 1
                i += 1
                Continue While
            End If

            Dim token As String = ""
            Dim colInicio As Integer = col

            ' 1. COMENTARIOS
            If c = "/"c AndAlso i + 1 < codigo.Length AndAlso codigo(i + 1) = "/"c Then
                While i < codigo.Length AndAlso codigo(i) <> vbCr AndAlso codigo(i) <> vbLf
                    token &= codigo(i)
                    i += 1
                    col += 1
                End While
                InsertarFila(token, "Comentario", linea, colInicio, Color.FromArgb(190, 245, 190))
                Continue While
            End If

            ' 2. CADENAS Y LIBRERÍAS
            If c = """"c Then
                While i < codigo.Length
                    Dim charActual As Char = codigo(i)
                    token &= charActual
                    i += 1
                    col += 1
                    If (token.Length > 1 AndAlso charActual = """"c) OrElse charActual = vbCr OrElse charActual = vbLf Then
                        Exit While
                    End If
                End While
                InsertarFila(token, "Cadena / Libreria", linea, colInicio, Color.FromArgb(230, 195, 255))
                Continue While
            End If

            ' 3. PALABRAS, NÚMEROS E IDENTIFICADORES
            If Char.IsLetter(c) Or c = "_" Or c = "#" Then
                While i < codigo.Length And (Char.IsLetterOrDigit(codigo(i)) Or codigo(i) = "_" Or codigo(i) = "#")
                    token &= codigo(i)
                    i += 1
                    col += 1
                End While
            ElseIf Char.IsDigit(c) Then
                While i < codigo.Length And Char.IsDigit(codigo(i))
                    token &= codigo(i)
                    i += 1
                    col += 1
                End While
            Else
                token = c
                i += 1
                col += 1
            End If

            ' CLASIFICACIÓN E INSERCIÓN
            Dim tipoToken As String = ClasificarToken(token)
            Dim colorFila As Color = Color.White

            Select Case tipoToken
                Case "Palabra Reservada" : colorFila = Color.FromArgb(255, 230, 150)
                Case "Operador Aritmetico" : colorFila = Color.FromArgb(255, 185, 185)
                Case "Operador Relacional" : colorFila = Color.FromArgb(255, 210, 160)
                Case "Simbolo" : colorFila = Color.FromArgb(195, 225, 255)
                Case "Numero" : colorFila = Color.FromArgb(220, 220, 220)
            End Select

            InsertarFila(token, tipoToken, linea, colInicio, colorFila)
        End While

        ActualizarEstadisticas()
    End Sub

    Private Sub InsertarFila(texto As String, tipo As String, fila As Integer, columna As Integer, colorFondo As Color)
        Dim item As New ListViewItem(texto)
        item.SubItems.Add(tipo)
        item.SubItems.Add(fila.ToString())
        item.SubItems.Add(columna.ToString())
        item.BackColor = colorFondo
        ListView2.Items.Add(item)
    End Sub
#End Region

#Region "SINTAXIS VISUAL (Coloreado en Vivo)"
    Private Function ConstruirRegex(arreglo() As String) As String
        Dim listaEscapada As New List(Of String)
        For Each item In arreglo
            listaEscapada.Add(Regex.Escape(item))
        Next
        Return String.Join("|", listaEscapada)
    End Function

    Private Sub PintarPalabrasLinea(texto As String, inicioLinea As Integer, patron As String, color As Color)
        Dim coincidencias = Regex.Matches(texto, patron)
        For Each m As Match In coincidencias
            TextBox3.Select(inicioLinea + m.Index, m.Length)
            TextBox3.SelectionColor = color
        Next
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        If pintando Then Exit Sub
        pintando = True

        SendMessage(TextBox3.Handle, WM_SETREDRAW, False, 0)
        Dim posicionCursor As Integer = TextBox3.SelectionStart
        Dim diferenciaCaracteres As Integer = Math.Abs(TextBox3.Text.Length - lastTextLength)

        Try
            If String.IsNullOrWhiteSpace(TextBox3.Text) Then Exit Sub

            If diferenciaCaracteres > 1 Then
                PintarSeccionTexto(TextBox3.Text, 0)
            Else
                Dim numLinea As Integer = TextBox3.GetLineFromCharIndex(posicionCursor)
                If numLinea >= 0 AndAlso numLinea < TextBox3.Lines.Length Then
                    Dim inicio As Integer = TextBox3.GetFirstCharIndexFromLine(numLinea)
                    PintarSeccionTexto(TextBox3.Lines(numLinea), inicio)
                End If
            End If
        Finally
            TextBox3.SelectionStart = posicionCursor
            TextBox3.SelectionLength = 0
            SendMessage(TextBox3.Handle, WM_SETREDRAW, True, 0)
            TextBox3.Invalidate()

            lastTextLength = TextBox3.Text.Length
            pintando = False
            PictureBoxLineas.Invalidate()
        End Try
    End Sub

    Private Sub TextBox3_Click(sender As Object, e As EventArgs) Handles TextBox3.Click
        If lastHighlightedStart <> -1 Then
            TextBox3.Select(lastHighlightedStart, lastHighlightedLength)
            TextBox3.SelectionBackColor = Color.White
            TextBox3.Select(TextBox3.SelectionStart, 0)
            lastHighlightedStart = -1
        End If
    End Sub

    Private Sub PintarSeccionTexto(texto As String, inicioIndex As Integer)
        TextBox3.Select(inicioIndex, texto.Length)
        TextBox3.SelectionColor = Color.Black

        Dim listaNormal As New List(Of String)
        For Each palabra In reservadas
            If palabra <> "#include" Then listaNormal.Add(palabra)
        Next

        Dim regexReservadas As String = "\b(" & String.Join("|", listaNormal) & ")\b|#include\b"
        Dim regexAritmeticos As String = ConstruirRegex(operadoresAritmeticos)
        Dim regexRelacionales As String = ConstruirRegex(operadoresRelacionales)
        Dim regexSimbolos As String = ConstruirRegex(simbolos)
        Dim regexComentarios As String = "//.*"
        Dim regexCadenas As String = """[^""\r\n]*"""

        PintarPalabrasLinea(texto, inicioIndex, regexReservadas, Color.DarkGoldenrod)
        PintarPalabrasLinea(texto, inicioIndex, regexAritmeticos, Color.Red)
        PintarPalabrasLinea(texto, inicioIndex, regexRelacionales, Color.DarkOrange)
        PintarPalabrasLinea(texto, inicioIndex, regexSimbolos, Color.DarkBlue)
        PintarPalabrasLinea(texto, inicioIndex, regexCadenas, Color.Purple)
        PintarPalabrasLinea(texto, inicioIndex, regexComentarios, Color.Green)
    End Sub
#End Region

#Region "INTERFAZ Y NAVEGACIÓN"
    Private Sub ListView2_SizeChanged(sender As Object, e As EventArgs) Handles ListView2.SizeChanged
        If ListView2.Columns.Count = 4 Then
            Dim anchoTotal As Integer = ListView2.Width - 25
            If anchoTotal > 0 Then
                ListView2.Columns(0).Width = CInt(anchoTotal * 0.45)
                ListView2.Columns(1).Width = CInt(anchoTotal * 0.35)
                ListView2.Columns(2).Width = CInt(anchoTotal * 0.1)
                ListView2.Columns(3).Width = CInt(anchoTotal * 0.1)
            End If
        End If
    End Sub

    Private Sub PictureBoxLineas_Paint(sender As Object, e As PaintEventArgs) Handles PictureBoxLineas.Paint
        e.Graphics.Clear(Color.White)
        Dim fuenteNumeros As New Font(TextBox3.Font.FontFamily, TextBox3.Font.Size)
        Dim brochaNumeros As New SolidBrush(Color.Black)

        Try
            Dim primerCaracterVisible As Integer = TextBox3.GetCharIndexFromPosition(New Point(0, 0))
            Dim primerLineaVisible As Integer = TextBox3.GetLineFromCharIndex(primerCaracterVisible)

            For i As Integer = primerLineaVisible To TextBox3.Lines.Length - 1
                Dim indicePrimerCaracterLinea As Integer = TextBox3.GetFirstCharIndexFromLine(i)
                If indicePrimerCaracterLinea >= 0 Then
                    Dim posicionY As Point = TextBox3.GetPositionFromCharIndex(indicePrimerCaracterLinea)
                    If posicionY.Y > TextBox3.Height Then Exit For
                    e.Graphics.DrawString((i + 1).ToString(), fuenteNumeros, brochaNumeros, 5, posicionY.Y + 6)
                End If
            Next
        Catch ex As Exception
            ' Manejo pasivo para evitar bloqueos gráficos
        End Try
    End Sub

    Private Sub TextBox3_VScroll(sender As Object, e As EventArgs) Handles TextBox3.VScroll
        PictureBoxLineas.Invalidate()
    End Sub

    Private Sub TextBox3_SizeChanged(sender As Object, e As EventArgs) Handles TextBox3.SizeChanged
        PictureBoxLineas.Invalidate()
    End Sub

    Private Sub ListView2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView2.SelectedIndexChanged
        If ListView2.SelectedItems.Count > 0 Then
            Dim item As ListViewItem = ListView2.SelectedItems(0)
            Dim numLinea As Integer = CInt(item.SubItems(2).Text) - 1
            Dim numCol As Integer = CInt(item.SubItems(3).Text) - 1

            If numLinea >= 0 AndAlso numLinea < TextBox3.Lines.Length Then
                If lastHighlightedStart <> -1 Then
                    TextBox3.Select(lastHighlightedStart, lastHighlightedLength)
                    TextBox3.SelectionBackColor = Color.White
                End If

                Dim inicioLinea As Integer = TextBox3.GetFirstCharIndexFromLine(numLinea)
                Dim posicionGlobal As Integer = inicioLinea + numCol

                TextBox3.Select(posicionGlobal, item.Text.Length)
                TextBox3.SelectionBackColor = Color.FromArgb(230, 220, 255)

                lastHighlightedStart = posicionGlobal
                lastHighlightedLength = item.Text.Length

                TextBox3.Focus()
                TextBox3.ScrollToCaret()
            End If
        End If
    End Sub
#End Region

#Region "BARRA DE ESTADO Y ACERCA DE"
    Private Sub ActualizarEstadisticas()
        Dim total As Integer = ListView2.Items.Count
        Dim res As Integer = 0, id As Integer = 0, num As Integer = 0, err As Integer = 0

        For Each item As ListViewItem In ListView2.Items
            Select Case item.SubItems(1).Text
                Case "Palabra Reservada" : res += 1
                Case "Identificador" : id += 1
                Case "Numero" : num += 1
                Case "Desconocido" : err += 1
            End Select
        Next

        lblEstadisticas.Text = String.Format("Total: {0} | Reservadas: {1} | Identificadores: {2} | Errores: {3}", total, res, id, err)
    End Sub

    Private Sub AcercaDeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AcercaDeToolStripMenuItem.Click
        MessageBox.Show("Analizador léxico" & vbCrLf & "Versión: 2.5", "Acerca de este programa", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub ListadoDePalabrasReservadasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListadoDePalabrasReservadasToolStripMenuItem.Click
        Using ventanaPalabras As New Form2()
            ventanaPalabras.ShowDialog()
        End Using
    End Sub
#End Region

End Class