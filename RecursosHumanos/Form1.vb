Imports MySql.Data.MySqlClient
Imports System.Net
Imports System.Net.Mail
Imports System.Security.Cryptography
Public Class Form1
    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles contraseña.TextChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        nombre.Text = ""
        nombre.Focus()
        colores(1)

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        apellido.Text = ""
        apellido.Focus()
        colores(2)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        email.Text = ""
        email.Focus()
        colores(3)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        telefono.Text = ""
        colores(4)
        telefono.Focus()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        contraseña.Text = ""
        contraseña.Focus()
        colores(5)
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles apellido.TextChanged

    End Sub

    Private Sub TextBox2_Click(sender As Object, e As EventArgs) Handles apellido.Click
        apellido.Text = ""
        colores(2)
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles email.TextChanged

    End Sub

    Private Sub TextBox3_Click(sender As Object, e As EventArgs) Handles email.Click
        email.Text = ""
        colores(3)
    End Sub

    Private Sub TextBox4_Click(sender As Object, e As EventArgs) Handles telefono.Click
        telefono.Text = ""
        colores(4)
    End Sub

    Private Sub TextBox5_Click(sender As Object, e As EventArgs) Handles contraseña.Click
        contraseña.Text = ""
        colores(5)
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        correoin.Text = ""
        correoin.Focus()
        colores(6)
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        passin.Text = ""
        passin.Focus()
        colores(7)
    End Sub

    Private Sub correoin_Click(sender As Object, e As EventArgs) Handles correoin.Click
        correoin.Text = ""
        colores(6)
    End Sub

    Private Sub passin_Click(sender As Object, e As EventArgs) Handles passin.Click
        passin.Text = ""
        colores(7)
    End Sub

    Private Sub TextBox1_Click(sender As Object, e As EventArgs) Handles nombre.Click
        nombre.Text = ""

        colores(1)
    End Sub
    Public Sub colores(tipo As Integer)
        If tipo = 1 Then
            Button2.FlatAppearance.BorderColor = (Color.LightSteelBlue)
            Button3.FlatAppearance.BorderColor = (Color.Gray)
            Button4.FlatAppearance.BorderColor = (Color.Gray)
            Button5.FlatAppearance.BorderColor = (Color.Gray)
            Button6.FlatAppearance.BorderColor = (Color.Gray)
            Button7.FlatAppearance.BorderColor = (Color.Gray)
            Button8.FlatAppearance.BorderColor = (Color.Gray)
        End If
        If tipo = 2 Then
            Button2.FlatAppearance.BorderColor = (Color.Gray)
            Button3.FlatAppearance.BorderColor = (Color.LightSteelBlue)
            Button4.FlatAppearance.BorderColor = (Color.Gray)
            Button5.FlatAppearance.BorderColor = (Color.Gray)
            Button6.FlatAppearance.BorderColor = (Color.Gray)
            Button7.FlatAppearance.BorderColor = (Color.Gray)
            Button8.FlatAppearance.BorderColor = (Color.Gray)
        End If
        If tipo = 3 Then
            Button2.FlatAppearance.BorderColor = (Color.Gray)
            Button3.FlatAppearance.BorderColor = (Color.Gray)
            Button4.FlatAppearance.BorderColor = (Color.LightSteelBlue)
            Button5.FlatAppearance.BorderColor = (Color.Gray)
            Button6.FlatAppearance.BorderColor = (Color.Gray)
            Button7.FlatAppearance.BorderColor = (Color.Gray)
            Button8.FlatAppearance.BorderColor = (Color.Gray)
        End If
        If tipo = 4 Then
            Button2.FlatAppearance.BorderColor = (Color.Gray)
            Button3.FlatAppearance.BorderColor = (Color.Gray)
            Button4.FlatAppearance.BorderColor = (Color.Gray)
            Button5.FlatAppearance.BorderColor = (Color.LightSteelBlue)
            Button6.FlatAppearance.BorderColor = (Color.Gray)
            Button7.FlatAppearance.BorderColor = (Color.Gray)
            Button8.FlatAppearance.BorderColor = (Color.Gray)
        End If
        If tipo = 5 Then
            Button2.FlatAppearance.BorderColor = (Color.Gray)
            Button3.FlatAppearance.BorderColor = (Color.Gray)
            Button4.FlatAppearance.BorderColor = (Color.Gray)
            Button5.FlatAppearance.BorderColor = (Color.Gray)
            Button6.FlatAppearance.BorderColor = (Color.LightSteelBlue)
            Button7.FlatAppearance.BorderColor = (Color.Gray)
            Button8.FlatAppearance.BorderColor = (Color.Gray)
        End If
        If tipo = 6 Then
            Button2.FlatAppearance.BorderColor = (Color.Gray)
            Button3.FlatAppearance.BorderColor = (Color.Gray)
            Button4.FlatAppearance.BorderColor = (Color.Gray)
            Button5.FlatAppearance.BorderColor = (Color.Gray)
            Button6.FlatAppearance.BorderColor = (Color.Gray)
            Button7.FlatAppearance.BorderColor = (Color.Gray)
            Button8.FlatAppearance.BorderColor = (Color.LightSteelBlue)
        End If
        If tipo = 7 Then
            Button2.FlatAppearance.BorderColor = (Color.Gray)
            Button3.FlatAppearance.BorderColor = (Color.Gray)
            Button4.FlatAppearance.BorderColor = (Color.Gray)
            Button5.FlatAppearance.BorderColor = (Color.Gray)
            Button6.FlatAppearance.BorderColor = (Color.Gray)
            Button7.FlatAppearance.BorderColor = (Color.LightSteelBlue)
            Button8.FlatAppearance.BorderColor = (Color.Gray)
        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim md5 As MD5CryptoServiceProvider
        Dim bytValue() As Byte
        Dim bytHash() As Byte
        Dim strPassOutput As String
        Dim i As Integer
        strPassOutput = ""
        md5 = New MD5CryptoServiceProvider
        bytValue = System.Text.Encoding.UTF8.GetBytes(passin.Text)
        bytHash = md5.ComputeHash(bytValue)
        md5.Clear()
        For i = 0 To bytHash.Length - 1
            strPassOutput &= bytHash(i).ToString("x").PadLeft(2, "0")
        Next

        If (Inicio(correoin.Text, strPassOutput)) Then
            MenuPrincipal.Show()
            Me.Close()
        End If


    End Sub
    Function Inicio(ByVal usuario As String, ByVal contraseña As String) As Boolean
        Dim local As New MySqlConnection("server=localhost;database=ProyectoVisualBasic;user id=root;password=fili;SslMode=none")
        Dim oConexion As New MySqlConnection("server=mante.hosting.acm.org; Database=mantehos_Usuarios; User Id=mantehos_root; Password=Ew,^mq5xy2x$; SslMode=none")
        Dim oDataAdapter As New MySqlDataAdapter
        Dim oDataSet As New DataSet
        Dim sSql As String
        Dim sw As Boolean = False
        Try
            local.Open()
            Cursor = System.Windows.Forms.Cursors.WaitCursor
            sSql = "Select nombre from usuarios where email='" & usuario & "' and contraseña='" & contraseña & "';"
            oConexion.Open()
            Dim hola As String
            Dim consultaa As New MySqlCommand("Select aceptado from aceptacion where email='" & usuario & "';", oConexion)
            hola = consultaa.ExecuteScalar
            If (hola = "no") Then
                MessageBox.Show("No a aceptado su correo electronico, intente de nuevo")
            Else
                oDataAdapter = New MySqlDataAdapter(sSql, local)
                oDataSet.Clear()
                oDataAdapter.Fill(oDataSet, "usuarios")
                If (oDataSet.Tables("usuarios").Rows.Count() <> 0) Then
                    Dim consulta As New MySqlCommand("Select nombre from usuarios where email='" & usuario & "';", local)
                    MenuPrincipal.Correo = usuario
                    MenuPrincipal.FullName = consulta.ExecuteScalar
                    Cursor = System.Windows.Forms.Cursors.Default
                    sw = True
                Else
                    MessageBox.Show("Usuario y/o Password no válidos", "Registro de Usuarios")
                    Cursor = System.Windows.Forms.Cursors.Default
                End If
            End If
            local.Close()

        Catch ex As Exception
            MessageBox.Show("no se pudo" & ex.Message)
        End Try
        Return (sw)
    End Function
    Function Registro(ByVal nombres As String, ByVal apellidos As String, ByVal emails As String, ByVal telefonos As String, ByVal contraseñas As String) As Boolean
        Dim oConexion As New MySqlConnection("server=localhost;database=ProyectoVisualBasic;user id=root;password=fili;SslMode=none")
        Dim online As New MySqlConnection("server=mante.hosting.acm.org; Database=mantehos_Usuarios; User Id=mantehos_root; Password=Ew,^mq5xy2x$; SslMode=none")
        Dim consulta As New MySqlCommand("Insert into usuarios(nombre,apellido,email,telefono,contraseña) values('" & nombres & "','" & apellidos & "','" & emails & "','" & telefonos & "',md5('" & contraseñas & "'));", oConexion)
        Dim consulta2 As New MySqlCommand("Insert into aceptacion(email,contrasena,aceptado) values('" & emails & "','" & contraseñas & "','no');", online)
        Dim extra As New MySqlCommand("Insert into adicional(email,sexo,pais,fecha,curp,rfc,imagen) values('" & emails & "','No configurado','No configurado','No configurado','No configurado','No configurado','No configurado');", oConexion)
        Dim sw As Boolean = False
        Try
            Dim email As New MailMessage
            email.From = New MailAddress("thefilisalsa@gmail.com")
            email.To.Add(emails)
            email.Subject = "Click para validar"
            email.Body = "Click para acceder al sistema http://mante.hosting.acm.org/consulta2.php?email=" & emails & "&aceptado=si&contrasena=" & contraseñas
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
                MessageBox.Show("Para acceder al sistema es necesario aceptar el correo enviado", "Enviado")
            Catch ex As Exception
                MessageBox.Show("Ocurrio un error al enviar el correo" & ex.Message, "Error")
                Cursor = System.Windows.Forms.Cursors.Default
            End Try
            oConexion.Open()
            online.Open()
            consulta2.ExecuteNonQuery()
            extra.ExecuteNonQuery()
            consulta.ExecuteNonQuery()
            oConexion.Close()
            online.Close()
            sw = True
        Catch ex As Exception
            sw = False
            MessageBox.Show("Ya existe una cuenta asociada a ese correo electronico" & ex.Message)
        End Try
        Return (sw)
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (Registro(nombre.Text, apellido.Text, email.Text, telefono.Text, contraseña.Text)) Then
            MessageBox.Show("Usuario agregado con exito, inicie sesión", "Registro de usuarios")

        End If
    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click
        Dim hijo As Mensaje = New Mensaje()
        GroupBox1.Dispose()
        GroupBox2.Dispose()
        AbrirFormEnPanel(hijo)
    End Sub
    Private Sub AbrirFormEnPanel(ByVal formpanel)
        If (Me.Panel1.Controls.Count > 0) Then
            Me.Panel1.Controls.RemoveAt(0)
        End If
        Dim fp As Form = New Form()
        fp = formpanel
        fp.TopLevel = False
        fp.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        fp.Dock = DockStyle.Fill
        Panel1.Controls.Add(fp)
        Me.Panel1.Tag = fp
        fp.Show()
    End Sub
End Class
