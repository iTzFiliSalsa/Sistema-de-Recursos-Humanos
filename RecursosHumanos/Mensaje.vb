Imports MySql.Data.MySqlClient
Imports System.Net.Mail
Imports System.Net
Public Class Mensaje
    Dim Correo As String
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs)
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim conexion As New MySqlConnection("server=localhost;database=ProyectoVisualBasic;user id=root;password=fili;SslMode=none")
        Dim consulta As New MySqlCommand("Select email,contraseña from usuarios where email='" & TextBox1.Text & "';", conexion)
        Correo = TextBox1.Text
        Try
            conexion.Open()
            Dim DataReader As MySqlDataReader = consulta.ExecuteReader()
            If DataReader.HasRows Then
                While DataReader.Read()
                    Dim email As New MailMessage
                    email.From = New MailAddress("thefilisalsa@gmail.com")
                    email.To.Add(TextBox1.Text)
                    email.Subject = "Contraseña de recuperacion"
                    email.Body = "Su contraseña de recuperación es: " & DataReader.GetValue(1)
                    email.IsBodyHtml = False
                    email.Priority = MailPriority.Normal
                    Dim smtp As New SmtpClient
                    smtp.Host = "smtp.gmail.com"
                    smtp.Port = 587
                    smtp.UseDefaultCredentials = False
                    smtp.Credentials = New NetworkCredential("thefilisalsa@gmail.com", "afss2344686")
                    smtp.EnableSsl = True
                    Try
                        Cursor = System.Windows.Forms.Cursors.WaitCursor
                        smtp.Send(email)
                        Cursor = System.Windows.Forms.Cursors.Default
                        MessageBox.Show("Contraseña de recuperacion enviado, Ingreselo en la parte de abajo", "Enviado")
                        contraseña.Enabled = True
                        sesion.Enabled = True
                    Catch ex As Exception
                        MessageBox.Show("Ocurrio un error al enviar el correo" & ex.Message, "Error")
                        Cursor = System.Windows.Forms.Cursors.Default
                    End Try
                End While

            Else
                MessageBox.Show("El correo electronico no existe en nuestra base de datos, intente nuevamente", "Error")
            End If
            conexion.Close()
        Catch ex As Exception
            MessageBox.Show("No existe" & ex.Message)
        End Try

    End Sub

    Private Sub Panel1_Paint_1(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub sesion_Click(sender As Object, e As EventArgs) Handles sesion.Click
        If (Inicio(Correo, contraseña.Text)) Then
            MenuPrincipal.Show()
            Me.Close()
        End If
    End Sub
    Function Inicio(ByVal usuario As String, ByVal contraseña As String) As Boolean
        Dim oConexion As New MySqlConnection("server=localhost;database=ProyectoVisualBasic;user id=root;password=fili;SslMode=none")
        Dim oDataAdapter As New MySqlDataAdapter
        Dim oDataSet As New DataSet
        Dim sSql As String
        Dim sw As Boolean = False
        Try
            sSql = "Select * from usuarios where email='" & usuario & "' and contraseña='" & contraseña & "';"
            oConexion.Open()
            oDataAdapter = New MySqlDataAdapter(sSql, oConexion)
            oDataSet.Clear()
            oDataAdapter.Fill(oDataSet, "usuarios")
            If (oDataSet.Tables("usuarios").Rows.Count() <> 0) Then
                Dim consulta As New MySqlCommand("Select nombre from usuarios where email='" & usuario & "';", oConexion)
                MenuPrincipal.Correo = usuario
                MenuPrincipal.FullName = consulta.ExecuteScalar
                sw = True
            Else
                MessageBox.Show("El codigo de ingreso no es valido", "Intente nuevamente")
            End If
        Catch ex As Exception
            MessageBox.Show("no se pudo" & ex.Message)
        End Try
        Return (sw)
    End Function
End Class