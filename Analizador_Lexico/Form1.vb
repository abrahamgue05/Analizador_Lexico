Imports System.Text.RegularExpressions ' Importamos la librería para usar Expresiones Regulares (Regex)

Public Class Form1

#Region "VARIABLES GLOBALES"
    ' Variable global que guarda la ruta exacta donde está guardado el archivo en la computadora
    Dim nombreArchivo As String
#End Region

#Region "MENÚ ARCHIVO (Operaciones del sistema)"

    ' ====================================================================
    ' NUEVO ARCHIVO
    ' ====================================================================
    Private Sub NuevoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoToolStripMenuItem.Click
        ' Borramos todo el contenido del cuadro de texto principal
        TextBox3.Text = ""
        ' Cambiamos la vista automáticamente a la pestaña número 3 (índice 2) que es la de edición
        TabControl1.SelectedIndex = 2
    End Sub

    ' ====================================================================
    ' GUARDAR ARCHIVO
    ' ====================================================================
    Private Sub GuardarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarToolStripMenuItem.Click
        ' Verificamos si el cuadro de texto está completamente vacío
        If TextBox3.Text = "" Then
            ' Mostramos un mensaje de error advirtiendo que no se puede guardar en blanco
            MsgBox("El archivo no puede estar vacio!!!", MsgBoxStyle.Critical, "Contenido vacio!!")
            ' Nos aseguramos de regresar al usuario a la pestaña de edición
            TabControl1.SelectedIndex = 2
        Else
            ' Abrimos una ventanita para preguntarle al usuario cómo quiere llamar a su archivo
            nombreArchivo = InputBox("Escribe un nombre para el archivo")

            ' Configuramos la ventana de guardado de Windows
            With SaveFileDialog1
                .FileName = nombreArchivo ' Le ponemos el nombre que el usuario acaba de escribir
                .Filter = "Archivos de texto|*.txt|Todos los archivos|*.*" ' Solo permitimos guardar como .txt

                ' Si el usuario presiona el botón de "Aceptar" en la ventana de guardado...
                If .ShowDialog() = DialogResult.OK Then
                    nombreArchivo = .FileName ' Actualizamos nuestra variable con la ruta completa y final
                    Guardar() ' Ejecutamos la función de abajo que hace el guardado físico
                End If
            End With
        End If
    End Sub

    ' ====================================================================
    ' FUNCIÓN AUXILIAR: GUARDAR FÍSICAMENTE EN EL DISCO DURO
    ' ====================================================================
    Private Sub Guardar()
        ' Abrimos un canal de escritura (StreamWriter) hacia la ruta del archivo
        Dim sw As New IO.StreamWriter(nombreArchivo, False, System.Text.Encoding.Default)

        ' Recorremos línea por línea todo lo que está escrito en nuestro cuadro de texto
        For Each linea In TextBox3.Lines
            sw.WriteLine(linea) ' Escribimos esa línea exacta en el archivo físico
        Next
        sw.Close() ' Cerramos el archivo para liberar la memoria de la computadora

        ' Variable bandera para saber si este archivo ya está en el historial de "Recientes"
        Dim archivoExiste As Boolean = False

        ' Revisamos todos los elementos que ya están en la lista (ListView1)
        For Each item As ListViewItem In ListView1.Items
            ' Si el texto del elemento es igual a la ruta de nuestro archivo...
            If item.Text = nombreArchivo Then
                archivoExiste = True ' Marcamos que ya existe
                Exit For ' Rompemos el ciclo porque ya no necesitamos seguir buscando
            End If
        Next

        ' Si terminamos de buscar y el archivo NO existía en la lista...
        If archivoExiste = False Then
            ListView1.Items.Add(nombreArchivo) ' Lo agregamos como un elemento nuevo al historial
        End If
    End Sub

    ' ====================================================================
    ' ABRIR ARCHIVO
    ' ====================================================================
    Private Sub AbrirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AbrirToolStripMenuItem.Click
        ' Configuramos la ventana de Windows para abrir archivos
        With OpenFileDialog1
            .Filter = "Archivos de texto|*.txt|Todos los archivos|*.*" ' Filtramos para que solo vea los .txt
            .FileName = "" ' Limpiamos el nombre predeterminado

            ' Si el usuario selecciona un archivo y presiona "Aceptar"...
            If .ShowDialog() = DialogResult.OK Then
                nombreArchivo = .FileName ' Guardamos la ruta del archivo seleccionado
                AbrirArchivo() ' Ejecutamos la función que lo lee
            End If
        End With
    End Sub

    ' ====================================================================
    ' FUNCIÓN AUXILIAR: LEER EL ARCHIVO DEL DISCO
    ' ====================================================================
    Private Sub AbrirArchivo()
        ' Abrimos un canal de lectura (StreamReader) configurado para leer acentos y símbolos
        Dim sr As New IO.StreamReader(nombreArchivo, System.Text.Encoding.Default)

        ' Leemos todo el contenido de golpe (ReadToEnd) y lo pegamos en nuestro cuadro de texto
        TextBox3.Text = sr.ReadToEnd()

        ' Cerramos el canal de lectura por seguridad
        sr.Close()

        ' Cambiamos a la pestaña de edición para que el usuario vea su código cargado
        TabControl1.SelectedIndex = 2
    End Sub

    ' ====================================================================
    ' SALIR DEL PROGRAMA
    ' ====================================================================
    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        End ' Apaga el programa por completo y libera la memoria RAM
    End Sub

#End Region

#Region "MENÚ EDICIÓN Y FORMATO"

    Private Sub DeshacerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeshacerToolStripMenuItem.Click
        ' Si el cuadro de texto tiene memoria de acciones previas...
        If TextBox3.CanUndo Then
            TextBox3.Undo() ' Deshacemos la última acción
            TextBox3.ClearUndo() ' Limpiamos la memoria de deshacer
        End If
    End Sub

    Private Sub CortarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CortarToolStripMenuItem.Click
        ' Si el usuario tiene seleccionado al menos 1 carácter...
        If TextBox3.SelectionLength > 0 Then
            TextBox3.Cut() ' Cortamos el texto al portapapeles
        End If
    End Sub

    Private Sub CopiarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopiarToolStripMenuItem.Click
        ' Si el usuario tiene seleccionado al menos 1 carácter...
        If TextBox3.SelectionLength > 0 Then
            TextBox3.Copy() ' Copiamos el texto al portapapeles
        End If
    End Sub

    Private Sub PegarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PegarToolStripMenuItem.Click
        ' Si hay texto guardado en el portapapeles de Windows...
        If Clipboard.ContainsText() Then
            TextBox3.Paste() ' Lo pegamos en el cuadro de texto
        End If
    End Sub

    Private Sub SeleccionarTodoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SeleccionarTodoToolStripMenuItem.Click
        TextBox3.SelectAll() ' Selecciona y sombrea todo el texto del editor
    End Sub

    ' ====================================================================
    ' CAMBIAR TIPO DE LETRA
    ' ====================================================================
    Private Sub CambiarFuente()
        Dim fontDialog As New FontDialog() ' Creamos la ventana de fuentes de Windows
        fontDialog.Font = TextBox3.Font ' Le decimos que empiece con la fuente que ya tenemos

        ' Si el usuario elige una fuente y da Aceptar...
        If fontDialog.ShowDialog() = DialogResult.OK Then
            TextBox3.Font = fontDialog.Font ' Aplicamos la nueva fuente a nuestro editor
        End If
    End Sub

    Private Sub FuenteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FuenteToolStripMenuItem.Click
        CambiarFuente() ' Llamamos a la función de arriba
    End Sub

    ' ====================================================================
    ' CAMBIAR COLOR DE LETRA
    ' ====================================================================
    Private Sub ColorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ColorToolStripMenuItem.Click
        Dim colorDialog As New ColorDialog() ' Creamos la paleta de colores de Windows
        colorDialog.Color = TextBox3.ForeColor ' Empezamos con el color actual

        ' Si el usuario elige un color y da Aceptar...
        If colorDialog.ShowDialog() = DialogResult.OK Then
            TextBox3.ForeColor = colorDialog.Color ' Cambiamos el color de todo el texto
        End If
    End Sub

#End Region

#Region "BARRA DE HERRAMIENTAS (Accesos Rápidos)"
    ' Todos estos botones simplemente "imitan" el clic de las opciones del menú superior
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
        ' Preparamos un texto con la información de los autores del programa
        Dim datos As String = "Analizador lexico" & vbCrLf & "Version: 1.0"
        ' Lo mostramos en un cuadro de mensaje con un icono de información
        MessageBox.Show(datos, "Acerca de este programa", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub ListadoDePalabrasReservadasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListadoDePalabrasReservadasToolStripMenuItem.Click
        ' Creamos una instancia de nuestra segunda ventana
        Dim ventanaPalabras As New Form2()
        ' La mostramos en la pantalla pausando la ventana principal
        ventanaPalabras.ShowDialog()
    End Sub

#End Region

#Region "MOTOR DEL ANALIZADOR LÉXICO"

    ' ====================================================================
    ' 1. FUNCIÓN AUXILIAR: Su único trabajo es clasificar una sola palabra
    ' ====================================================================
    Private Function ClasificarToken(palabra As String) As String
        ' Definimos nuestros diccionarios de datos basados en el lenguaje C++
        Dim reservadas() As String = {"if", "while", "do", "for", "else", "switch", "int", "double", "string", "#include", "cout", "cin", "return", "using", "namespace", "std"}
        Dim operadoresAritmeticos() As String = {"+", "-", "*", "/", "="}
        Dim operadoresRelacionales() As String = {"<", ">"}
        Dim simbolos() As String = {"{", "}", "(", ")", "[", "]", ";", ",", """"}

        ' Comparamos la palabra recibida con nuestros diccionarios.
        ' Si la encuentra (índice >= 0), retorna su clasificación inmediatamente.
        If Array.IndexOf(reservadas, palabra) >= 0 Then Return "Palabra Reservada"
        If Array.IndexOf(operadoresAritmeticos, palabra) >= 0 Then Return "Operador Aritmetico"
        If Array.IndexOf(operadoresRelacionales, palabra) >= 0 Then Return "Operador Relacional"
        If Array.IndexOf(simbolos, palabra) >= 0 Then Return "Simbolo"

        ' Si es un número puro, lo clasificamos
        If IsNumeric(palabra) Then Return "Numero"

        ' Usamos la regla Regex obligatoria para saber si cumple con las reglas de una variable (Empieza con letra, sigue con letras/números)
        If Regex.IsMatch(palabra, "^[a-zA-Z_][a-zA-Z0-9_]*$") Then Return "Identificador"

        ' Si no cayó en ninguna regla anterior, es un error léxico
        Return "Desconocido"
    End Function

    ' ====================================================================
    ' 2. BOTÓN PRINCIPAL: Procesa todo el texto y lo envía a la tabla
    ' ====================================================================
    Private Sub SepararTokensToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SepararTokensToolStripMenuItem.Click
        ' Vaciamos la tabla para que no se junten análisis anteriores
        ListView2.Items.Clear()

        ' Si las columnas de la tabla aún no existen, las creamos con sus tamaños
        If ListView2.Columns.Count = 0 Then
            ListView2.Columns.Add("Token", 120)
            ListView2.Columns.Add("Tipo", 150)
        End If

        ' Extraemos el texto crudo del editor
        Dim codigo As String = TextBox3.Text

        ' Si está en blanco o solo tiene espacios, detenemos el análisis y avisamos
        If String.IsNullOrWhiteSpace(codigo) Then
            MessageBox.Show("No hay codigo para analizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' LISTA DE SÍMBOLOS A SEPARAR: Queremos despegar símbolos que estén pegados a letras (Ej. "x=5;")
        Dim simbolosASeparar() As String = {"+", "-", "*", "/", "=", "<", ">", "{", "}", "(", ")", "[", "]", ";", ",", """"}
        Dim codigoPreparado As String = codigo

        ' Recorremos cada símbolo y lo reemplazamos por él mismo pero con un espacio antes y después
        For Each sim In simbolosASeparar
            codigoPreparado = codigoPreparado.Replace(sim, " " & sim & " ")
        Next

        ' Preparamos los separadores naturales (espacio, salto de línea y tabuladores)
        Dim delimitadores() As Char = {" "c, ControlChars.Cr, ControlChars.Lf, ControlChars.Tab}
        ' Cortamos todo el texto preparado en un arreglo de palabras individuales
        Dim tokens() As String = codigoPreparado.Split(delimitadores, StringSplitOptions.RemoveEmptyEntries)

        ' Evaluamos cada palabra suelta que sacamos del paso anterior
        For Each token As String In tokens
            ' Creamos una nueva fila visual en la tabla con el nombre de la palabra
            Dim fila As New ListViewItem(token)

            ' Llamamos a nuestra función ClasificarToken para que adivine qué es, y lo agregamos a la segunda columna
            fila.SubItems.Add(ClasificarToken(token))

            ' Insertamos la fila completa en la tabla visual
            ListView2.Items.Add(fila)
        Next
    End Sub

#End Region

#Region "SINTAXIS VISUAL (Colores en vivo)"

    ' ====================================================================
    ' EVENTO: Se dispara cada vez que el usuario teclea una letra
    ' ====================================================================
    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        ' Si se borró todo el texto, no hay nada que pintar, así que salimos
        If TextBox3.Text = "" Then Exit Sub

        ' Guardamos la posición exacta donde está el puntero parpadeando
        Dim posicionCursor As Integer = TextBox3.SelectionStart

        ' Seleccionamos todo el texto actual y lo pintamos de negro para "limpiar" colores de palabras borradas
        TextBox3.SelectAll()
        TextBox3.SelectionColor = Color.Black

        ' Preparamos una regla de búsqueda Regex. \b significa que debe ser una palabra exacta y completa.
        Dim palabrasReservadas As String = "\b(if|while|do|for|else|switch|int|double|string|cout|cin|return|using|namespace|std)\b|#include\b"

        ' Le pedimos a Regex que nos dé una lista de todas las palabras en el texto que coincidan con nuestra regla
        Dim coincidencias As MatchCollection = Regex.Matches(TextBox3.Text, palabrasReservadas)

        ' Recorremos cada coincidencia encontrada en el texto
        For Each match As Match In coincidencias
            ' Seleccionamos esa palabra exacta usando su posición (Index) y su tamaño (Length)
            TextBox3.Select(match.Index, match.Length)
            ' Pintamos esa pequeña selección de color azul
            TextBox3.SelectionColor = Color.Blue
        Next

        ' Regresamos el puntero exactamente a donde el usuario estaba escribiendo para que no note la interrupción
        TextBox3.Select(posicionCursor, 0)
        ' Nos aseguramos de que la siguiente letra que escriba siga siendo de color negro normal
        TextBox3.SelectionColor = Color.Black
    End Sub

#End Region

End Class