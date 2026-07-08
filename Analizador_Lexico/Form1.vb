Imports System.Text.RegularExpressions ' Importamos la librería para usar Expresiones Regulares (Regex)

Public Class Form1

#Region "VARIABLES GLOBALES"
    ' Variable global que guarda la ruta exacta donde está guardado el archivo en la computadora
    Dim nombreArchivo As String

    ' ====================================================================
    ' DICCIONARIOS DE DATOS DEL ANALIZADOR LÉXICO (Variables Globales)
    ' ====================================================================
    ' DICCIONARIO COMPLETO DE PALABRAS RESERVADAS C++
    Dim reservadas() As String = {"#include", "alignas", "alignof", "and", "and_eq", "asm", "auto", "bitand",
    "bitor", "bool", "break", "case", "catch", "char", "char8_t", "char16_t", "char32_t", "cin", "class", "compl",
    "concept", "const", "const_cast", "consteval", "constexpr", "constinit", "continue", "co_await", "co_return",
    "co_yield", "cout", "decltype", "default", "delete", "do", "double", "dynamic_cast", "else", "endl", "enum",
    "explicit", "export", "extern", "false", "float", "for", "friend", "goto", "if", "inline", "int", "long",
    "mutable", "namespace", "new", "noexcept", "not", "not_eq", "nullptr", "operator", "or", "or_eq", "private",
    "protected", "public", "register", "reinterpret_cast", "requires", "return", "short", "signed", "sizeof",
    "static", "static_assert", "static_cast", "std", "string", "struct", "switch", "template", "this",
    "thread_local", "throw", "true", "try", "typedef", "typeid", "typename", "union", "unsigned", "using",
    "virtual", "void", "volatile", "wchar_t", "while", "xor", "xor_eq"}
    Dim operadoresAritmeticos() As String = {"+", "-", "*", "/", "="}
    Dim operadoresRelacionales() As String = {"<", ">"}
    Dim simbolos() As String = {"{", "}", "(", ")", "[", "]", ";", ","} ' Quité las comillas de aquí porque ahora tienen su propia regla
#End Region

#Region "MENÚ ARCHIVO (Operaciones del sistema)"

    ' ====================================================================
    ' NUEVO ARCHIVO
    ' ====================================================================
    Private Sub NuevoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoToolStripMenuItem.Click
        TextBox3.Text = ""
        TabControl1.SelectedIndex = 2
    End Sub

    ' ====================================================================
    ' GUARDAR ARCHIVO
    ' ====================================================================
    Private Sub GuardarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarToolStripMenuItem.Click
        If TextBox3.Text = "" Then
            MsgBox("El archivo no puede estar vacio!!!", MsgBoxStyle.Critical, "Contenido vacio!!")
            TabControl1.SelectedIndex = 2
        Else
            nombreArchivo = InputBox("Escribe un nombre para el archivo")

            With SaveFileDialog1
                .FileName = nombreArchivo
                .Filter = "Archivos de texto|*.txt|Todos los archivos|*.*"

                If .ShowDialog() = DialogResult.OK Then
                    nombreArchivo = .FileName
                    Guardar()
                End If
            End With
        End If
    End Sub

    ' ====================================================================
    ' FUNCIÓN AUXILIAR: GUARDAR FÍSICAMENTE EN EL DISCO DURO
    ' ====================================================================
    Private Sub Guardar()
        Dim sw As New IO.StreamWriter(nombreArchivo, False, System.Text.Encoding.Default)
        For Each linea In TextBox3.Lines
            sw.WriteLine(linea)
        Next
        sw.Close()
    End Sub

    ' ====================================================================
    ' ABRIR ARCHIVO
    ' ====================================================================
    Private Sub AbrirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AbrirToolStripMenuItem.Click
        With OpenFileDialog1
            .Filter = "Archivos de texto|*.txt|Todos los archivos|*.*"
            .FileName = ""

            If .ShowDialog() = DialogResult.OK Then
                nombreArchivo = .FileName
                AbrirArchivo()
            End If
        End With
    End Sub

    ' ====================================================================
    ' FUNCIÓN AUXILIAR: LEER EL ARCHIVO DEL DISCO
    ' ====================================================================
    Private Sub AbrirArchivo()
        Dim sr As New IO.StreamReader(nombreArchivo, System.Text.Encoding.Default)
        TextBox3.Text = sr.ReadToEnd()
        sr.Close()
        TabControl1.SelectedIndex = 2
    End Sub

    ' ====================================================================
    ' SALIR DEL PROGRAMA
    ' ====================================================================
    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        End
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

    Private Sub FuenteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FuenteToolStripMenuItem.Click
        Dim fontDialog As New FontDialog()
        fontDialog.Font = TextBox3.Font
        If fontDialog.ShowDialog() = DialogResult.OK Then
            TextBox3.Font = fontDialog.Font
        End If
    End Sub

    Private Sub ColorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ColorToolStripMenuItem.Click
        Dim colorDialog As New ColorDialog()
        colorDialog.Color = TextBox3.ForeColor
        If colorDialog.ShowDialog() = DialogResult.OK Then
            TextBox3.ForeColor = colorDialog.Color
        End If
    End Sub

#End Region

#Region "BARRA DE HERRAMIENTAS"
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
#End Region

#Region "MENÚ ACERCA DE Y AYUDA"
    Private Sub AcercaDeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AcercaDeToolStripMenuItem.Click
        Dim datos As String = "Analizador lexico" & vbCrLf & "Version: 2.5"
        MessageBox.Show(datos, "Acerca de este programa", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub ListadoDePalabrasReservadasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListadoDePalabrasReservadasToolStripMenuItem.Click
        Dim ventanaPalabras As New Form2()
        ventanaPalabras.ShowDialog()
    End Sub
#End Region

#Region "MOTOR DEL ANALIZADOR LÉXICO"

    Private Function ClasificarToken(palabra As String) As String
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
            MessageBox.Show("No hay codigo para analizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

            ' >>> 1. REGLA: DETECTAR COMENTARIOS (//) <<<
            If c = "/"c AndAlso i + 1 < codigo.Length AndAlso codigo(i + 1) = "/"c Then
                While i < codigo.Length AndAlso codigo(i) <> vbCr AndAlso codigo(i) <> vbLf
                    token &= codigo(i)
                    i += 1
                    col += 1
                End While

                Dim filaComentario As New ListViewItem(token)
                filaComentario.SubItems.Add("Comentario")
                filaComentario.SubItems.Add(linea.ToString())
                filaComentario.SubItems.Add(colInicio.ToString())

                ' Verde un poco más marcado
                filaComentario.BackColor = Color.FromArgb(190, 245, 190)
                ListView2.Items.Add(filaComentario)
                Continue While
            End If

            ' >>> 2. NUEVA REGLA MASTER: DETECTAR CADENAS DE TEXTO / LIBRERÍAS ("...") <<<
            If c = """"c Then
                While i < codigo.Length
                    Dim charActual As Char = codigo(i)
                    token &= charActual
                    i += 1
                    col += 1

                    ' Si encontramos la comilla de cierre, terminamos la cadena
                    If token.Length > 1 AndAlso charActual = """"c Then
                        Exit While
                    End If
                    ' Si hay un salto de línea imprevisto, cerramos para evitar bucles infinitos
                    If charActual = vbCr Or charActual = vbLf Then
                        Exit While
                    End If
                End While

                Dim filaCadena As New ListViewItem(token)
                filaCadena.SubItems.Add("Cadena / Libreria")
                filaCadena.SubItems.Add(linea.ToString())
                filaCadena.SubItems.Add(colInicio.ToString())

                ' Morado/Violeta pastel más intenso
                filaCadena.BackColor = Color.FromArgb(230, 195, 255)
                ListView2.Items.Add(filaCadena)
                Continue While
            End If

            ' >>> 3. EXTRACCIÓN NORMAL (Letras, Números, Símbolos) <<<
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

            Dim tipoToken As String = ClasificarToken(token)
            Dim fila As New ListViewItem(token)
            fila.SubItems.Add(tipoToken)
            fila.SubItems.Add(linea.ToString())
            fila.SubItems.Add(colInicio.ToString())

            ' >>> COLORES DE FILA MÁS OSCUROS Y VIVOS <<<
            Select Case tipoToken
                Case "Palabra Reservada"
                    fila.BackColor = Color.FromArgb(255, 230, 150) ' Amarillo/Dorado más marcado
                Case "Operador Aritmetico"
                    fila.BackColor = Color.FromArgb(255, 185, 185) ' Rojo/Rosa más marcado
                Case "Operador Relacional"
                    fila.BackColor = Color.FromArgb(255, 210, 160) ' Naranja más marcado
                Case "Simbolo"
                    fila.BackColor = Color.FromArgb(195, 225, 255) ' Azul más marcado
                Case "Numero"
                    fila.BackColor = Color.FromArgb(220, 220, 220) ' Gris perfectamente visible
            End Select

            ListView2.Items.Add(fila)
        End While
    End Sub

#End Region

#Region "SINTAXIS VISUAL (Colores en vivo)"

    Private Function ConstruirRegex(arreglo() As String) As String
        Dim listaEscapada As New List(Of String)
        For Each item In arreglo
            listaEscapada.Add(Regex.Escape(item))
        Next
        Return String.Join("|", listaEscapada)
    End Function

    Private Sub PintarPalabras(textoCrudo As String, patronRegex As String, colorLetra As Color)
        Dim coincidencias As MatchCollection = Regex.Matches(textoCrudo, patronRegex)
        For Each match As Match In coincidencias
            TextBox3.Select(match.Index, match.Length)
            TextBox3.SelectionColor = colorLetra
        Next
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        If TextBox3.Text = "" Then Exit Sub

        Dim posicionCursor As Integer = TextBox3.SelectionStart

        TextBox3.SelectAll()
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

        ' Patrón para capturar texto entre comillas
        Dim regexCadenas As String = """[^""\r\n]*"""

        ' Pintamos según categoría
        PintarPalabras(TextBox3.Text, regexReservadas, Color.DarkGoldenrod)
        PintarPalabras(TextBox3.Text, regexAritmeticos, Color.Red)
        PintarPalabras(TextBox3.Text, regexRelacionales, Color.DarkOrange)
        PintarPalabras(TextBox3.Text, regexSimbolos, Color.DarkBlue)

        ' Pintamos las cadenas de texto en el editor (Color Púrpura)
        PintarPalabras(TextBox3.Text, regexCadenas, Color.Purple)

        ' Pintamos los comentarios al final de todo para asegurar que sobrescriban cualquier cosa
        PintarPalabras(TextBox3.Text, regexComentarios, Color.Green)

        TextBox3.Select(posicionCursor, 0)
        TextBox3.SelectionColor = Color.Black
    End Sub

#End Region

#Region "EVENTOS DE INTERFAZ"

    Private Sub ListView2_SizeChanged(sender As Object, e As EventArgs) Handles ListView2.SizeChanged
        If ListView2.Columns.Count = 4 Then
            Dim anchoTotal As Integer = ListView2.Width - 25

            If anchoTotal > 0 Then
                ListView2.Columns(0).Width = CInt(anchoTotal * 0.45) ' Token: 45%
                ListView2.Columns(1).Width = CInt(anchoTotal * 0.35) ' Tipo: 35%
                ListView2.Columns(2).Width = CInt(anchoTotal * 0.1) ' Línea: 10%
                ListView2.Columns(3).Width = CInt(anchoTotal * 0.1) ' Columna: 10%
            End If
        End If
    End Sub

#End Region

End Class