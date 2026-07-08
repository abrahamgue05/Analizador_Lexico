Public Class Form2

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Forzamos el tamaño de la caja de texto para que ocupe casi toda la ventana
        TextBox1.Size = New Size(275, 290)

        ' Configuramos la caja de texto para que sea modo lectura y tenga scroll
        TextBox1.Multiline = True
        TextBox1.ScrollBars = ScrollBars.Vertical
        TextBox1.ReadOnly = True

        ' La super lista de palabras reservadas categorizada
        Dim lista As String = "PALABRAS RESERVADAS C++" & vbCrLf &
                              "=======================" & vbCrLf & vbCrLf &
                              "TIPOS DE DATOS:" & vbCrLf &
                              "int, double, float, char, bool, void," & vbCrLf &
                              "string, auto, short, long, signed, unsigned," & vbCrLf &
                              "wchar_t, char8_t, char16_t, char32_t" & vbCrLf & vbCrLf &
                              "CONTROL DE FLUJO:" & vbCrLf &
                              "if, else, switch, case, default," & vbCrLf &
                              "while, do, for, break, continue," & vbCrLf &
                              "return, goto" & vbCrLf & vbCrLf &
                              "CLASES Y OBJETOS (POO):" & vbCrLf &
                              "class, struct, union, public, private," & vbCrLf &
                              "protected, virtual, override, final," & vbCrLf &
                              "this, friend, new, delete, operator" & vbCrLf & vbCrLf &
                              "MODIFICADORES:" & vbCrLf &
                              "const, constexpr, static, inline," & vbCrLf &
                              "explicit, mutable, volatile, register" & vbCrLf & vbCrLf &
                              "MANEJO DE ERRORES Y EXCEPCIONES:" & vbCrLf &
                              "try, catch, throw, noexcept" & vbCrLf & vbCrLf &
                              "LIBRERÍAS Y ESPACIOS DE NOMBRES:" & vbCrLf &
                              "#include, using, namespace, std," & vbCrLf &
                              "cout, cin, endl" & vbCrLf & vbCrLf &
                              "VALORES Y CONVERSIONES:" & vbCrLf &
                              "true, false, nullptr, sizeof, typeid," & vbCrLf &
                              "static_cast, dynamic_cast, const_cast" & vbCrLf & vbCrLf &
                              "OTROS OPERADORES LÓGICOS:" & vbCrLf &
                              "and, or, not, xor, bitand, bitor"

        TextBox1.Text = lista
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        ' Este evento se creó si le diste doble clic a la caja de texto por error.
        ' Lo dejamos vacío porque no necesitamos que haga nada cuando el texto cambie.
    End Sub

End Class