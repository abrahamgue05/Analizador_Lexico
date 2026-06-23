Public Class Form2

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' 1. Configuramos la caja de texto (TextBox1)
        TextBox1.Multiline = True
        TextBox1.ScrollBars = ScrollBars.Vertical
        TextBox1.Width = 250
        TextBox1.Height = 300

        ' 2. Deshabilitamos la escritura para que el usuario no modifique las reglas
        TextBox1.ReadOnly = True

        ' 3. Agregamos las 10 palabras reservadas para C++ según la imagen
        Dim palabrasCPP As String = "if" & vbCrLf &
                                    "while" & vbCrLf &
                                    "do" & vbCrLf &
                                    "for" & vbCrLf &
                                    "else" & vbCrLf &
                                    "switch" & vbCrLf &
                                    "int" & vbCrLf &
                                    "double" & vbCrLf &
                                    "string" & vbCrLf &
                                    "#include"

        ' Mostramos el texto en la caja
        TextBox1.Text = palabrasCPP
    End Sub

    ' =================================================================
    ' BOTÓN CERRAR CON CONFIRMACIÓN
    ' =================================================================
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Mostramos el mensaje con los botones Aceptar (OK) y Cancelar
        Dim resultado As DialogResult = MessageBox.Show("¿Estas seguro de salir?", "CONFIRMACION", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

        ' Si el usuario le da a "Aceptar", cerramos la ventana
        If resultado = DialogResult.OK Then
            Me.Close()
        End If
    End Sub

End Class